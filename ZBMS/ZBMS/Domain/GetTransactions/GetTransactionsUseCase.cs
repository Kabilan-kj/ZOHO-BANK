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
        public IGetTransactionsDataManager dataManager; 
        private ICallBack<GetTransactionsResponse> callBack;
        private GetTransactionsRequest request;


        public GetTransactionsUseCase(ICallBack<GetTransactionsResponse> _callBack,GetTransactionsRequest _request)
        {
            callBack = _callBack;
            request = _request;
        }

        public override void Action()
        {
            dataManager = DependencyContainersClass.DependencyContainerObject.GetProvider().GetService(typeof(IGetTransactionsDataManager)) as IGetTransactionsDataManager;
            dataManager.GetData(new GetTransactionsCallBack(this),request);
        }



        private class GetTransactionsCallBack : ICallBack<GetTransactionsResponse>
        {
            GetTransactionsUseCase useCase;
            public GetTransactionsCallBack(GetTransactionsUseCase _useCase)
            {
                useCase = _useCase;
            }
            public void OnSuccess(GetTransactionsResponse response)
            {
                useCase.callBack.OnSuccess(response);   
            }
            public void OnFailure()
            {
                useCase.callBack.OnFailure();
            }

            public void OnError()
            {
                throw new NotImplementedException();
            }
        }

    }
}
