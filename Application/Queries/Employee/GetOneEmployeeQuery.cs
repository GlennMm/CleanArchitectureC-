using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Employee
{
    public class GetOneEmployeeQuery
    {
        public record Query(int Id) : IRequest<Response<Core.Entities.Employee>>;

        public class Handler : IRequestHandler<Query, Response<Core.Entities.Employee>>
        {
            private readonly IEmployeeRepository _repository;

            public Handler(IEmployeeRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Employee>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await _repository.GetByIdAsync(request.Id);
                return new Response<Core.Entities.Employee>(results);
            }
        }
    }
}