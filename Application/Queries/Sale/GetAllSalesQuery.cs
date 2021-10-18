using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Sale
{
    public static class GetAllSalesQuery
    {
        public record GetAllSales() : IRequest<Response<IEnumerable<Core.Entities.Sale>>>;

        public class Handler : IRequestHandler<GetAllSales, Response<IEnumerable<Core.Entities.Sale>>>
        {

            private readonly ISalesRepository _repository;

            public Handler(ISalesRepository repository)
            {
                _repository = repository;
            }
            
            public async Task<Response<IEnumerable<Core.Entities.Sale>>> Handle(GetAllSales request, CancellationToken cancellationToken)
            {
                var results =  await _repository.GetAllAsync();
                return new Response<IEnumerable<Core.Entities.Sale>>(results);
            }
        }

    }
}