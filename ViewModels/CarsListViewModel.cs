using CalTechnology.Data.Models;

namespace CalTechnology.ViewModels;

public class CarsListViewModel{
    public IEnumerable<Car> allCars{ get; set; }
    public string carCategory{ get; set; }
}