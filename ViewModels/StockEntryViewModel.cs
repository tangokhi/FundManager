using FundManager.Model;
using FundManager.Service;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace FundManager.ViewModels
{
    public class StockEntryViewModel : BindableBase, IDataErrorInfo
    {
        private readonly IFundManagerService _fundManagerService;
        
        private string _stockType;

        private string _price;

        private string _quantity;

        public StockEntryViewModel(IFundManagerService fundManagerService)
        {
            _fundManagerService = fundManagerService;
            StockTypes = new[] { typeof(EquityStock).Name, typeof(BondStock).Name };
            SaveStockCommand = new DelegateCommand(Save, CanSave);                 
        }

        public IEnumerable<string> StockTypes { get; private set; }

        public string StockType
        {
            get { return _stockType; }
            set
            {
                SetProperty(ref _stockType, value);
                SaveStockCommand.RaiseCanExecuteChanged();
            }
        }

        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                SetProperty(ref _price, value);                
                SaveStockCommand.RaiseCanExecuteChanged();
            }
        }

        public string Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                SetProperty(ref _quantity, value);
                
                SaveStockCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand SaveStockCommand { get; private set; }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        

        private void Save()
        {
            _fundManagerService.AddStock(StockType, decimal.Parse(Price), int.Parse(Quantity));
        }

        private bool CanSave()
        {
            string error = this[nameof(Price)];
            if (string.IsNullOrWhiteSpace(error))
            {
                error = this[nameof(Quantity)];
                if (string.IsNullOrWhiteSpace(error))
                {
                    error = this[nameof(StockType)];
                    return string.IsNullOrWhiteSpace(error);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;

            if (propertyName.Equals(nameof(Price)))
            {
                if (string.IsNullOrWhiteSpace(Price))
                {
                    validationMessage = "Price cannot be null or empty";
                }

                decimal priceValue;
                if (!decimal.TryParse(Price,out priceValue))
                {
                    validationMessage = "Price must be a decimal value";
                }
            }

            else if (propertyName.Equals(nameof(Quantity)))
            {
                if (string.IsNullOrWhiteSpace(Quantity))
                {
                    validationMessage = "Quantity cannot be null or empty";
                }

                int quantityValue;
                if (!int.TryParse(Quantity, out quantityValue))
                {
                    validationMessage = "Quantity must be an int value";
                }
            }

            else if (propertyName.Equals(nameof(StockType)))
            {
                if (string.IsNullOrWhiteSpace(StockType))
                {
                    validationMessage = "Quantity cannot be null or empty";
                }
            }

            return validationMessage;
        }
    }
}
