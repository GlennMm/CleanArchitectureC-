using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Invoice
{
    public class GetOneInvoiceQuery
    {
        public record Query(int Id) : IRequest<Response<Core.Entities.Invoice>>;

        public class Handler : IRequestHandler<Query, Response<Core.Entities.Invoice>>
        {
            private readonly IInvoiceRepository _repository;

            public Handler(IInvoiceRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response<Core.Entities.Invoice>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await _repository.GetByIdAsync(request.Id);
                return new Response<Core.Entities.Invoice>(results);
            }
        }
    }
}