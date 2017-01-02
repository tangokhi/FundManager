using System;
using System.Collections.Generic;
using System.Linq;

namespace FundManager.Model
{
    public class Fund
    {
        private readonly IList<Stock> _stocks = new List<Stock>();

        public void AddStock(string stockType, decimal price, int quantity)
        {
            Stock stock = Create(stockType, price, quantity);
            _stocks.Add(stock);

            EventHandler<DataEventArgs<Stock>> addStockEventHandler = this.AddStockEvent;

            if (addStockEventHandler != null)
            {
                var eventArgs = new DataEventArgs<Stock>(stock);

                addStockEventHandler(this, eventArgs);
            }
        }
        
        public event EventHandler<DataEventArgs<Stock>> AddStockEvent;

        public IList<Stock> Stocks
        {
            get
            {
                return _stocks;
            }
        }

        public int EquityStockCount
        {
            get
            {
                return _stocks.Count(s => s is EquityStock);
            }
        }

        public int BondStockCount
        {
            get
            {
                return _stocks.Count(s => s is BondStock);
            }
        }

        public decimal EquitiesTotalMarketValue
        {
            get
            {
                return _stocks.Where(s => s is EquityStock).Sum(s => s.MarketValue);
            }
        }

        public decimal BondsTotalMarketValue
        {
            get
            {
                return _stocks.Where(s => s is BondStock).Sum(s => s.MarketValue);
            }
        }

        public decimal TotalEquityStockWeight
        {
            get
            {
                return _stocks.Where(s => s is EquityStock).Sum(s => s.CalculateStockWeight(TotalMarketValue));
            }
        }

        public decimal TotalBondStockWeight
        {
            get
            {
                return _stocks.Where(s => s is BondStock).Sum(s => s.CalculateStockWeight(TotalMarketValue));
            }
        }

        public decimal TotalStockWeight
        {
            get
            {
                return _stocks.Sum(s => s.CalculateStockWeight(TotalMarketValue));
            }
        }

        public decimal TotalMarketValue
        {
            get
            {
                return _stocks.Sum(s => s.MarketValue);
            }
        }

        internal Stock Create(string stockType, decimal price, int quantity)
        {
            Stock stock;
            if (stockType.Equals(typeof(EquityStock).Name))
            {
                stock = new EquityStock(price, quantity);
                stock.Name = $"Equity{EquityStockCount + 1}";
            }
            else
            {
                stock = new BondStock(price, quantity);
                stock.Name = $"Bond{BondStockCount + 1}";
            }

            return stock;
        }
    }
}
