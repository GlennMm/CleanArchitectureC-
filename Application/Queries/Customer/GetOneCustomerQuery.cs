using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Customer
{
    public class GetOneCustomerQuery
    {
        public record Query(int Id) : IRequest<Response<Core.Entities.Customer>>;

        public class Handler : IRequestHandler<Query, Response<Core.Entities.Customer>>
        {
            private readonly ICustomerRepository _repository;

            public Handler(ICustomerRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Customer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await _repository.GetByIdAsync(request.Id);
                return new Response<Core.Entities.Customer>(results);
            }
        }
    }
}