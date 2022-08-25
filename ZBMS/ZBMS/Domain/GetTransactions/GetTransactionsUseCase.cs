using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Contract;
using ZBMS.Contract.DataManagerContracts;
using ZBMS.DataLayer;
using ZBMS.PresentationLayer;

namespace ZBMS.DomainLayer
{
    public  class GetTransactionsUseCase : UseCaseBase
    {
       // private IGetTransactionsDataManager _dataManager; 
        private ICallBack<GetTransactionsResponse> _callBack;
        private GetTransactionsRequest _request;

        public GetTransactionsUseCase(ICallBack<GetTransactionsResponse> callBack,GetTransactionsRequest request)
        {
            _callBack = callBack;
            _request = request;
        }

        public override void Action()
        {
           var dataManager = DependencyContainersClass.DependencyContainerObject.GetProvider().GetService(typeof(IGetTransactionsDataManager)) as IGetTransactionsDataManager;
           var usecaseCallback = new GetTransactionsCallBack(this);
           dataManager.GetData(_request, usecaseCallback);
        }

        private class GetTransactionsCallBack : ICallBack<GetTransactionsResponse>
        {
            private GetTransactionsUseCase _useCase;
            public GetTransactionsCallBack(GetTransactionsUseCase useCase)
            {
                _useCase = useCase;
            }
            public void OnSuccess(GetTransactionsResponse response)
            {
                _useCase._callBack.OnSuccess(response);   
            }
            public void OnFailure()
            {
                _useCase._callBack.OnFailure();
            }

            public void OnError()
            {
               // throw new NotImplementedException();
            }
        }

    }
}
