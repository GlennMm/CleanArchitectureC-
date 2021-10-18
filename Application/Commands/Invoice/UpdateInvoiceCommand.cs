using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Invoice
{
    public class UpdateInvoiceCommand
    {
        public record Command(Core.Entities.Invoice Invoice) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly IInvoiceRepository _repository;

            public Handler(IInvoiceRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.UpdateAsync(request.Invoice);
                return Unit.Value;
            }
        }
    }
}