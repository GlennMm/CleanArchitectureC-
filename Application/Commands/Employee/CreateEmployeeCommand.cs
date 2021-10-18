using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Employee
{
    public class CreateEmployeeCommand
    {
        public record Command(Core.Entities.Employee Employee) : IRequest<Response<Core.Entities.Employee>>;

        public class Handler : IRequestHandler<Command, Response<Core.Entities.Employee>>
        {
            private readonly IEmployeeRepository _repository;

            public Handler(IEmployeeRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Employee>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.AddAsync(request.Employee);
                return new Response<Core.Entities.Employee>(result);
            }
        }
    }
}