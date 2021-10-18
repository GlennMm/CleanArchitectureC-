using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Invoice
{
    public class CreateInvoiceCommand
    {
        public record Command(Core.Entities.Invoice Invoice) : IRequest<Response<Core.Entities.Invoice>>;

        public class Handler : IRequestHandler<Command, Response<Core.Entities.Invoice>>
        {
            private readonly IInvoiceRepository _repository;

            public Handler(IInvoiceRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Invoice>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.AddAsync(request.Invoice);
                return new Response<Core.Entities.Invoice>(result);
            }
        }
    }
}