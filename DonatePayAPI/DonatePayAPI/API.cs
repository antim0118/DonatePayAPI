using Newtonsoft.Json;
using System;

namespace DonatePay
{
    public class API
    {
        public const string API_URL = "https://donatepay.ru/api/v1";
        public string API_KEY;
        public API(string YOUR_API_KEY) => API_KEY = YOUR_API_KEY;

        #region Методы
        public Structs.User User
        {
            get
            {
                string request = Request.GET(API_URL + "/user?access_token=" + API_KEY);
                return JsonConvert.DeserializeObject<Structs.User>(request);
            }
        }
        public Structs.Transactions Transactions(int limit = 25, int before = 0, int after = 0, int skip = 0, Enums.Order order = Enums.Order.DESC, Enums.Type type = Enums.Type.Unknown, Enums.Status status = Enums.Status.Unknown)
        {
            string options = string.Empty;
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
            else if (order == Enums.Order.DESC)
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
            else if (status == Enums.Status.Cancel)
                options += "&status=cancel";
            else if (status == Enums.Status.Wait)
                options += "&status=wait";
            else if (status == Enums.Status.User)
                options += "&status=user";
            #endregion
            string request = Request.GET(API_URL + "/transactions?access_token=" + API_KEY + options);
            return JsonConvert.DeserializeObject<Structs.Transactions>(request);
        }
        public Structs.Notification Notification(string name, string sum, string comment, DateTime date, bool notification = true)
        {
            string options = "&name=" + name +
                            "&sum=" + sum +
                            "&comment=" + comment +
                            "&date=" + date.ToString("yyyy-MM-dd ") + date.ToString("T") + ".888888" +
                            "&notification=" + (notification ? "1" : "-1");
            string request = Request.POST(API_URL + "/notification?access_token=" + API_KEY + options, string.Empty, string.Empty);
            return JsonConvert.DeserializeObject<Structs.Notification>(request);
        }
        #endregion
    }
}
