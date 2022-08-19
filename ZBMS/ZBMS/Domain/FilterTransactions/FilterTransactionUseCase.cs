using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBMS.Contract;
using ZBMS.DomainLayer;
using ZBMS.FilterTransactionsUseCase.DataLayer;

namespace ZBMS.FilterTransactionsUseCase.DomainLayer
{
    public class FilterTransactionUseCase : UseCaseBase
    {
        private FilterTransactionsRequest request;
        private ICallBack<FilterTransactionsResponse> presenterCallBack;
        private FilterTransactionsUseCaseCallBack useCaseCallBack;
        private IFilterTransactionsDataManager dataManager;

        public FilterTransactionUseCase(FilterTransactionsRequest _request, ICallBack<FilterTransactionsResponse> _callBack)
        {
            request = _request;
            presenterCallBack = _callBack;
        }
        public override void Action()
        {
            dataManager = DependencyContainersClass.DependencyContainerObject.GetProvider().GetService(typeof(IFilterTransactionsDataManager)) as IFilterTransactionsDataManager;
            useCaseCallBack = new FilterTransactionsUseCaseCallBack(this);
            dataManager.GetData(request, useCaseCallBack);
        }

        private class FilterTransactionsUseCaseCallBack : ICallBack<FilterTransactionsResponse>
        {
            FilterTransactionUseCase usecase;

            public FilterTransactionsUseCaseCallBack(FilterTransactionUseCase _usecase)
            {
                usecase = _usecase;
            }

            public void OnError()
            {
                usecase.presenterCallBack.OnError();
            }

            public void OnFailure()
            {
                usecase.presenterCallBack.OnFailure();
            }

            public void OnSuccess(FilterTransactionsResponse response)
            {
                usecase.presenterCallBack.OnSuccess(response);
            }
        }


    }
}
