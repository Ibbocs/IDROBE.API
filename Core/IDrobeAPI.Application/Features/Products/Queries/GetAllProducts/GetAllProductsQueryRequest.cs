﻿using IDrobeAPI.Application.Features.Products.Model;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<GenericActionResponse<ProductListViewModel>>
{
    public bool isDeleted { get; set; } = false;
}
