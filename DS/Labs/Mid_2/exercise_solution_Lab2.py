import pandas as pd
df1 = pd.read_csv('data1.csv', index_col=0)
#print(df1)
df2 = pd.read_csv('data2.csv', index_col=1)
#print("\n",df2)
df3 = df1.append(df2)
#print(df3)
df4 = pd.read_csv('data3.csv', index_col=0)
#print(df4)
result = pd.concat([df3, df4], axis=1)
#print(result)
jsonfile = pd.read_json('data.json')
#print(jsonfile)
result = pd.concat([result, jsonfile], ignore_index=True)
#print(result)
##However, we might not know which of our columns can be converted reliably
##to a numeric type. In that case we can just write:
result = result.apply(lambda x: pd.to_numeric(x, errors='coerce'))
##print(result)
result = result.fillna(result.mean())
result = result.round(2)
print(result)
result.to_csv("newdata.csv")


