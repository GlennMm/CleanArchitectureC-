using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Sale
{
    public class DeleteSaleCommand
    {
        public record Command(Core.Entities.Sale Sale) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly ISalesRepository _repository;

            public Handler(ISalesRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.DeleteAsync(request.Sale);
                return Unit.Value;
            }
        }
    }
}