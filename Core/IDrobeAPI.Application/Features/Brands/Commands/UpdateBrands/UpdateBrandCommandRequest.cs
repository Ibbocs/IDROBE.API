using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Commands.UpdateBrands;

public class UpdateBrandCommandRequest:IRequest<ActionResponse>
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string Description { get; set; }
    public string BrandType { get; set; }
    public string ImagePath { get; set; }
}
