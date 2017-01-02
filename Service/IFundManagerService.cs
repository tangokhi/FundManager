using FundManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Service
{
    public interface IFundManagerService
    {
        void AddStock(string type, decimal price, int quantity);

        Fund GetFund();
    }
}
