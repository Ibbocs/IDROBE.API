using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.DTOs;

public class CategoryGetDto
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; }
    public int Priorty { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    //burda inculud elesem eger hansisa entity dtosun, onda entity adin yazmaliyam mapper gore
}   
