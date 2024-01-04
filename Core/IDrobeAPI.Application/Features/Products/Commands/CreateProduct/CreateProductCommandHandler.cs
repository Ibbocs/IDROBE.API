using IDrobeAPI.Application.Features.Products.Rules;
using IDrobeAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            //await productRules.ProductTitleMustNotBeSame(products, request.Title); rule istifadesi
            throw new NotImplementedException();
        }
    }
}
