using AutoFixture;
using FoodApp.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Tests.FoodApp.TestInfrastructure
{
    public static class DataTestHelpers
    {
        public static TContext AddInMemoryDatabase<TContext>(this Fixture fixture, string tenantId = "") where TContext : DataContext
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            fixture.Register<DbContextOptions<DataContext>>(() => options);
            fixture.Register<string>(() => tenantId);
            var database = fixture.Freeze<TContext>();
            fixture.Register<IDataContext>(() => database);
            return database;
        }
    }
}
