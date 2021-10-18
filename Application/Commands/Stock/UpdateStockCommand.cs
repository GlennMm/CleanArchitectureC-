using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Stock
{
    public class UpdateStockCommand
    {
        public record Command(Core.Entities.Stock Stock) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly IStockRepository _repository;

            public Handler(IStockRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.UpdateAsync(request.Stock);
                return Unit.Value;
            }
        }
    }
}