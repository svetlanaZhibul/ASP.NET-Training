using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Broker broker = new Broker();

            Random rnd = new Random();
            int usd = rnd.Next(20, 40);
            int euro = rnd.Next(30, 50);
            StockInfo info = new StockInfo();

            bank.StartTrackingStockInfo(info);
            broker.StartTrackingStockInfo(info);

            info.StockInfoSender(usd, euro);

            broker.StopTrackingStockInfo(info);

            usd = 22;
            euro = 50;

            info.StockInfoSender(usd, euro);

            System.Console.ReadKey();
        }
        

        public void Market()
        {
            //Random rnd = new Random();
            //stocksInfo.USD = rnd.Next(20, 40);
            //stocksInfo.Euro = rnd.Next(30, 50);
            //Notify();
        }
    }
}
