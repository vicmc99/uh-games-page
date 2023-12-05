using Data.DTO.In;

namespace Services.Domain.CategoryService;

public interface ICategoryService
{
    public void PostCategory(CreateCategoryDto createCategoryDto);
}