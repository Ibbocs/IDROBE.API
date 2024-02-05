using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Commands.CreateCategories;

public class CreateCategoryCommandRequest : IRequest<ActionResponse>
{
    public int ParentId{ get; set;}
    public string Name { get; set; }
    public int Priorty { get; set; }
}
