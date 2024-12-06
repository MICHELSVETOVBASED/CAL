using CalTechnology.Data.Interfaces;
using CalTechnology.Data.Models;


namespace CalTechnology.Data.mocks;

public class MockCars : IAllCars{



    private readonly ICarsCategory _categoryCars = new MockCategory();
    public IEnumerable<Car> Cars{
        get{
            return new List<Car>{
                new Car{
                    name = "Tesla Model S",
                    shortDesc = "Fast prodigy auto",
                    longDesc = "Beautiful,fast and so quite auto by Tesla company",
                    img = "/img/11.jpg", 
                    price = 45000,
                    isFavourite = true,
                    available = true, 
                    Category = _categoryCars.AllCategories.First()//то есть здесь категория с Car равняется ссылке на мок категорию, в ней - енамрбл и первый
                },
                new Car{
                    name = "Mustang Mach-E",
                    shortDesc = "Quite and peaceful",
                    longDesc = "Cozy auto for big city life",
                    price = 39000,
                    img = "/img/22.jpg",
                    isFavourite = false,
                    available = true,
                    Category = _categoryCars.AllCategories.First()
                },
                new Car{
                    name = "BMW M4",
                    shortDesc = "Impudent and stylish",
                    longDesc = "Cozy auto for big city life",
                    img = "/img/33.jpg",
                    price = 65535,
                    isFavourite = true,
                    available = true,
                    Category = _categoryCars.AllCategories.Last()
                },
                new Car{
                    name = "Mercedes C Class",
                    shortDesc = "Snug, comfy and big",
                    longDesc = "Homely auto for bang city",
                    img = "/img/44.jpg",
                    price = 50000,
                    isFavourite = false,
                    available = false,
                    Category = _categoryCars.AllCategories.Last()
                },
                new Car{   
                    name = "Nissan Gt R",
                    shortDesc = "Bold, noiseless and chicky",
                    longDesc = "So smoothy and sussy",
                    //img = "https://i.pinimg.com/736x/cd/d4/08/cdd408ac637eae35abbad14a2d60629d.jpg", ЗДЕСЬ ПРИМЕР ПОЛНОГО ВВОДА
                    img = "/img/55.jpg",
                    price = 55000,
                    isFavourite = true,
                    available = true,
                    Category = _categoryCars.AllCategories.First()
                }
            };
        }
    }

    public IEnumerable<Car> getFavCars{ get; set; }

    public Car getObjectCar(int carId){
        throw new NotImplementedException();
    }
    public Car getObjectCar1(int carId){
        throw new NotImplementedException();
    }
}//new gray