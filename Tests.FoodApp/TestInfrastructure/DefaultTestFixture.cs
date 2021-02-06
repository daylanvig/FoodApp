using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FoodApp.Core.Domain.Common;
using FoodApp.Core.Interfaces;
using Moq;

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

        public Mock<IMapper> DoMockMapper()
        {
            var mockMapper = new Mock<IMapper>();
            SetMock(mockMapper);
            return mockMapper;
        }

        public Mock<TMock> DoMock<TMock, TReturns>(TReturns returns) where TMock : class
        {
            var mock = CreateMock.Default<TMock, TReturns>(returns);
            SetMock(mock);
            return mock;
        }

        public Mock<IRepository<TEntity>> DoMockRepository<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var mock = CreateRepositoryMock.CreateRepository<TEntity>(entity);
            SetMock(mock);
            return mock;
        }
    }
}
