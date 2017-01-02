using FundManager.Model;
using FundManager.Repository;

namespace FundManager.Service
{
    public class FundManagerService : IFundManagerService
    {
        private readonly IFundRepository _fundRepository;

        public FundManagerService(IFundRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public void AddStock(string type, decimal price, int quantity)
        {
            Fund fund = _fundRepository.GetFund();

            fund.AddStock(type, price, quantity);
        }

        public Fund GetFund()
        {
            return _fundRepository.GetFund();
        }
    }
}
