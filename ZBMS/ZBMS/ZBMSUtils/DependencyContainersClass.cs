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
        private ServiceProvider serviceProvider;
        private ServiceCollection serviceObjectsCollection;

        private DependencyContainersClass()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            serviceObjectsCollection = new ServiceCollection();

            serviceObjectsCollection.AddSingleton<IGetTransactionsDataManager,GetTransactionsDataManager>();
            serviceObjectsCollection.AddSingleton<IGetDetailedTransactionDataManager, GetDetailedTransactionDataManager>();
            serviceObjectsCollection.AddSingleton<IFilterTransactionsDataManager, FilterTransactionsDataManager>();
           

            serviceProvider=serviceObjectsCollection.BuildServiceProvider();
        }

        public ServiceProvider GetProvider()
        {
            return serviceProvider;
        }
    }
}
