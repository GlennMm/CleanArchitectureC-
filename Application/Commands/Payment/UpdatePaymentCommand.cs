using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Payment
{
    public class UpdatePaymentCommand
    {
        public record Command(Core.Entities.Payment Payment) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly IPaymentRepository _repository;

            public Handler(IPaymentRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.UpdateAsync(request.Payment);
                return Unit.Value;
            }
        }
    }
}