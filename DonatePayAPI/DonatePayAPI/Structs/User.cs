namespace DonatePay.Structs
{
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
}
