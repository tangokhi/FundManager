using FundManager.Model;
using FundManager.Service;
using System.Collections.ObjectModel;
using System.Linq;

namespace FundManager.ViewModels
{
    public class StockCollectionViewModel
    {
        private readonly Fund _fund;

        private readonly ObservableCollection<StockViewModel> _stocks = new ObservableCollection<StockViewModel>();

        public StockCollectionViewModel(IFundManagerService fundManagerService)
        {
            _fund = fundManagerService.GetFund();

            _fund.Stocks.ToList().ForEach(s => _stocks.Add(new StockViewModel(s, _fund)));

            _fund.AddStockEvent += Fund_AddStockEvent;
        }

        private void Fund_AddStockEvent(object sender, DataEventArgs<Stock> e)
        {
            if (e != null && e.Data != null)
            {
                _stocks.Add(new StockViewModel(e.Data, _fund));
            }
        }

        public ObservableCollection<StockViewModel> Stocks
        {
            get
            {
                return _stocks;
            }
        }
    }
}
