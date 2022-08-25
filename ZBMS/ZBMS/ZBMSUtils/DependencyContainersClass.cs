using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Contract.DataManagerContracts;
using ZBMS.Contract.ViewModelBase;
using ZBMS.Data;
using ZBMS.DataLayer;
using ZBMS.FilterTransactionsUseCase.DataLayer;
using ZBMS.ViewModel;

namespace ZBMS.Contract
{
    public class DependencyContainersClass
    {
        public static DependencyContainersClass DependencyContainerObject = new DependencyContainersClass();
        private ServiceProvider _serviceProvider;
        private ServiceCollection _serviceObjectsCollection;

        private DependencyContainersClass()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            _serviceObjectsCollection = new ServiceCollection();

            _serviceObjectsCollection.AddSingleton<IGetTransactionsDataManager,GetTransactionsDataManager>();
            _serviceObjectsCollection.AddSingleton<IGetDetailedTransactionDataManager, GetDetailedTransactionDataManager>();
            _serviceObjectsCollection.AddSingleton<IFilterTransactionsDataManager, FilterTransactionsDataManager>();


            _serviceProvider = _serviceObjectsCollection.BuildServiceProvider();
        }

        public ServiceProvider GetProvider()
        {
            return _serviceProvider;
        }
    }
}
