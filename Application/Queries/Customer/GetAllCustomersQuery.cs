using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Customer
{
    public class GetAllCustomersQuery
    {
        public record Query() : IRequest<Response<IEnumerable<Core.Entities.Customer>>>;

        public class Handler : IRequestHandler<Query, Response<IEnumerable<Core.Entities.Customer>>>
        {
            public readonly ICustomerRepository Repo;

            public Handler(ICustomerRepository repo)
            {
                Repo = repo;
            }

            public async Task<Response<IEnumerable<Core.Entities.Customer>>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var results = await Repo.GetAllAsync();
                return new Response<IEnumerable<Core.Entities.Customer>>(results);
            }
        }
    }
}