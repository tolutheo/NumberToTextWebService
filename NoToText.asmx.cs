using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NumberToWordsWebService
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
      /*  [WebMethod]
        public string kobval(decimal d)
        {
            d = d % 1;
            return d.ToString();
        }
     */
        [WebMethod]
        public string NumberToText(decimal number)
        {
            string result = null;

            if (number == 0)
            {
                result = "Zero";
            }
            else
            {
                var naira = NumberToText((long)number)+" naira";
                var kobo = KoboValue(number) + " kobo";
                result = naira + " and " + kobo;
                return result;
            }

            return result + " naira";
        }

        public string KoboValue(decimal d)
        {
            d = d % 1;
            d = d * 100;
            string f;
            if (d == 0)
            {
                f = "zero";
            }
            else
            {
                f = NumberToText((long)d);
            }
            return f;
        }
        public string NumberToText(long n)
        {
            if (n < 0)
                return "Minus " + NumberToText(-n);
            else if (n == 0)
                return "";
            else if (n <= 19)
                return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
                                "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                                "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
            else if (n <= 99)
                return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
                                "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
            else if (n <= 199)
                return "One Hundred " + NumberToText(n % 100);
            else if (n <= 999)
                return NumberToText(n / 100) + "Hundred " + NumberToText(n % 100);
            else if (n <= 1999)
                return "One Thousand " + NumberToText(n % 1000);
            else if (n <= 999999)
                return NumberToText(n / 1000) + "Thousand " + NumberToText(n % 1000);
            else if (n <= 1999999)
                return "One Million " + NumberToText(n % 1000000);
            else if (n <= 999999999)
                return NumberToText(n / 1000000) + "Million " + NumberToText(n % 1000000);
            else if (n <= 1999999999)
                return "One Billion " + NumberToText(n % 1000000000);
            else
                return NumberToText(n / 1000000000) + "Billion " + NumberToText(n % 1000000000);
        }
    }
}
