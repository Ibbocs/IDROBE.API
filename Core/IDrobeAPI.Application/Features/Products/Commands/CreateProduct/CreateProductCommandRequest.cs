using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Commands.CreateProduct
{                                                     //bu void uygun gelir, sebebi bhavior ise dusun deye, cunki o response gozleyir
    public class CreateProductCommandRequest:IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int StockQuantity { get; set; }

        public IList<int> CategoryIds { get; set; }
    }
}
