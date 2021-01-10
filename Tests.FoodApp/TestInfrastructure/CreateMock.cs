using Moq;
using System.Threading.Tasks;

namespace Tests.FoodApp.TestInfrastructure
{
    public class CreateMock
    {
        /// <summary>
        /// Create a mock that returns the provided value as default. Value is also used for Task returns.
        /// </summary>
        /// <typeparam name="TMock">Mock type</typeparam>
        /// <typeparam name="TReturns">The type of the returns.</typeparam>
        /// <param name="returns">Mock data to return</param>
        /// <returns></returns>
        public static Mock<TMock> Default<TMock, TReturns>(TReturns returns) where TMock : class
        {
            var mock = new Mock<TMock>();
            mock.SetReturnsDefault<TReturns>(returns);
            mock.SetReturnsDefault<Task<TReturns>>(Task.FromResult(returns));
            return mock;
        }
    }
}
