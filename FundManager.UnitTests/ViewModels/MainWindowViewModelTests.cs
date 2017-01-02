using FundManager.Model;
using FundManager.Service;
using FundManager.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.UnitTests.ViewModels
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private StockEntryViewModel _stockEntryViewModel;

        private StockCollectionViewModel _stockCollectionViewModel;

        private StockSummaryViewModel _stockSummaryViewModel;


        [TestMethod]
        public void StockEntryVM_WhenCalled_ReturnsStockEntryViewModel()
        {
            var mainWindowVm = CreateViewModel();

            Assert.AreSame(_stockEntryViewModel, mainWindowVm.StockEntryVM);
        }

        [TestMethod]
        public void StockCollectionVM_WhenCalled_ReturnsStockCollectionViewModel()
        {
            var mainWindowVm = CreateViewModel();

            Assert.AreSame(_stockCollectionViewModel, mainWindowVm.StockCollectionVM);
        }

        [TestMethod]
        public void StockSummaryVm_WhenCalled_ReturnsStockSummaryViewModel()
        {
            var mainWindowVm = CreateViewModel();

            Assert.AreSame(_stockSummaryViewModel, mainWindowVm.StockSummaryVM);
        }

        private MainWindowViewModel CreateViewModel()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.GetFund()).Returns(new Fund());
            _stockEntryViewModel = new StockEntryViewModel(mockFundManagerService.Object);
            _stockCollectionViewModel = new StockCollectionViewModel(mockFundManagerService.Object);
            _stockSummaryViewModel = new StockSummaryViewModel(mockFundManagerService.Object);
            return new MainWindowViewModel(_stockEntryViewModel, _stockCollectionViewModel, _stockSummaryViewModel);
        }
    }
}
