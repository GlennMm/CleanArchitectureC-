using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using MediatR;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Repositories;

namespace Application.Queries.Sale
{
    public static class GetSaleQuery
    {
        public record Query(int Id) : IRequest<Response<Core.Entities.Sale>>;
        
        public class Handler: IRequestHandler<Query, Response<Core.Entities.Sale>>
        {

            private readonly ISalesRepository _repo;

            public Handler(ISalesRepository repo)
            {
                _repo = repo;
            }
            
            public async Task<Response<Core.Entities.Sale>> Handle(Query request, CancellationToken cancellationToken)
            {
                var sale = await _repo.GetByIdAsync(request.Id);
                return sale == null ? null : new Response<Core.Entities.Sale>(sale);
            }
        }

    }
}