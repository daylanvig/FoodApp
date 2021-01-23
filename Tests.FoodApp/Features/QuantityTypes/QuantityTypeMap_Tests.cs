using AutoMapper;
using FoodApp.Server.Features.QuantityTypes;
using Xunit;

namespace Tests.FoodApp.Features.QuantityTypes
{
    public class QuantityTypeMap_Tests
    {
        [Fact]
        public void ValidateConfiguration()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<MapProfile>());
            cfg.AssertConfigurationIsValid();
        }
    }
}
