import feedparser
import sys
import pyodbc
import requests
import requests_toolbelt




################################ Set SQL Server ######################################
server = 'LAPTOP-AHLA95LV'
database = 'NewsExtractor'

cnxn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server}; \
                       SERVER=' + server + '; \
                       DATABASE=' + database +'; \
                       Trusted_Connection=yes;')

cursor = cnxn.cursor()

cursor.execute("TRUNCATE TABLE Dataset") # remove all the data fro the table

cursor.commit()
######################################################################################







################################ RSS FEED Parser #####################################
RSS_URLS = ['http://www.dn.se/nyheter/m/rss/',
            'https://rss.aftonbladet.se/rss2/small/pages/sections/senastenytt/', 'https://feeds.expressen.se/nyheter/',
            'http://www.svd.se/?service=rss', 'http://api.sr.se/api/rss/program/83?format=145',
            'http://www.svt.se/nyheter/rss.xml'
              ]

posts = []

for url in RSS_URLS:
    posts.extend(feedparser.parse(url).entries)
######################################################################################




################### Extracting Only the Titles From RSS FEED #########################
def OnlyTitlesandSumaries():
    only_titles_and_summaries = []
    for x in posts:
        tempdict = {}
        tempdict["title"] = x["title"]
        tempdict["summary"] = x["summary"]
        only_titles_and_summaries.append(tempdict)
    return only_titles_and_summaries

Only_the_titles_Summaries = OnlyTitlesandSumaries()

#print(OnlyTitles())


def TitleAndSummaryList():
    title_and_summary_list = []
    temp_and_summary_title_list = []
    for x in Only_the_titles_Summaries:
        for key in x:
            if 'title' == key:
                firstkey = x[key]
            if 'summary' == key:
                secondkey = x[key]
                temp_and_summary_title_list.append(firstkey + ' ' + secondkey)
        title_and_summary_list.append(temp_and_summary_title_list)
        temp_and_summary_title_list = []
    return title_and_summary_list

The_Title_Summary_List = TitleAndSummaryList()

#print(TitleList())
######################################################################################

#################### Unifying Lists of List for Title ################################

def PrintDeposit():
    newList= []
    for item in The_Title_Summary_List:
        for value in item:
            newList.append(value)
    return newList



oldList = PrintDeposit()

#print(oldList)


#################### Running the Peltarion Algorightm #################################

def get_prediction(input_dict, token, url):
     payload = requests_toolbelt.MultipartEncoder(input_dict)
     r = requests.post(url, data=payload, headers={'Content-Type': payload.content_type}, auth=(token, ''))
     return(eval(r.text))



def RunAPI():
    newerList = []
    for i in oldList:
        input_dict = {"Heading":'"'+i+'"'}
        token = "942a949d-2128-475b-9fde-1d0fb1a6f96c"
        url = "https://a.azure-eu-west.platform.peltarion.com/deployment/40fbaf78-140f-4648-a66a-63d2b936a2ef/forward"
        pred = get_prediction(input_dict, token, url)
        newerList.append(pred)
    return newerList


peltarion_return = RunAPI()

#print(peltarion_return)

#print(len(peltarion_return))

######################################################################################


#################### Extracting the Topic of the Title ###############################

def FindMaxValue():
    results = []
    tempValue = 0.0
    tempKey = ""
    for d in peltarion_return:
        for k,v in d.items():
            if v > tempValue:
                tempValue = v
                tempKey = k
        results.append(tempKey)
        tempValue = 0.0
    return results


#print(FindMaxValue())

#print(len(FindMaxValue()))

foundTitle = FindMaxValue()

######################################################################################

##################### Extracting the all three values from RSS FEED ##################
allitems = []


for x in posts:
    tempdict = {}
    tempdict["title"] = x["title"]
    tempdict["summary"] = x["summary"]
    tempdict["link"] = x["link"]
    allitems.append(tempdict)

#print(allitems)


finalList = []
tempList = []
key1 = "title"
key2 = "summary"
key3 = "link"

for x in allitems:
    for key in x:
        if key1 == key:
            tempList.append(x[key])
        if key2 == key:
            tempList.append(x[key])
        if key3 == key:
            tempList.append(x[key])
    finalList.append(tempList)
    tempList = []

#print(finalList)

######################################################################################

######################### Concatenate Pletarion with RSS #############################


newList = [[y] + x for y, x in zip(foundTitle, finalList)]

print(newList)




######################################################################################


records = newList


insert_query = '''INSERT INTO Dataset (topic, title, summary, link)
                    VALUES (?, ?, ?, ?);'''

for row in records:

    values = (row[0], row[1], row[2], row[3])

    cursor.execute(insert_query, values)

cnxn.commit()

cursor.execute('SELECT * FROM Dataset')

for row in cursor:
    print(row)



