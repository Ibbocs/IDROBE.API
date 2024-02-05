using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.DTOs;

public class BrandGetDto
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string Description { get; set; }
    public string BrandType { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    //burda inculud elesem eger hansisa entity dtosun, onda entity adin yazmaliyam mapper gore
}
