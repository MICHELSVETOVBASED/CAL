using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using CalTechnology.Data.Models;

namespace CalTechnology.Data;

public class DBObjects{
    public static void Initial(AppDBContent content){
        if (!content.Category.Any())
            content.Category.AddRange(Categories.Select(c => c.Value));
        if (!content.Car.Any()){
            content.AddRange(
                new Car{
                    name = "Tesla Model S",
                    shortDesc = "Fast prodigy auto",
                    longDesc = "Beautiful,fast and so quite auto by Tesla company",
                    img = "/img/11.jpg",
                    price = 45000,
                    isFavourite = true,
                    available = true,
                    Category = Categories["Electric cars"]
                },
                new Car{
                    name = "Mustang Mach-E",
                    shortDesc = "Quite and peaceful",
                    longDesc = "Cozy auto for big city life",
                    price = 39000,
                    img = "/img/22.jpg",
                    isFavourite = false,
                    available = true,
                    Category = Categories["Electric cars"]
                },
                new Car{
                    name = "BMW M4",
                    shortDesc = "Impudent and stylish",
                    longDesc = "Cozy auto for big city life",
                    img = "/img/33.jpg",
                    price = 65535,
                    isFavourite = true,
                    available = true,
                    Category = Categories["Classical autos"]
                },
                new Car{
                    name = "Mercedes C Class",
                    shortDesc = "Snug, comfy and big",
                    longDesc = "Homely auto for bang city",
                    img = "/img/44.jpg",
                    price = 50000,
                    isFavourite = false,
                    available = false,
                    Category = Categories["Classical autos"]
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
                    Category = Categories["Electric cars"]
                });
        }

        content.SaveChanges();
    }

    private static Dictionary<string, Category> category;
    public static Dictionary<string, Category> Categories{
        get{
            if (category == null){
                var list = new Category[]{
                    new Category{ categoryName = "Electric cars", desc = "Modern type of transport" },
                    new Category{ categoryName = "Classical autos", desc = "Cars with interal combustion engine" }
                };
                category = new Dictionary<string, Category>();
                foreach (Category el in list)
                    category.Add(el.categoryName, el);
            }

            return category;
        }
    }
}