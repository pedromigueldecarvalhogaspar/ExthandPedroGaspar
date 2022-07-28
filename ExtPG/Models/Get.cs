using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExtPG.Models
{
    public class Get
    {
        string Symbol = "tBTCUSD";
        public void Load()
        {
            string stringUrl = String.Format($"https://api-pub.bitfinex.com/v2/trades/{Symbol}/hist");
            WebRequest requestObjGet = WebRequest.Create(stringUrl);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string stringResult = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                stringResult = sr.ReadToEnd();
                Console.Write(stringResult);
                sr.Close();
            }
        }
    }
}
