using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Commands.ProductCreatings;

public class ProductCreateCommandRequest: IRequest<ActionResponse>
{
    public int BrandId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }
    public bool IsNew { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public decimal Length { get; set; }
    public string ClothesType { get; set; }
    public string ArmType { get; set; }

    public IList<int> CategoryIds { get; set; }
}
