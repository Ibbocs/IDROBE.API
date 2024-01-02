using IDrobeAPI.Application.Interfaces.Repositories.EnityReadRepos;
using IDrobeAPI.Domain.Entities;
using IDrobeAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Implementation.Repositories.EnityReadRepos
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
