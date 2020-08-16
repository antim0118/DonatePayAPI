namespace DonatePay.Structs
{
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
}
