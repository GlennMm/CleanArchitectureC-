using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Stock
{
    public class CreateStockCommand
    {
        public record Command(Core.Entities.Stock Stock) : IRequest<Response<Core.Entities.Stock>>;

        public class Handler : IRequestHandler<Command, Response<Core.Entities.Stock>>
        {
            private readonly IStockRepository _repository;

            public Handler(IStockRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Stock>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.AddAsync(request.Stock);
                return new Response<Core.Entities.Stock>(result);
            }
        }
    }
}