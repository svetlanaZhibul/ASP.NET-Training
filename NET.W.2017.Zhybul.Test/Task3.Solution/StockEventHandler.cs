using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public sealed class StockEventsArgs : EventArgs
    {
        public int USD { get; set; }
        public int Euro { get; set; }

        public StockEventsArgs() { }
        public StockEventsArgs(int usd, int euro)
        {
            USD = usd;
            Euro = euro;
        }

        //property
    }

    public class StockInfo
    {
        public event EventHandler<StockEventsArgs> NotifyStock;

        public void StockInfoSender(int usd, int euro)
        {
            OnNotifyStock(new StockEventsArgs(usd, euro));
        }

        protected virtual void OnNotifyStock(StockEventsArgs args)
        {
            NotifyStock?.Invoke(this, args);
        }
    }

    public class Broker
    {
        public Broker() { }

        public string Name { get; set; }

        public void StartTrackingStockInfo(StockInfo info)
        {
            info.NotifyStock += TrackStockInfo;
        }

        public void TrackStockInfo(object sender, StockEventsArgs stockInfo)
        {
            if (stockInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, stockInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, stockInfo.USD);

        }

        public void StopTrackingStockInfo(StockInfo info)
        {
            info.NotifyStock -= TrackStockInfo;
        }
    }

    public class Bank
    {
        public Bank() { }

        public string Name { get; set; }

        public void StartTrackingStockInfo(StockInfo info)
        {
            info.NotifyStock += TrackStockInfo;
        }

        public void TrackStockInfo(object sender, StockEventsArgs stockInfo)
        {
            if (stockInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, stockInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, stockInfo.Euro);

        }

        public void StopTrackingStockInfo(StockInfo info)
        {
            info.NotifyStock -= TrackStockInfo;
        }
    }
}
