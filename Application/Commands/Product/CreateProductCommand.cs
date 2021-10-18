using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Product
{
    public class CreateProductCommand
    {
        public record Command(Core.Entities.Product Product) : IRequest<Response<Core.Entities.Product>>;

        public class Handler : IRequestHandler<Command, Response<Core.Entities.Product>>
        {
            private readonly IProductRepository _repository;

            public Handler(IProductRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Product>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.AddAsync(request.Product);
                return new Response<Core.Entities.Product>(result);
            }
        }
    }
}