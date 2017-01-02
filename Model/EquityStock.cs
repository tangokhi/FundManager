using System;

namespace FundManager.Model
{
    public class EquityStock : Stock
    {
        public EquityStock(decimal price, int quantity) : base(price, quantity)
        {
        }

        public override string StockType
        {
            get
            {
                return "Equity";
            }
        }

        public override int Tolerance
        {
            get
            {
                return 200000;
            }
        }

        public override decimal TransactionCost
        {
            get
            {
                return MarketValue * (0.5m / 100);
            }
        }
    }
}
