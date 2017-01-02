using FundManager.Model;
using Microsoft.Practices.Prism.Mvvm;
using System.ComponentModel;

namespace FundManager.ViewModels
{
    public class FundViewModel : BindableBase
    {
        private readonly Fund _fund;

        public FundViewModel(Fund fund)
        {
            _fund = fund;
            _fund.AddStockEvent += (s, e) =>
            {
                OnPropertyChanged("EquityTotalNumber");
                OnPropertyChanged("EquityTotalMarketValue");
                OnPropertyChanged("EquityTotalStockWeight");
                OnPropertyChanged("BondTotalNumber");
                OnPropertyChanged("BondTotalMarketValue");
                OnPropertyChanged("BondTotalStockWeight");
                OnPropertyChanged("StockTotalNumber");
                OnPropertyChanged("StockTotalMarketValue");
                OnPropertyChanged("StockTotalStockWeight");
            };
        }
        
        public int EquityTotalNumber
        {
            get
            {
                return _fund.EquityStockCount;
            }
        }

        public decimal EquityTotalStockWeight
        {
            get
            {
                return _fund.TotalEquityStockWeight;
            }
        }

        public decimal EquityTotalMarketValue
        {
            get
            {
                return _fund.EquitiesTotalMarketValue;
            }
        }

        public int BondTotalNumber
        {
            get
            {
                return _fund.BondStockCount;
            }
        }

        public decimal BondTotalStockWeight
        {
            get
            {
                return _fund.TotalBondStockWeight;
            }
        }

        public decimal BondTotalMarketValue
        {
            get
            {
                return _fund.BondsTotalMarketValue;
            }
        }

        public int StockTotalNumber
        {
            get
            {
                return _fund.Stocks.Count;
            }
        }

        public decimal StockTotalStockWeight
        {
            get
            {
                return _fund.TotalStockWeight;
            }
        }

        public decimal StockTotalMarketValue
        {
            get
            {
                return _fund.TotalMarketValue;
            }
        }
    }
}
