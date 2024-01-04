﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest:IRequest<IList<GetAllProductsQueryResponse>>
    {
    }
}
