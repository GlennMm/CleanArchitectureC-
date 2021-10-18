using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Product
{
    public class GetAllProductsQuery
    {
        public record Query() : IRequest<Response<IEnumerable<Core.Entities.Product>>>;
        
        public class Handler: IRequestHandler<Query, Response<IEnumerable<Core.Entities.Product>>>
        {
            public readonly IProductRepository Repo;
            
            public Handler(IProductRepository repo)
            {
                Repo = repo;
            }

            public async Task<Response<IEnumerable<Core.Entities.Product>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await Repo.GetAllAsync();
                return new Response<IEnumerable<Core.Entities.Product>>(product);
            }
        }
    }
}