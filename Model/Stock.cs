namespace FundManager.Model
{
    public abstract class Stock
    {
        protected Stock(decimal price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public abstract string StockType { get; }

        public string Name { get; set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public decimal MarketValue
        {
            get
            {
                return Price * Quantity;
            }
        }

        public abstract decimal TransactionCost { get; }

        public abstract int Tolerance { get; }

        public decimal CalculateStockWeight(decimal fundMarketValue)
        {
            return (MarketValue * fundMarketValue) / 100;
        }
    }
}
