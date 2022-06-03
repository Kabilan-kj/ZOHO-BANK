using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataModule;
using DataModule.AccountDetails;

namespace ZBMS
{
    public class CustomerLoginPage
    {
        private CustomerLoginPageDBHandler dbHandler = new CustomerLoginPageDBHandler();
        private CustomerData SelectedCustomer = new CustomerData();
        //private  static CancellationTokenSource  tokenSource = new CancellationTokenSource();
        //private  CancellationToken token = tokenSource.Token;

        public async Task<CustomerData> GetCustomerAsync(string id)
        {
            return await Task.Run(() => 
            {
                return dbHandler.GetCustomer(id);
            });
   
        }
        public CustomerData GetCustomer(string id)
        {
           return dbHandler.GetCustomer(id);
         
        }



        public  async Task<CustomerData> SignUp(CustomerData customer)
        {
            int Id = dbHandler.GetCustomerId();
            CustomerData NewCustomer = new CustomerData(customer.Name, customer.Address, customer.Contact, customer.MailId, Id);
            int rows = await Task.Run(() => { return dbHandler.AddCustomer(NewCustomer); }); 
            if (rows > 0)
            {
                return NewCustomer;
            } 

            return null;
        }

        public async Task<int> UpdateCustomerData(CustomerData customer)
        {
            return await Task.Run(async () =>
            {
                return dbHandler.UpdateCustomer(customer);
                
            });
        }


    }
}
