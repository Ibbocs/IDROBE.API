using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Products.Exceptions;
using IDrobeAPI.Domain.Entities;

namespace IDrobeAPI.Application.Features.Products.Rules
{
    public class ProductRules:BaseRules
    {
        //meselen eyni adli product elave etmek olmaz
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
