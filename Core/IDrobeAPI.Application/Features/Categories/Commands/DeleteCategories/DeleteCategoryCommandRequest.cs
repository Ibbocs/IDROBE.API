using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Commands.DeleteCategories;

public class DeleteCategoryCommandRequest:IRequest<ActionResponse>
{
    public int Id { get; set; }
}
