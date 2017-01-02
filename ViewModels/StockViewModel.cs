using FundManager.Model;
using Microsoft.Practices.Prism.Mvvm;

namespace FundManager.ViewModels
{
    public class StockViewModel : BindableBase
    {
        private readonly Stock _stock;

        private readonly Fund _parentFund;
        
        public StockViewModel(Stock stock, Fund parentFund)
        {
            _stock = stock;
            _parentFund = parentFund;
            _parentFund.AddStockEvent += (sender, dataEventArgs) => OnPropertyChanged("StockWeight");
        }

        public string StockType
        {
            get
            {
                return _stock.StockType;
            }
        }
        
        public string Name
        {
            get { return _stock.Name; }
        }

        public decimal Price
        {
            get
            {
                return _stock.Price;
            }
        }

        public int Quantity
        {
            get
            {
                return _stock.Quantity;
            }
        }

        public decimal MarketValue
        {
            get
            {
                return _stock.MarketValue;
            }
        }

        public decimal StockWeight
        {
            get
            {
                return _stock.CalculateStockWeight(_parentFund.TotalMarketValue);
            }
        }

        public decimal TransactionCost
        {
            get
            {
                return _stock.TransactionCost;
            }
        }

        public bool Highlight
        {
            get
            {
                var result = _stock.MarketValue < 0 || _stock.TransactionCost > _stock.Tolerance;
                return result;
            }
        }
    }
}
