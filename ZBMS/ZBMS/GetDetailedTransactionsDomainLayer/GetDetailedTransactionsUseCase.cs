using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DataLayer;
using ZBMS.DomainLayer;

namespace ZBMS.GetDetailedTransactionsDomainLayer
{
    public class GetDetailedTransactionsUseCase : UseCaseBase
    {

        private ICallBack<GetDetailedTransactionsResponse> presenterCallBack;
        private GetDetailedTransactionsRequest request;
        private GetTransactionsDataManager dataManager;
        private GetDetailedTransactionsUseCaseCallBack useCaseCallBack;

        public GetDetailedTransactionsUseCase(GetDetailedTransactionsRequest _request,ICallBack<GetDetailedTransactionsResponse> _presenterCallBack)
        {
            presenterCallBack = _presenterCallBack;
            request = _request;

        }
        public override void Action()
        {
            dataManager = new GetTransactionsDataManager();
            useCaseCallBack= new GetDetailedTransactionsUseCaseCallBack(this);
            dataManager.GetDetailedTransaction(request, useCaseCallBack);
        }

        private class GetDetailedTransactionsUseCaseCallBack : ICallBack<GetDetailedTransactionsResponse>
        {
            GetDetailedTransactionsUseCase usecase;
           public  GetDetailedTransactionsUseCaseCallBack(GetDetailedTransactionsUseCase _usecase)
           {
                usecase = _usecase;
           }

           public  void OnError()
           {
                usecase.presenterCallBack.OnError();
           }

            public void OnFailure()
            {
               usecase.presenterCallBack.OnFailure();   
            }

            public  void OnSuccess(GetDetailedTransactionsResponse response)
            {
                usecase.presenterCallBack.OnSuccess(response);  
            }
        }




    }
}
