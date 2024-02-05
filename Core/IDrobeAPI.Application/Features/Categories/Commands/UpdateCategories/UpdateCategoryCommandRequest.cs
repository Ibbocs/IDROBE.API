using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Commands.UpdateCategories;

public class UpdateCategoryCommandRequest:IRequest<ActionResponse>
{
    public int Id { get; set; }

    public int ParentId { get; set; }
    public string Name { get; set; }
    public int Priorty { get; set; }
}
