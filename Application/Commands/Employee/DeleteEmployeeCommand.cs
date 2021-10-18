using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Employee
{
    public class DeleteEmployeeCommand
    {
        public record Command(Core.Entities.Employee Employee) : IRequest;
        
        public class Handler: IRequestHandler<Command>
        {
            private readonly IEmployeeRepository _repository;

            public Handler(IEmployeeRepository repository)
            {
                _repository = repository;
            }
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.DeleteAsync(request.Employee);
                return Unit.Value;
            }
        }
    }
}