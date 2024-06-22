using CalTechnology.Data.Interfaces;
using CalTechnology.Data.Models;

namespace CalTechnology.Data.Repository;

public class CategoryRepository : ICarsCategory{
    private readonly AppDBContent appDBContent;

    public CategoryRepository(AppDBContent appDBontent){
        this.appDBContent = appDBContent;
    }

    public IEnumerable<Category> AllCategories => appDBContent.Category;
}
