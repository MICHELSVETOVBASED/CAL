using CalTechnology.Data.Interfaces;
using System;
using System.Collections.Generic;
using CalTechnology.Data.Models;
using CalTechnology.Data.Models;
using CalTechnology.Data;
using Microsoft.EntityFrameworkCore;

namespace CalTechnology.Data.Repository;

public class CarRepository:IAllCars{
    
    private readonly AppDBContent appDBContent;
    public CarRepository(AppDBContent appDBContent){
        this.appDBContent = appDBContent;
    }

    public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);
    public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.isFavourite)
        .Include(c => c.Category);

    public Car getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);// ddd
}