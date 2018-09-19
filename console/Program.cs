using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace console {
    public class Program {
        static void Main (string[] args) {

            try {
                var cars =
                    File
                    .ReadAllLines ("fuel.csv")
                    .Skip (1)
                    .Select (l => Fuel.GetFuel (l))
                    .ToList ();

                var manufacturers =

                    File
                    .ReadAllLines ("manufacturers.csv")
                    .Select (l => Manufacturers.GetManufacturer (l))
                    .SkipLast (1)
                    .ToList ();

                //top 3 fuel efficient cars by country

                var query = manufacturers
                    .Join (cars, c => c.CarName, m => m.CarName, 
                            (m, c) => 
                                new 
                                {
                                    Manufacturer = m,
                                    Cars = c
                                })
                    .GroupBy(m => m.Manufacturer.Country)
                    .OrderBy(m => m.Key);                                     

                foreach (var country in query) {                    
                    Console.WriteLine ($"Country:{country.Key}");
                    foreach (var car in country.OrderByDescending(c => c.Cars.Combined).Take(3)) {
                        Console.WriteLine ($"\t{car.Cars.CarName} {car.Cars.Carline} : {car.Cars.Combined}");
                    }
                }              

            }
            catch(Exception e){
                Console.WriteLine(e.ToString());
            }

        }
    }

    public class Fuel {
        public int Year { get; set; }
        public string CarName { get; set; }
        public string Carline { get; set; }
        public float EngDispl { get; set; }
        public int Cylinders { get; set; }
        public int CityFE { get; set; }
        public int HwyFE { get; set; }
        public int Combined { get; set; }

        public Fuel () {

        }
        public static Fuel GetFuel (string line) {

            var cols = line.Split (',');

            return new Fuel {
                Year = int.Parse (cols[0]),
                    CarName = cols[1],
                    Carline = cols[2],
                    EngDispl = float.Parse (cols[3]),
                    Cylinders = int.Parse (cols[4]),
                    CityFE = int.Parse (cols[5]),
                    HwyFE = int.Parse (cols[6]),
                    Combined = int.Parse (cols[7])
            };
        }
    }

    public class Manufacturers {
        public string CarName { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }

        public static Manufacturers GetManufacturer (string m) {
            var cols = m.Split (',');
            return new Manufacturers {
                CarName = cols[0],
                    Country = cols[1],
                    Year = int.Parse (cols[2])
            };
        }
    }
}