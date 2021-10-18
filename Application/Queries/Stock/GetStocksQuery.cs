using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Stock
{
    public class GetAllStocksQuery
    {
        public record Query() : IRequest<Response<IEnumerable<Core.Entities.Stock>>>;
        
        public class Handler: IRequestHandler<Query, Response<IEnumerable<Core.Entities.Stock>>>
        {

            private readonly IStockRepository _repository;

            public Handler(IStockRepository repository)
            {
                _repository = repository; 
            }
            
            public async Task<Response<IEnumerable<Core.Entities.Stock>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await _repository.GetAllAsync();
                return new Response<IEnumerable<Core.Entities.Stock>>(results);
            }
        }
    }
}