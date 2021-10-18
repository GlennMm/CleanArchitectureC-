using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Payment
{
    public class GetAllPaymentsQuery
    {
        public record Query() : IRequest<Response<IEnumerable<Core.Entities.Payment>>>;

        public class Handler : IRequestHandler<Query, Response<IEnumerable<Core.Entities.Payment>>>
        {
            private readonly IPaymentRepository _repository;

            public Handler(IPaymentRepository repository)
            {
                _repository = repository;
            }
            
            public async Task<Response<IEnumerable<Core.Entities.Payment>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await _repository.GetAllAsync();
                return new Response<IEnumerable<Core.Entities.Payment>>(results);
            }
        }

    }
}