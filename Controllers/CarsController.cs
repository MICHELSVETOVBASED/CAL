using CalTechnology.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CalTechnology.Data.Interfaces;
using CalTechnology.Data.Models;


namespace CalTechnology.Controllers;

public class CarsController:Controller{
    private readonly IAllCars _allCars;
    private readonly ICarsCategory _allCategories;

    public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat){
        _allCars = iAllCars;
        _allCategories = iCarsCat;
    }
    
    [Route("Cars/List")]
    [Route("Cars/List/{category}")]
    public ViewResult List(string category){
        string _category = category;
        IEnumerable<Car> cars = null;
        string currCategory = "";
        
        if (string.IsNullOrEmpty(category)){
            cars = _allCars.Cars.OrderBy(i => i.id);
        }
        else{
            if (string.Equals("Electric", category, StringComparison.OrdinalIgnoreCase) || 
                string.Equals("Electromobiles", category, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("Electro", category, StringComparison.OrdinalIgnoreCase)){
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Electric")).OrderBy(i => i.id);
            }
            else if (string.Equals("Classical", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Classical")).OrderBy(i => i.id);
            }

            currCategory = _category;
        }
        
        var carObj = new CarsListViewModel{
            allCars = cars,
            carCategory = currCategory
        };
        
        ViewBag.Title = "Page with autas";
        return View(carObj);
    }
}