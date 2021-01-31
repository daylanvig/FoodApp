using FoodApp.Core.Common.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FoodApp.Core.Common.Guards
{
    public class IEnumerableGuards_Tests
    {
        private IEnumerable<int> _items;

        [Fact]
        public void ShouldThrowAnArgumentExceptionWhenNull()
        {
            Assert.Throws<ArgumentException>(() => Guard.HasMinimumLength(_items, 0, "Items"));
        }

        [Fact]
        public void ShouldThrowAnArgumentExceptionWhenLengthLessThanMinimum()
        {
            // Arrange
            _items = new int[] { 1, 2, 3 };
            // Act + Assert
            Assert.Throws<ArgumentException>(() => Guard.HasMinimumLength(_items, 4, "Items"));
        }

        [Fact]
        public void ShouldNotThrow()
        {
            // Arrange
            _items = new int[] { 1, 2, 3 };
            // Act
            Guard.HasMinimumLength(_items, 2, "Items");
            // Assert 
            // -> no assertion if test passes
        }
    }
}
