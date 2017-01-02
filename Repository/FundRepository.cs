using FundManager.Model;

namespace FundManager.Repository
{
    public class FundRepository : IFundRepository
    {
        Fund _fund = new Fund();

        public Fund GetFund()
        {
            return _fund;
        }
    }
}
