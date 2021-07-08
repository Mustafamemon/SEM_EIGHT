# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""
import pandas as pd

data = {'cities' : ['lahore','karachi',],
        'provinces' : ['punjab','sindh']}

# store data as DataFrame object. Assign object name as frame
frame1 = pd.DataFrame(data)

# print frame
print(frame1)

data2 = {"cities": ["islamabad","karachi","peshawar","quetta"],
  "provinces": ["capital","sindh", "KPK","Balochistan"]}

frame2 = pd.DataFrame(data2) 
print(frame2)

# combine both objects frame1 and frame2; without any duplicate rows and re-arrange all indexes

frame3 = pd.concat([frame1,frame2],ignore_index=True) 
frame3 = frame3.drop_duplicates() 
frame3 = frame3.sort_values("provinces") 
frame3 = frame3.reset_index(drop=True) 

#help(pd.DataFrame) 

print(frame3) 





