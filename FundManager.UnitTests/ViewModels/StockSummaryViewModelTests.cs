using FundManager.Model;
using FundManager.Service;
using FundManager.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FundManager.UnitTests.ViewModels
{
    [TestClass]
    public class StockSummaryViewModelTests
    {
        [TestMethod]
        public void Fund_WhenCalled_ReturnsTheFundObject()
        {
            var fund = new Fund();
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.GetFund()).Returns(fund);

            var stockSummaryViewModel = new StockSummaryViewModel(mockFundManagerService.Object);

            Assert.IsNotNull(stockSummaryViewModel.Fund);
        }
    }
}
