using IDrobeAPI.Application.Features.Products.Model;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetByIdProducts;

public class GetByIdProductQueryRequest: IRequest<GenericActionResponse<ProductSingleViewModel>>
{
    public int Id { get; set; }
    public bool isDeleted { get; set; } = false;

}
