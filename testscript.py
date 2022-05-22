#!/usr/bin/env python
# coding: utf-8

# In[1]:


path = "tomatologicheskaya_klinika_vse_svoi_russia_moscow.xml"
aspects = ['сервис', 'качество', 'успех']


# In[2]:


from xml.etree import ElementTree
import pandas as pd


# In[3]:


tree = ElementTree.parse(path)
root = tree.getroot()
reviews_array = []
for review in root:
    reviews_array.append(review.text)
data = {'review': reviews_array}
df = pd.DataFrame(data)


# In[4]:


answer =[]
first_row = df.iloc[0].tolist()
for aspect in aspects:
    answer.append([aspect, first_row])


# In[ ]:
print(answer)



