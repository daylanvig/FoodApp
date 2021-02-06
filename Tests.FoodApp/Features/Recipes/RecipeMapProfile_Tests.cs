using AutoMapper;
using FoodApp.Server.Features.QuantityTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FoodApp.Features.Recipes
{
    public class RecipeMapProfile_Tests
    {

        [Fact]
        public void ConfigurationShouldBeValid()
        {
            var config = new MapperConfiguration(c => c.AddProfile<MapProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
