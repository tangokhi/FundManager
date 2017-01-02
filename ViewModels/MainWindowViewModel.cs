namespace FundManager.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(StockEntryViewModel stockEntryViewModel, StockCollectionViewModel stockCollectionViewModel, StockSummaryViewModel stockSummaryViewModel)
        {
            StockEntryVM = stockEntryViewModel;
            StockCollectionVM = stockCollectionViewModel;
            StockSummaryVM = stockSummaryViewModel;

        }

        public StockEntryViewModel StockEntryVM
        {
            get; set;
        }

       public StockCollectionViewModel StockCollectionVM { get; set; }

       public StockSummaryViewModel StockSummaryVM { get; set; }
    }
}
