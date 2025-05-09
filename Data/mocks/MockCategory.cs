using CalTechnology.Data.Interfaces;
using CalTechnology.Data.Models;


namespace CalTechnology.Data.mocks;

public class MockCategory:ICarsCategory{
    public IEnumerable<Category> AllCategories{
        get{
            return new List<Category>(){
                new Category{ categoryName = "Electric",desc = "Modern type of transport"},
                new Category{categoryName = "Classical",desc ="Internal combustion engine"}
            };
        }
    }
}