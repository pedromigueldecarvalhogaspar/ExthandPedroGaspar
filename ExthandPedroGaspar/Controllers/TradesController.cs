using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExthandPedroGaspar.Data;
using ExthandPedroGaspar.Models;
using System.Net;
using System.IO;

namespace ExthandPedroGaspar.Controllers
{
    public class TradesController : Controller
    {
        private readonly ExthandPedroGasparContext _context;

        public TradesController(ExthandPedroGasparContext context)
        {
            _context = context;
        }

        // GET: Trades
        public IActionResult Get()
        {
            string Symbol = "tBTCUSD";
            string TimeFrame = "1h";
            string Section = "last";

            string stringUrl = String.Format($"https://api-pub.bitfinex.com/v2/candles/trade:{TimeFrame}:{Symbol}/{Section}");
            WebRequest requestObjGet = WebRequest.Create(stringUrl);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string stringResult = null; 
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                stringResult = sr.ReadToEnd();
            }

            return Ok();
        }
    }
}
