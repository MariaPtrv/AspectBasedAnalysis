#!/usr/bin/env python
# coding: utf-8

# In[1]:




# In[2]:


aspects_list=["качество", "сервис", "аппаратура","удобство", "расположение", "питание", "размещение", "персонал"] #


# In[3]:

import elementpath
from ruwordnet import RuWordNet
wn = RuWordNet()
from xml.etree import ElementTree
import pandas as pd
##
import re
##
import nltk
from nltk.tokenize import word_tokenize, sent_tokenize
from nltk.corpus import stopwords
russian_stopwords = set(stopwords.words('russian'))
from pymystem3 import Mystem #pip install pymystem3
from string import punctuation
##
from difflib import SequenceMatcher
from spacy.matcher import Matcher

#Настройки для полного отображения таблицы
pd.set_option('display.max_rows', None)
pd.set_option('display.max_columns', None)
pd.set_option('display.max_colwidth', None)


# <h3>Импорт данных</h3>
# <i>Чтение отзывов из xml файла и сохранение их в виде dataframe</i>

# In[4]:


#tree = ElementTree.parse("tomatologicheskaya_klinika_vse_svoi_russia_moscow.xml")
#tree = ElementTree.parse("aboratoriya_invitro_russia.xml")
tree = ElementTree.parse("aboratoriya_gemotest_russia.xml")
root = tree.getroot()
reviews_array = []
for review in root:
    reviews_array.append(review.text)
data = {'review': reviews_array}
df = pd.DataFrame(data)


# In[5]:


df.info()


# **Separate into sentences**

# In[6]:


reviews_list = []
for row in df['review']:
    for sen in nltk.tokenize.sent_tokenize(row):
        reviews_list.append([sen, row, len(sen)])
        
df = pd.DataFrame(reviews_list, columns =['sentence', 'review', 'len'])


# **Удаление предложений меньше 10 символов**

# In[7]:


#df[df['sentence'].apply(lambda x: len(x) < 10)]
#df = df[df.len > 10]


# **Noise cleaning - spacing, charachers, lowercaseing**

# In[8]:


df.dropna(inplace = True)
df['sentence'] = df['sentence'].apply(str.lower)
df['review'] = df['review'].apply(lambda x: re.sub(r'[^\w\d\s\']+', '', x))  


# In[9]:


mystem = Mystem() 
def preprocess_text(text):
    tokens = mystem.lemmatize(text.lower())
    tokens = [token for token in tokens if token not in stopwords              and token != " "               and token.strip() not in punctuation]
    
    text = " ".join(tokens)
    return text


# In[10]:


import spacy
nlp = spacy.load('ru_core_news_sm')


# <h1>Выявление паттернов</h1>

# In[11]:


nlp = spacy.load('ru_core_news_md') #python -m spacy download ru_core_news_md
chanks_text = []
sentences = list(df.sentence)


# In[12]:


pattern1 = [{"POS": "NOUN"}, {"POS": "ADJ"}, {"IS_PUNCT": True, "OP": "+"}, {"POS": "ADJ"}]
pattern2 = [{"POS": "VERB"}, {"POS": "VERB"}, {"POS": "NOUN"}]
pattern3 = [ {"POS": "ADJ", "OP": "+"}, {"POS": "NOUN"}]
pattern4 = [ {"POS": "NOUN"}, {"POS": "ADV"}]
pattern5 = [{"POS": "NOUN"}, {"POS": "ADJ"}, {"POS": "CONJ", "OP": "?"}, {"POS": "ADJ"}]


# In[13]:


matcher = Matcher(nlp.vocab)
matcher.add("[pattern1]", [pattern1])
matcher.add("[pattern2]", [pattern2])
matcher.add("[pattern3]", [pattern3])
matcher.add("[pattern4]", [pattern4])
matcher.add("[pattern5]", [pattern5])


# In[ ]:


for sen in sentences:
    doc = nlp(sen)
    matches = matcher(doc)
    for match_id, start, end in matches:
        string_id = nlp.vocab.strings[match_id] 
        span = doc[start:end]
        chanks_text.append(span.text)   


# <hr size="5"/>

# <h1>Выделение существительных в чанках, присвоение тональности чанкам </h1>
# <h3>Существительное     Текст      Тональность (>0 - положительная, <0 - отрицательные) </h3>

# In[ ]:


from dostoevsky.tokenization import RegexTokenizer
from dostoevsky.models import FastTextSocialNetworkModel

tokenizer = RegexTokenizer()
model = FastTextSocialNetworkModel(tokenizer=tokenizer)


# In[ ]:


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
                sentiment_value =  (-1)*sents.get('negative')
            else:
                sentiment_value = sents.get('positive')
            chank_text_noun_sentiment.append([span.text, sen, sentiment_value]) 


# In[ ]:


chank_text_noun_sentiment


# <h1>Присвоение перечня гипонимов, синонимов аспектам</h1>

# In[ ]:


def get_clear_words(text):
    
    result =[]
    pattern_nouns = [{"POS": "NOUN"}]
    matcher = Matcher(nlp.vocab)
    matcher.add("[pattern_nouns]", [pattern_nouns])
    doc = nlp(text)
    for match_id, start, end in matcher(doc):
        string_id = nlp.vocab.strings[match_id] 
        span = doc[start:end]     
        result.append(str(span.text).lower())
    return result


# In[ ]:


aspects_alt = []
for aspect_item in aspects_list:
    aspect_words = []
    senses =  wn.get_senses(aspect_item)
    for sense in senses:
        aspect_words.append(get_clear_words(sense.synset.title))
    for hypernyms in wn.get_senses(aspect_item)[0].synset.hypernyms:
        aspect_words.append(get_clear_words(hypernyms.title))
      
    aspect_words.append([aspect_item])
    words = [i for n, i in enumerate(aspect_words) if i not in aspect_words[:n]]
    aspects_alt.append([aspect_item,words])   


# In[ ]:


aspects_alt


# In[ ]:


chank_text_noun_sentiment


# <h1>Объединение аспектов и чанков на основе смыслового сходства</h1>
# <h3>Добавление к аспекту происходит в случае, если показатель сходства больше 0.5</h3>

# In[ ]:


def similar(a, b):
    return SequenceMatcher(None, a, b).ratio()


# In[ ]:


aspects_simwords= []
for aspect in aspects_alt:
    avg_values = []
    sim_words =  []
    for word in aspect[1]:
        sim_chanks = []             #фразы, подходящие по смыслу к слову, похожему на аспект       
        if len(word) > 0:
            for chank in chank_text_noun_sentiment:
                value_sim = similar(word[0], chank[0])
                if (value_sim > 0.5):                 #похожи
                    sim_chanks.append(chank[2])
                    #print(word[0], '    ',  chank[1], '    ',   chank[2]) 
            #print(word[0], sum(sim_chanks)/len(sim_chanks))
            if len(sim_chanks) > 0:
                sim_words.append([word[0], sum(sim_chanks)/len(sim_chanks)])
                avg_values.append(sum(sim_chanks)/len(sim_chanks))
    ans = sum(avg_values)/len(avg_values)
    print(aspect, '   ', round(5*(1+ ans)/2,2))
    aspects_simwords.append([aspect, sim_words,ans, round(5*(1+ ans)/2,2)])     


# In[ ]:





# In[ ]:





# In[ ]:




