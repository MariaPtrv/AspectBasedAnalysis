import elementpath
import xml.etree.ElementTree as ET
from xml.etree import ElementTree
import pandas as pd
import re
import nltk
from nltk.corpus import stopwords
russian_stopwords = set(stopwords.words('russian'))
from difflib import SequenceMatcher
from spacy.matcher import Matcher
import spacy
nlp = spacy.load('ru_core_news_sm')
from dostoevsky.tokenization import RegexTokenizer
from dostoevsky.models import FastTextSocialNetworkModel
from ruwordnet import RuWordNet
wn = RuWordNet()

def read_xml(path):
    tree = ElementTree.parse("aboratoriya_invitro_russia.xml")
    root = tree.getroot()
    reviews_array = []
    for review in root:
        reviews_array.append(review.text)
    data = {'review': reviews_array}
    df = pd.DataFrame(data)
    return df

def preparing_df(df):
    reviews_list = []
    for row in df['review']:
        for sen in nltk.tokenize.sent_tokenize(row):
            reviews_list.append([sen, row, len(sen)])

    df = pd.DataFrame(reviews_list, columns=['sentence', 'review', 'len'])
    df.dropna(inplace=True)
    df['sentence'] = df['sentence'].apply(str.lower)
    df['review'] = df['review'].apply(lambda x: re.sub(r'[^\w\d\s\']+', '', x))
    return df

def find_patterns(df):
    nlp = spacy.load('ru_core_news_md')  # python -m spacy download ru_core_news_md
    chanks_text = []
    sentences = list(df.sentence)
    pattern1 = [{"POS": "NOUN"}, {"POS": "ADJ"}, {"IS_PUNCT": True, "OP": "+"}, {"POS": "ADJ"}]
    pattern2 = [{"POS": "VERB"}, {"POS": "VERB"}, {"POS": "NOUN"}]
    pattern3 = [{"POS": "ADJ", "OP": "+"}, {"POS": "NOUN"}]
    pattern4 = [{"POS": "NOUN"}, {"POS": "ADV"}]
    pattern5 = [{"POS": "NOUN"}, {"POS": "ADJ"}, {"POS": "CONJ", "OP": "?"}, {"POS": "ADJ"}]
    matcher = Matcher(nlp.vocab)
    matcher.add("[pattern1]", [pattern1])
    matcher.add("[pattern2]", [pattern2])
    matcher.add("[pattern3]", [pattern3])
    matcher.add("[pattern4]", [pattern4])
    matcher.add("[pattern5]", [pattern5])
    for sen in sentences:
        doc = nlp(sen)
        matches = matcher(doc)
        for match_id, start, end in matches:
            string_id = nlp.vocab.strings[match_id]
            span = doc[start:end]
            chanks_text.append(span.text)
    tokenizer = RegexTokenizer()
    model = FastTextSocialNetworkModel(tokenizer=tokenizer)
    chank_text_noun_sentiment = []
    pattern_nouns = [{"POS": "NOUN"}]
    pattern_verbs = [{"POS": "VERB"}]
    matcher = Matcher(nlp.vocab)
    matcher.add("[pattern_nouns]", [pattern_nouns])
    matcher.add("[pattern_verbs]", [pattern_verbs])

    for sen in chanks_text:
        doc = nlp(sen)
        matches = matcher(doc)
        for match_id, start, end in matches:
            string_id = nlp.vocab.strings[match_id]
            span = doc[start:end]
            results = model.predict([sen], k=5)
            sents = results[0]
            if (sents.get('negative') < -0.2 or sents.get('positive') > 0.2):
                if (sents.get('negative') > sents.get('positive')):
                    sentiment_value = (-1) * sents.get('negative')
                else:
                    sentiment_value = sents.get('positive')
                chank_text_noun_sentiment.append([span.text, sen, sentiment_value])
    return chank_text_noun_sentiment


def get_clear_words(text):
    result = []
    pattern_nouns = [{"POS": "NOUN"}]
    matcher = Matcher(nlp.vocab)
    matcher.add("[pattern_nouns]", [pattern_nouns])
    doc = nlp(text)
    for match_id, start, end in matcher(doc):
        string_id = nlp.vocab.strings[match_id]
        span = doc[start:end]
        result.append(str(span.text).lower())
    return result

def find_hypernyms(aspects_list):
    aspects_alt = []
    for aspect_item in aspects_list:
        aspect_words = []
        test = 1
        senses = wn.get_senses(aspect_item)
        for sense in senses:
            aspect_words.append(get_clear_words(sense.synset.title))
        for hypernyms in wn.get_senses(aspect_item)[0].synset.hypernyms:
            aspect_words.append(get_clear_words(hypernyms.title))
        aspect_words.append([aspect_item])
        words = [i for n, i in enumerate(aspect_words) if i not in aspect_words[:n]]
        aspects_alt.append([aspect_item, words])
    return aspects_alt

def similar(a, b):
    return SequenceMatcher(None, a, b).ratio()

def merge_aspects(aspects_alt, chank_text_noun_sentiment):
    aspects_simwords = []
    for aspect in aspects_alt:
        avg_values = []
        sim_words = []
        for word in aspect[1]:
            sim_chanks = []  # фразы, подходящие по смыслу к слову, похожему на аспект
            if len(word) > 0:
                for chank in chank_text_noun_sentiment:
                    value_sim = similar(word[0], chank[0])
                    if (value_sim > 0.5):  # похожи
                        sim_chanks.append(chank[2])
                        # print(word[0], '    ',  chank[1], '    ',   chank[2])
                # print(word[0], sum(sim_chanks)/len(sim_chanks))
                if len(sim_chanks) > 0:
                    sim_words.append([word[0], sum(sim_chanks) / len(sim_chanks)])
                    avg_values.append(sum(sim_chanks) / len(sim_chanks))
        ans = sum(avg_values) / len(avg_values)
        print(aspect[0], '   ', round(5 * (1 + ans) / 2, 2))
        aspects_simwords.append([aspect[0],  round(5 * (1 + ans) / 2, 2)])
    return aspects_simwords

def get_answer(answer_list):
    root = ET.Element('aspects')
    for value in answer_list:
        aspect = ET.Element('aspect', name=value[0])
        aspect.text = str(value[1])
        root.append(aspect)
    xml_str = ET.tostring(root, encoding="utf-8", method="xml")
    print(xml_str.decode(encoding="utf-8"))
    savefile = open("answer.xml", "w", encoding="utf-8")
    savefile.write(xml_str.decode(encoding="utf-8"))
#path = "aboratoriya_gemotest_russia.xml"
#aspects_list = ["качество", "сервис", "аппаратура","удобство", "расположение", "питание", "размещение", "персонал"]
df = read_xml(path)
chank_text_noun_sentiment = find_patterns(preparing_df(df))
aspects_alt= find_hypernyms(aspects_list)
get_answer(answer_list)