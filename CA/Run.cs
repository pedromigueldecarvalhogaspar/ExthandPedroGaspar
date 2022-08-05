using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace CA
{
    class Run
    {
        public static void MinMax()
        {

            string stringUrl = "https://api-pub.bitfinex.com/v2/trades/tBTCEUR/hist?limit=1000";

            using (var client = new HttpClient())
            {
                var endpoint = new Uri(stringUrl);
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<dynamic>(json);

                int timeCount = 0;
                int maxPrice = 0;
                int minPrice = 0;
                
                for (int i = 0; i < obj.Count; i++)
                {
                    
                    
                    int search = obj[i][3];
                    const int hour = 3600000;

                    timeCount = obj[0][1] - obj[i][1];
                    maxPrice = obj[0][3];
                    minPrice = obj[0][3];

                    if (search > maxPrice)
                    {
                        maxPrice = search;
                    }

                    if (search < minPrice)
                    {
                        minPrice = search;
                    }

                    if (timeCount > hour)
                    {
                        Console.WriteLine($"In the last {timeCount} miliseconds:\nMin value:{minPrice};\nMax value:{maxPrice};\nAverage value:{(maxPrice + minPrice) / 2}");
                        return;
                    }
                }
            }
        }
    }
}


