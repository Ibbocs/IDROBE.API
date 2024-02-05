using IDrobeAPI.Application.Features.Categories.DTOs;
using IDrobeAPI.Application.Models.PaginationModels;

namespace IDrobeAPI.Application.Features.Categories.Models
{
    public class CategoryPaginationListViewModel:BasePageableModel
    {
        public IList<CategoryGetDto> Items { get; set; }
    }
}
