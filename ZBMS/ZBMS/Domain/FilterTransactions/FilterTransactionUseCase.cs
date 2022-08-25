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
        private FilterTransactionsRequest _request;
        private ICallBack<FilterTransactionsResponse> _presenterCallBack;
       // private FilterTransactionsUseCaseCallBack _useCaseCallBack;
       // private IFilterTransactionsDataManager _dataManager;

        public FilterTransactionUseCase(FilterTransactionsRequest request, ICallBack<FilterTransactionsResponse> callBack)
        {
            _request = request;
            _presenterCallBack = callBack;
        }
        public override void Action()
        {
           var dataManager = DependencyContainersClass.DependencyContainerObject.GetProvider().GetService(typeof(IFilterTransactionsDataManager)) as IFilterTransactionsDataManager;
           var useCaseCallBack = new FilterTransactionsUseCaseCallBack(this);
           dataManager.GetData(_request, useCaseCallBack);
        }

        private class FilterTransactionsUseCaseCallBack : ICallBack<FilterTransactionsResponse>
        {
            private FilterTransactionUseCase _usecase;

            public FilterTransactionsUseCaseCallBack(FilterTransactionUseCase usecase)
            {
                _usecase = usecase;
            }

            public void OnError()
            {
                _usecase._presenterCallBack.OnError();
            }

            public void OnFailure()
            {
                _usecase._presenterCallBack.OnFailure();
            }

            public void OnSuccess(FilterTransactionsResponse response)
            {
                _usecase._presenterCallBack.OnSuccess(response);
            }
        }


    }
}
