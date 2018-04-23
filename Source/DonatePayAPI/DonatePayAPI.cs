using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace DonatePayAPI
{
    class DonatePayAPI
    {
        #region make get запрос
        private static string GetResponse(string url)
        {
            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }

        private static string PostRequest(string url, string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            var data = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;


            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        private static string Split(string str, string delimiter)
        {
            string _ = str.Split(new string[] { "\"" + delimiter + "\":\"" }, StringSplitOptions.None)[1].Split('"')[0];
            return _;
        }
        private static int Spliti(string str, string delim)
        {
            int _ = Convert.ToInt32(str.Split(new string[] { "\"" + delim + "\":" }, StringSplitOptions.None)[1].Split(',')[0]);
            return _;
        }
        #endregion
        private string apikey;
        public DonatePayAPI(string API_key)
        {
            apikey = API_key;
        }

        #region GetUser
        public User GetUser
        {
            get
            {
                string url = "http://donatepay.ru/api/v1/user";
                string resp = GetResponse(url + "?access_token=" + apikey);

                User u = JsonConvert.DeserializeObject<User>(resp);

                return u;
            }
        }

        public struct User
        {
            public string status { get; set; }
            public time time { get; set; }
            public Userdata data { get; set; }
        }

        

        public struct Userdata
        {
            public int id { get; set; }
            public string name { get; set; }
            public string avatar { get; set; }
            public string balance { get; set; }
            public string cashout_sum { get; set; }
        }
        #endregion
        #region GetTransactions
        public Transactions GetTransactions(int limit = 25, int before = 0, int after = 0, int skip = 0, string order = "DESC", string type = "all", string status = "all")
        {
            string url = "http://donatepay.ru/api/v1/transactions";
            string parameters = "";
            #region params
            if (limit != 25)
                parameters += "&limit=" + limit;
            if (before != 0)
                parameters += "&before=" + before;
            if (after != 0)
                parameters += "&after=" + after;
            if (skip != 0)
                parameters += "&skip=" + skip;
            if (order != "DESC")
                parameters += "&order=" + order;
            if (type != "all")
                parameters += "&type=" + type;
            if (status != "all")
                parameters += "&status=" + status;
            #endregion
            string resp = GetResponse(url + "?access_token=" + apikey + parameters);

            Transactions u = JsonConvert.DeserializeObject<Transactions>(resp);

            return u;
        }

        public struct Transactions
        {
            public string status { get; set; }
            public time time { get; set; }
            public string sum { get; set; }
            public int count { get; set; }
            public Transactionsdata[] data { get; set; }
        }

        public struct Transactionsdata
        {
            public int id { get; set; }
            public string what { get; set; }
            public string sum { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public vars vars { get; set; }
            public string comment { get; set; }
            public time created_at { get; set; }
        }

        public struct vars
        {
            public string name { get; set; }
            public string comment { get; set; }
        }
        #endregion
        #region PostNotification
        public Notification PostNotification(string name, int sum, string comment, int notification = 1)
        {
            string url = "http://donatepay.ru/api/v1/notification";
            string parameters = $"&name={name}&sum={sum}&comment={comment}";
            #region params
            if (notification != 1)
                parameters += "&notification=" + notification;
            #endregion
            string resp = PostRequest(url, "access_token=" + apikey + parameters);

            Notification u = JsonConvert.DeserializeObject<Notification>(resp);

            return u;
        }

        public struct Notification
        {
            public string status { get; set; }
            public time time { get; set; }
            public string message { get; set; }
        }
        #endregion

        public struct time
        {
            public string date { get; set; }
            public int timezone_type { get; set; }
            public string timezone { get; set; }
        }

    }
}
