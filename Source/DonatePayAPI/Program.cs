using System;
using static DonatePayAPI.DonatePayAPI;

namespace DonatePayAPI
{
    class Program
    {
        //using example
        //пример использования
        static void Main(string[] args)
        {
            DonatePayAPI dp = new DonatePayAPI("23vXl5IFqwmaYsfGKAiSPuj93OQTj5jPIgaT4sf47Hc6NQv2GwVmA2XbyKMR");

            Console.Write("Нажмите на цифру 1-3:\nClick on the number 1-3:\n\n1 - GetUser\n2 - GetTransactions\n3 - PostNotification\n\nNumber:");
            int ind = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (ind)
            {
                case 1:
                    Getus(dp);
                    break;
                case 2:
                    GetTrans(dp);
                    break;
                case 3:
                    PostNotif(dp);
                    break;
            }

        }

        public static void Getus(DonatePayAPI dp)
        {
            var user = dp.GetUser;
            string _ = $"ID:{user.data.id}\nname:{user.data.name}\navatar:{user.data.avatar}\nbalance:{user.data.balance}\ncashout_sum:{user.data.cashout_sum}";
            Console.WriteLine(_);
            Console.Read();
        }

        public static void GetTrans(DonatePayAPI dp)
        {
            var trans = dp.GetTransactions(/* !!!тут также есть параметры!!! */);
            string _ = $"status:{trans.status}\ntime:{trans.time.date}\nsum:{trans.sum}\n\ncount:{trans.count}\n\n";
            foreach (Transactionsdata data in trans.data)
            {
                _ += $"id:{data.id}\nfrom:{data.what}\nsum:{data.sum}\n{data.comment}\n\n";
            }
            Console.WriteLine(_);
            Console.Read();
        }

        public static void PostNotif(DonatePayAPI dp)
        {
            var not = dp.PostNotification("Name", 777, "Тестовый донат для DonatePayAPI");
            string _ = $"status:{not.status}\ndate:{not.time.date}\nmessage:{not.message}";
            Console.WriteLine(_);
            Console.Read();
        }

    }
}
