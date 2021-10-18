using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ResponseModel;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries.Invoice
{
    public class GetAllInvoicesQuery
    {
        public record Query() : IRequest<Response<IEnumerable<Core.Entities.Invoice>>>;

        public class Handler : IRequestHandler<Query, Response<IEnumerable<Core.Entities.Invoice>>>
        {
            public readonly IInvoiceRepository Repo;

            public Handler(IInvoiceRepository repo)
            {
                Repo = repo;
            }

            public async Task<Response<IEnumerable<Core.Entities.Invoice>>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var results = await Repo.GetAllAsync();
                return new Response<IEnumerable<Core.Entities.Invoice>>(results);
            }
        }
    }
}