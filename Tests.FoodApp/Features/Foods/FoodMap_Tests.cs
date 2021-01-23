using AutoMapper;
using FoodApp.Server.Features.Foods;
using Xunit;

namespace Tests.FoodApp.Features.Foods
{
    public class FoodMap_Tests
    {

        [Fact]
        public void ValidateMaps()
        {
            var config = new MapperConfiguration(c => c.AddProfile<MapProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
