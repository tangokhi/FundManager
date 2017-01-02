using System;

namespace FundManager.Model
{
    public class BondStock : Stock
    {
        public BondStock(decimal price, int quantity) : base(price, quantity)
        {
        }

        public override string StockType
        {
            get
            {
                return "Bond";
            }
        }

        public override int Tolerance
        {
            get
            {
                return 100000;
            }
        }

        public override decimal TransactionCost
        {
            get
            {
                return MarketValue * (2m / 100);
            }
        }
    }
}
