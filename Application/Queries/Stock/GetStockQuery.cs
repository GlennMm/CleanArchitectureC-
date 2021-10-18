using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Sale;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Stock
{
    public class GetStockQuery
    {
        public record Query(int Id) : IRequest<Response<Core.Entities.Stock>>;

        public class QueryHandler : IRequestHandler<Query, Response<Core.Entities.Stock>>
        {
            private readonly IStockRepository _repository;

            public QueryHandler(IStockRepository repository)
            {
                _repository = repository; 
            }
            
            public async Task<Response<Core.Entities.Stock>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _repository.GetByIdAsync(request.Id);
                return new Response<Core.Entities.Stock>(response);
            }
        }

    }
}