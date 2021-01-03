using AutoFixture;
using AutoFixture.AutoMoq;
using FoodApp.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace Tests.FoodApp.TestInfrastructure
{
    public class DefaultTestFixture<TSut> : Fixture
    {
        private TSut _sut;
        protected TSut Sut
        {
            get
            {
                // init once to allow mock overrides 
                if (_sut == null)
                {
                    _sut = CreateSut();
                }
                return _sut;
            }
        }
        public static DefaultTestFixture<TSut> Create()
        {
            return new DefaultTestFixture<TSut>();
        }

        public DefaultTestFixture()
        {
            Customize(new AutoMoqCustomization());
        }

        public void SetMock<TMock>(Mock<TMock> mock) where TMock : class
        {
            this.Register<TMock>(() => mock.Object);
        }

        public virtual TSut CreateSut()
        {
            return Build<TSut>().Create();
        }  
    }
}
