using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Sale
{
    public class CreateSaleCommand
    {
        public record Command(Core.Entities.Sale Sale) : IRequest<Response<Core.Entities.Sale>>;

        public class Handler : IRequestHandler<Command, Response<Core.Entities.Sale>>
        {
            private readonly ISalesRepository _repository;

            public Handler(ISalesRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Sale>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.AddAsync(request.Sale);
                return new Response<Core.Entities.Sale>(result);
            }
        }
    }
}