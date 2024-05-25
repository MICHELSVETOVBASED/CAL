using CalTechnology.Data.Interfaces;
using CalTechnology.Data.Models;


namespace CalTechnology.Data.mocks;

public class MockCategory:ICarsCategory{
    public IEnumerable<Category> AllCategories{
        get{
            return new List<Category>(){
                new Category{ categoryName = "Electromobiles",desc = "Modern type of transport"},
                new Category{categoryName = "Classical automobiles",desc ="Internal combustion engine"}
            };
        }
    }
}