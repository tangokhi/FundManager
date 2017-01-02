using FundManager.Model;
using FundManager.Service;

namespace FundManager.ViewModels
{
    public class StockSummaryViewModel
    {
        public StockSummaryViewModel(IFundManagerService fundManagerService)
        {
            Fund fund = fundManagerService.GetFund();

            Fund = new FundViewModel(fund);
        }

        public FundViewModel Fund
        {
            get; private set;
        }
    }
}
