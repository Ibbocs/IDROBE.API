using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Commands.DeleteBrands;

public class DeleteBrandCommandRequest:IRequest<ActionResponse>
{
    public int Id { get; set; }
}
