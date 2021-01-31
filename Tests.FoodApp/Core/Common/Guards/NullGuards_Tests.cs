using FoodApp.Core.Common.Guards;
using System;
using Xunit;

namespace Tests.FoodApp.Core.Common.Guards
{
    public class NullGuards_AgainstNull
    {
        [Fact]
        public void ShouldNotThrow()
        {
            Guard.AgainstNull(new NullGuardTestClass(), "Param");
        }

        [Fact]
        public void ShouldThrowAnArgumentException()
        {
            var argumentException = Assert.Throws<ArgumentException>(() => Guard.AgainstNull(null, "Param", "Test message"));
            Assert.Equal("Test message (Parameter 'Param')", argumentException.Message);
        }
    }

    public class NullGuards_ShouldBeNull
    {
        [Fact]
        public void ShouldThrowAnArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Guard.ShouldBeNull(new NullGuardTestClass(), "Param"));
        }

        [Fact]
        public void ShouldNotThrow()
        {
            Guard.ShouldBeNull(null, "Param");
        }
    }


    /// <summary>
    /// General test class 
    /// </summary>
    class NullGuardTestClass
    {

    }
}
