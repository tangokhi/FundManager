using FundManager.Repository;
using FundManager.Service;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FundManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static IUnityContainer _container = new UnityContainer();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container.RegisterType<IFundManagerService, FundManagerService>();
            _container.RegisterType<IFundRepository, FundRepository>(new ContainerControlledLifetimeManager());

            ViewModelLocationProvider.SetDefaultViewModelFactory((type) =>
            {
                return _container.Resolve(type);
            });
        }
    }
}
