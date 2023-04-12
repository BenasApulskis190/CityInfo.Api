using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Api.Models;

namespace CityInfo.Api
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        // public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>() {
                new CityDto() {
                    Id = 1,
                    Name = "city 1",
                    Description = "city 1 description",
                    PointOfInterest = new List<PointOfInterestDto>() {
                        new PointOfInterestDto() {
                            Id = 5,
                            Name = "city 1 point of interests",
                            Description = "city 1 point of interests Description"
                        },
                        new PointOfInterestDto() {
                            Id = 6,
                            Name = "city 1 point of interests 1",
                            Description = "city 1 point of interests Description 1"
                        },
                        new PointOfInterestDto() {
                            Id = 7,
                            Name = "city 1 point of interests 2",
                            Description = "city 1 point of interests Description 2"
                        },
                    }
                },
                new CityDto() {
                    Id = 2,
                    Name = "city 2",
                    Description = "city 2 description"
                },
                new CityDto() {
                    Id = 3,
                    Name = "city 3",
                    Description = "city 3 description"
                }
            };
        }
    }
}