
import pandas as pd
import datetime as dt
from dateutil.relativedelta import relativedelta
from flask import Flask, jsonify, request
from flask_cors import CORS
app = Flask(__name__)
CORS(app)

@app.route("/", methods=['GET','POST'])
def main():
    inputData = request.get_json()
    transactionamount = int(inputData["roundamount"])
    timeframe = int(inputData["timeframe"])
    pd.set_option('display.float_format', '{:.2f}'.format)
    df =pd.read_excel('BankData.xlsx')
    
    
    df.head()
    df['DATE'] = pd.to_datetime(df['DATE'])
    df.head()
    
    x = dt.datetime(2019, 5, 3)
        
    olddate = x + relativedelta(months=-timeframe)
    olddate
    mask = (df['DATE'] < x) & (df['DATE'] >= olddate)
    df_new = df.loc[mask]
    df_new
    df_new['BALANCE AMT'] = df_new['BALANCE AMT'].abs()
    df_new['BALANCE AMT']= df_new['BALANCE AMT'].astype(int)
    df_new
    df_mod = df_new['BALANCE AMT'] % transactionamount
    total = df_mod.sum()
    return str(total)

if __name__ == '__main__':
    app.run(debug=False);
