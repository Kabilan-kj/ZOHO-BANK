using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Contract;
using ZBMS.Contract.DataManagerContracts;
using ZBMS.DataLayer;
using ZBMS.DomainLayer;

namespace ZBMS.GetDetailedTransactionsDomainLayer
{
    public class GetDetailedTransactionsUseCase : UseCaseBase
    {

        private ICallBack<GetDetailedTransactionsResponse> _presenterCallBack;
        private GetDetailedTransactionsRequest _request;
       // private IGetDetailedTransactionDataManager _dataManager;
       // private GetDetailedTransactionsUseCaseCallBack _useCaseCallBack;

        public GetDetailedTransactionsUseCase(GetDetailedTransactionsRequest request,ICallBack<GetDetailedTransactionsResponse> presenterCallBack)
        {
            _presenterCallBack = presenterCallBack;
            _request = request;

        }
        public override void Action()
        {
           var  dataManager = DependencyContainersClass.DependencyContainerObject.GetProvider().GetService(typeof(IGetDetailedTransactionDataManager)) as IGetDetailedTransactionDataManager;
           var useCaseCallBack = new GetDetailedTransactionsUseCaseCallBack(this);
           dataManager.GetDetailedTransaction(_request, useCaseCallBack);
        }

        private class GetDetailedTransactionsUseCaseCallBack : ICallBack<GetDetailedTransactionsResponse>
        {
           private GetDetailedTransactionsUseCase _usecase;
           public  GetDetailedTransactionsUseCaseCallBack(GetDetailedTransactionsUseCase usecase)
           {
                _usecase = usecase;
           }

           public  void OnError()
           {
                _usecase._presenterCallBack.OnError();
           }

            public void OnFailure()
            {
                _usecase._presenterCallBack.OnFailure();   
            }

            public  void OnSuccess(GetDetailedTransactionsResponse response)
            {
                _usecase._presenterCallBack.OnSuccess(response);  
            }
        }




    }
}
