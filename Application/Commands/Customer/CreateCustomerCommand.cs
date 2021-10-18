using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Customer
{
    public class CreateCustomerCommand
    {
        public record Command(Core.Entities.Customer Customer) : IRequest<Response<Core.Entities.Customer>>;

        public class Handler : IRequestHandler<Command, Response<Core.Entities.Customer>>
        {
            private readonly ICustomerRepository _repository;

            public Handler(ICustomerRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Customer>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.AddAsync(request.Customer);
                return new Response<Core.Entities.Customer>(result);
            }
        }
    }
}