using AutoFixture;
using AutoFixture.AutoMoq;
using FoodApp.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Tests.FoodApp.TestInfrastructure
{
    public class DefaultTestFixture<TSut> : Fixture
    {
        public static DefaultTestFixture<TSut> Create()
        {
            return new DefaultTestFixture<TSut>();
        }

        private DefaultTestFixture()
        {
            Customize(new AutoMoqCustomization());
        }

        public TSut CreateSut()
        {
            return Build<TSut>().Create();
        }

        public TContext AddInMemoryDatabase<TContext>(string tenantId = "") where TContext: DataContext
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            this.Register<DbContextOptions<DataContext>>(() => options);
            this.Register<string>(() => tenantId);
            var database = this.Freeze<TContext>();
            this.Register<IDataContext>(() => database);
            return database;
        }
    }
}
