using IDrobeAPI.Application.Interfaces.Repositories.EntityWriteRepo;
using IDrobeAPI.Domain.Entities;
using IDrobeAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence.Implementation.Repositories.EntityWriteRepos
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
