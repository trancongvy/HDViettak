using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Dynamic;
using System.Web;
using System.Net;
using System.Threading.Tasks; 
namespace ViettakInv
{
    public class SyncInv
    {
        string user; string pass; string url; string pattern; string serial;
        public SyncInv(string _user, string _pass, string _url, string _pattern, string _serial)
        {
            url = _url; user = _user; pass = _pass; pattern = _pattern; serial = _serial;
        }

        private string ConvertToWeb(IDictionary<string, string> dic)
        {
            string result = "";
            foreach (var param in dic)
            {
                if (result.Length > 0) { result += "&"; }
                result += param.Key + "=" + WebUtility.UrlEncode(param.Value);
            }
            return result;
        }
        private string SyncMethod(string Method, string Content)
        {
            string sResult = "";
            try
            {
                HttpClient client = new HttpClient();
                var stringContent = new StringContent(Content, Encoding.UTF8, "application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Referrer = new Uri(url + Method + ".jsp");
                var resp = client.PostAsync(url + Method + ".jsp", stringContent).Result;
                using (HttpContent content1 = resp.Content)
                {
                    Task<string> result = content1.ReadAsStringAsync();
                    sResult = result.Result;
                }
            }
            catch (Exception ex) { }
            return sResult;
        }
        public string AddInvoice(string sData)
        {
            string result = "";
            var formParams = new Dictionary<string, string>(){
                    { "xmlInvData", sData },
                    { "username",user },
                    { "pass", pass },
                    { "pattern", pattern},
                    { "serial", serial }
                };
            var webString = new Func<IDictionary<string, string>, string>(ConvertToWeb).Invoke(formParams);
            result = SyncMethod("ImportAndPublishInv", webString);
            return result;
        }
        public string EditInvoice(string sData, string sohoadon)
        {
            string result = "";
            var formParams = new Dictionary<string, string>(){
                    { "xmlInvData", sData },
                    { "username",user },
                    { "pass", pass },
                    { "pattern", pattern},
                    { "serial", serial },
                    {"invno",sohoadon}
                };
            var webString = new Func<IDictionary<string, string>, string>(ConvertToWeb).Invoke(formParams);
            result = SyncMethod("EditInvoiceAction", webString);
            return result;
        }
        public string DeleteInvoice(string sohoadon)
        {
            string result = "";
            var formParams = new Dictionary<string, string>(){
                    { "username",user },
                    { "pass", pass },
                    { "pattern", pattern},
                    { "serial", serial },
                    {"invno",sohoadon}
                };
            var webString = new Func<IDictionary<string, string>, string>(ConvertToWeb).Invoke(formParams);
            result = SyncMethod("CancelInvoiceAction", webString);
            return result;
        }
    }
}
