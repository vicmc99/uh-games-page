using Data.DTO.In;
using Data.Model;
using DataAccess.Repository;

namespace Services.Domain.CategoryService;

public class CategoryService : ICategoryService

{
    private readonly IDataRepository _repository;

    public CategoryService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async void PostCategory(CreateCategoryDto createCategoryDto)
    {
        var category = new Category
        {
            Name = createCategoryDto.Name,
            Sports = new List<Sport>()
        };
        await _repository.Set<Category>().Create(category);
        await _repository.Save(default);
    }
}