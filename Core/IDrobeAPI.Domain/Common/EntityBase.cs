using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Domain.Common;

public class EntityBase : IEntityBaseAble
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; } 
    public bool IsDeleted { get; set; } = false;
}
