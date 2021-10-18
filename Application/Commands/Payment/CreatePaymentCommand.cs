using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Commands.Payment
{
    public class CreatePaymentCommand
    {
        public record Command(Core.Entities.Payment Payment) : IRequest<Response<Core.Entities.Payment>>;

        public class Handler : IRequestHandler<Command, Response<Core.Entities.Payment>>
        {
            private readonly IPaymentRepository _repository;

            public Handler(IPaymentRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Payment>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.AddAsync(request.Payment);
                return new Response<Core.Entities.Payment>(result);
            }
        }
    }
}