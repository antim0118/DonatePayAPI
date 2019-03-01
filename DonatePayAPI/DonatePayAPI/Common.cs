using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonatePay
{
    public class API
    {
        public string APIKey;
        public API(string YOUR_API_KEY)
        {
            APIKey = YOUR_API_KEY;
        }
        public Structs.User User
        {
            get
            {
                string request = Request.GET("https://donatepay.ru/api/v1/user?access_token=" + APIKey);
                return JsonConvert.DeserializeObject<Structs.User>(request);
            }
        }
        public Structs.Transactions Transactions(int limit = 25, int before = 0, int after = 0, int skip = 0, Enums.Order order = Enums.Order.DESC, Enums.Type type = Enums.Type.Unknown, Enums.Status status = Enums.Status.Unknown)
        {
            string options = "";
            options += "&limit=" + limit;
            if (before != 0)
                options += "&before=" + before;
            if (after != 0)
                options += "&after=" + after;
            if (skip != 0)
                options += "&skip=" + skip;
            #region order
            if (order == Enums.Order.ASC)
                options += "&order=ASC";
            if (order == Enums.Order.DESC)
                options += "&order=DESC";
            #endregion
            #region type
            if (type == Enums.Type.Cashout)
                options += "&type=cashout";
            if (type == Enums.Type.Donation)
                options += "&type=donation";
            #endregion
            #region status
            if (status == Enums.Status.Success)
                options += "&status=success";
            if (status == Enums.Status.Cancel)
                options += "&status=cancel";
            if (status == Enums.Status.Wait)
                options += "&status=wait";
            if (status == Enums.Status.User)
                options += "&status=user";
            #endregion
            string request = Request.GET("https://donatepay.ru/api/v1/transactions?access_token=" + APIKey + options);
            return JsonConvert.DeserializeObject<Structs.Transactions>(request);
        }
        public Structs.Notification Notification(string name, string sum, string comment, DateTime date, bool notification = true)
        {
            string options = "";
            options += "&name=" + name;
            options += "&sum=" + sum;
            options += "&comment=" + comment;
            options += "&date=" + date.ToString("yyyy-MM-dd ") + date.ToString("T") + ".888888";
            options += "&notification=" + (notification ? "1" : "-1");
            string request = Request.POST("https://donatepay.ru/api/v1/notification?access_token=" + APIKey + options, string.Empty, string.Empty);
            return JsonConvert.DeserializeObject<Structs.Notification>(request);
        }
    }

    public class Structs
    {
        public class Time
        {
            public string date { get; set; }
            public int timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class User
        {
            public Enums.Status Status
            {
                get
                {
                    if (status == "success")
                        return Enums.Status.Success;
                    else if (status == "error")
                        return Enums.Status.Error;
                    else
                        return Enums.Status.Unknown;
                }
            }
            public string status { get; set; }
            public string message { get; set; }
            public Time time { get; set; }
            public Data data { get; set; }

            public class Data
            {
                public int id { get; set; }
                public string name { get; set; }
                public string avatar { get; set; }
                public int balance { get; set; }
                public int cashout_sum { get; set; }
            }
        }
        public class Transactions
        {
            public Enums.Status Status
            {
                get
                {
                    if (status == "success")
                        return Enums.Status.Success;
                    else if (status == "error")
                        return Enums.Status.Error;
                    else
                        return Enums.Status.Unknown;
                }
            }
            public string status { get; set; }
            public string message { get; set; }
            public Time time { get; set; }
            public string sum { get; set; }
            public int count { get; set; }
            public Data[] data { get; set; }

            public class Data
            {
                public Enums.Type Type
                {
                    get
                    {
                        if (type == "donation")
                            return Enums.Type.Donation;
                        else if (type == "cashout")
                            return Enums.Type.Cashout;
                        else return Enums.Type.Unknown;
                    }
                }

                public int id { get; set; }
                public string what { get; set; }
                public string sum { get; set; }
                public string commission { get; set; }
                public string status { get; set; }
                public string type { get; set; }
                public Vars vars { get; set; }
                public string comment { get; set; }
                public Time created_at { get; set; }

                //public ? to_cash { get; set; }
                //public ? to_pay { get; set; }

                public class Vars
                {
                    public string name { get; set; }
                    public string comment { get; set; }
                    //public ? user_ip { get; set; }
                }
            }
        }
        public class Notification
        {
            public Enums.Status Status
            {
                get
                {
                    if (status == "success")
                        return Enums.Status.Success;
                    else if (status == "error")
                        return Enums.Status.Error;
                    else
                        return Enums.Status.Unknown;
                }
            }
            public string status { get; set; }
            public string message { get; set; }
            public Time time { get; set; }
        }
    }

    public class Enums
    {
        public enum Status
        {
            Success, Error, Unknown, Cancel, Wait, User
        }

        public enum Order
        {
            ASC, DESC
        }

        public enum Type
        {
            Donation, Cashout, Unknown
        }
    }
}
