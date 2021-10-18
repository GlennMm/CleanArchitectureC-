using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Employee
{
    public class GetAllEmployeesQuery
    {
        public record Query() : IRequest<Response<IEnumerable<Core.Entities.Employee>>>;

        public class Handler : IRequestHandler<Query, Response<IEnumerable<Core.Entities.Employee>>>
        {
            public readonly IEmployeeRepository Repo;

            public Handler(IEmployeeRepository repo)
            {
                Repo = repo;
            }

            public async Task<Response<IEnumerable<Core.Entities.Employee>>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var results = await Repo.GetAllAsync();
                return new Response<IEnumerable<Core.Entities.Employee>>(results);
            }
        }
    }
}