using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System;

namespace YksProject.Web_UI.Controllers
{
    public class SmsMailController : Controller
    {
        public ActionResult Sms()
        {

            string merchant_id = "AAAAAA";
            string merchant_key = "XXXXXXXXXXXXXXXX";
            string merchant_salt = "XXXXXXXXXXXXXXXX";

            string id = "XXXYYY";
            string cell_phone = "05347369103";
            string debug_on = "1";

            string Birlestir = string.Concat(id, merchant_id, cell_phone, merchant_salt);
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(merchant_key));
            byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(Birlestir));
            string paytr_token = Convert.ToBase64String(b);

            NameValueCollection data = new NameValueCollection();
            data["merchant_id"] = merchant_id;
            data["id"] = id;
            data["cell_phone"] = cell_phone;
            data["debug_on"] = debug_on;
            data["paytr_token"] = paytr_token;
            //

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] result = client.UploadValues("https://www.paytr.com/odeme/api/link/send-sms", "POST", data);
                string ResultAuthTicket = Encoding.UTF8.GetString(result);
                dynamic json = JValue.Parse(ResultAuthTicket);
                
            }
            return View();
        }
    }
}
