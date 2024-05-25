using CalTechnology.Data.Models;


namespace CalTechnology.Data.Interfaces;

public interface ICarsCategory{
    IEnumerable<Category> AllCategories{ get; }
}