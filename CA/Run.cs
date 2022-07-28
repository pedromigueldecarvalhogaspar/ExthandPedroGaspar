using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA
{
    class Run
    {

        public static void Cena()
        {
            string TimeFrame = "1h";
            string Symbol = "tBTCUSD";
            string Section = "last";

            string stringUrl = String.Format($"https://api-pub.bitfinex.com/v2/candles/trade:{TimeFrame}:{Symbol}/{Section}");
            WebRequest requestObjGet = WebRequest.Create(stringUrl);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string stringResult = null;
            string[] array;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                stringResult = sr.ReadToEnd();
                Console.WriteLine(stringResult);
                array = stringResult.Split(',');
            }


            double max=0;
            double min =0;
            double average = 0;
            for (int i = 0; i < array.Length; i++)
            {
                switch (i)
                {
                    case 2:
                        max = double.Parse(array[i], CultureInfo.InvariantCulture.NumberFormat);
                        break;
                    case 3:
                        min = double.Parse(array[i], CultureInfo.InvariantCulture.NumberFormat);
                        average = (max + min) / 2;
                        break;
                    default:
                        break;
                }
            }


            Console.WriteLine($"The max is {max}, the min is {min} and the average is {average}\n\n");


        }
    }

}
