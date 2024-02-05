using IDrobeAPI.Application.Features.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Models;

public class CategoryListViewModel
{
    public IList<CategoryGetDto> Items { get; set; }
}
