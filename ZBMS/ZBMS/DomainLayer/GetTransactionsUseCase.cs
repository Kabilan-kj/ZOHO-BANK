using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.DataLayer;
using ZBMS.PresentationLayer;

namespace ZBMS.DomainLayer
{
    public  class GetTransactionsUseCase : UseCaseBase
    {
        public GetTransactionsDataManager dataManager; 
        private IPresenterCallBack callBack;
        private GetTransactionsRequest request;
        public GetTransactionsUseCase(IPresenterCallBack _callBack,GetTransactionsRequest _request)
        {
            callBack = _callBack;
            request = _request;
        }

        public override void Action()
        {
            dataManager = new GetTransactionsDataManager();
            dataManager.GetData(new GetTransactionsCallBack(this),request);
        }

        private class GetTransactionsCallBack : IUseCaseCallBack
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
        }

    }
}
