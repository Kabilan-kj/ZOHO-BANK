using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            serviceProvider=serviceObjectsCollection.BuildServiceProvider();
        }

        public ServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
}
