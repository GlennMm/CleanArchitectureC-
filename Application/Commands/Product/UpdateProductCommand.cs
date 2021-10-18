using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Product
{
    public class UpdateProductCommand
    {
        public record Command(Core.Entities.Product Product) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly IProductRepository _repository;

            public Handler(IProductRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.UpdateAsync(request.Product);
                return Unit.Value;
            }
        }
    }
}