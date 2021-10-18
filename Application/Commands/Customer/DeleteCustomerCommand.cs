using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Customer
{
    public class DeleteCustomerCommand
    {
        public record Command(Core.Entities.Customer Customer) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly ICustomerRepository _repository;

            public Handler(ICustomerRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.DeleteAsync(request.Customer);
                return Unit.Value;
            }
        }
    }
}