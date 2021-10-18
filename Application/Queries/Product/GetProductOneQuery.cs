using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Product
{
    public class GetProductOneQuery
    {
        public record Query(int Id) : IRequest<Response<Core.Entities.Product>>;
        
        public class Handler: IRequestHandler<Query, Response<Core.Entities.Product>>
        {
            public readonly IProductRepository Repo;
            
            public Handler(IProductRepository repo)
            {
                Repo = repo;
            }

            public async Task<Response<Core.Entities.Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await Repo.GetByIdAsync(request.Id);
                return new Response<Core.Entities.Product>(product);
            }
        }
        
    }
}