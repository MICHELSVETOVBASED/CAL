using CalTechnology.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CalTechnology.Data.Interfaces;


namespace CalTechnology.Controllers;

public class CarsController:Controller{
    private readonly IAllCars _allCars;
    private readonly ICarsCategory _allCategories;

    public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat){
        _allCars = iAllCars;
        _allCategories = iCarsCat;
    }
    
    public ViewResult List(){
        ViewBag.Title = "Page with autas";
        CarsListViewModel obj = new CarsListViewModel();
        obj.allCars = _allCars.Cars;
        obj.carCategory = "Automobiles";
        return View(obj);
    }
}