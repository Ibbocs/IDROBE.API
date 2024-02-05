using IDrobeAPI.Application.Features.Brands.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Models;

public class BrandListViewModel
{
    public IList<BrandGetDto> Items { get; set; }
}
