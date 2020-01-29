using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSampleConsume.Tools.Models;

namespace WebApiSampleConsume.Tools
{
   public class OpenLibraryRequester:Requester
    {
        public OpenLibraryRequester() : base("https://openlibrary.org/api")
        {

        }

        public bookModel GetInfos(string isbn)
        {
            string Endpoint = "/books?bibkeys=ISBN:" + isbn + "&jscmd=data";
            string json = base.Execute(Endpoint, "");
            if (json != "")
            {
                string CleanJson = json.Replace("var _OLBookInfo =", "").Replace(@"\", "");
                CleanJson = CleanJson.Remove(CleanJson.Length - 2);
                CleanJson = CleanJson.Replace("ISBN:","");
                CleanJson = CleanJson.Substring(CleanJson.IndexOf(":") +1);
                bookModel lc =   JsonConvert.DeserializeObject<bookModel>(CleanJson); //Using NewTonsoft nuget
                 

                return lc;
            }
            else
            {
                return null;
            }
        }
    }
}

