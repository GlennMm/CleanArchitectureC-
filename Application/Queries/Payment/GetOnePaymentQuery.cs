using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Payment
{
    public class GetOnePaymentQuery
    {
        public record Query(int Id) : IRequest<Response<Core.Entities.Payment>>;

        public class Handler : IRequestHandler<Query, Response<Core.Entities.Payment>>
        {
            private readonly IPaymentRepository _repository;

            public Handler(IPaymentRepository repository)
            {
                _repository = repository;
            }
            
            public async Task<Response<Core.Entities.Payment>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await _repository.GetByIdAsync(request.Id);
                return new Response<Core.Entities.Payment>(results);
            }
        }
    }
}