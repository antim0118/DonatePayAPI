namespace DonatePay.Structs
{
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
