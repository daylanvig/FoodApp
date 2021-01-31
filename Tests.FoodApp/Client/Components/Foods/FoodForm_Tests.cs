using Bunit;
using FoodApp.Client.Components.Foods;
using FoodApp.Client.Components.Shared;
using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Foods;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.FoodApp.Client.ClientTestHelpers;
using Tests.FoodApp.TestInfrastructure;
using Xunit;
using static Tests.FoodApp.Client.ClientTestHelpers.SaveFooterHelpers;

namespace Tests.FoodApp.Client.Components.Foods
{
    public class FoodForm_Tests : RazorComponentFixture<FoodForm>
    {
        protected int OnFoodsChangeCallbackInvokedCount { get; private set; } = 0;
        protected void OnFoodChangeCallback()
        {
            OnFoodsChangeCallbackInvokedCount += 1;
        }

        protected ComponentParameterCollectionBuilder<FoodForm> AddTestBase(ComponentParameterCollectionBuilder<FoodForm> componentParameterBuilder)
        {
            return componentParameterBuilder.Add(f => f.OnFoodsChange, () => OnFoodChangeCallback());
        }
    }

    public class FoodForm_NewFood_Tests : FoodForm_Tests
    {
        private readonly FoodModel _food = new();

        /// <summary>
        /// Set Default Test Params
        /// </summary>
        private void SetDefaults()
        {
            SetParameters(p =>
                AddTestBase(p)
               .Add(f => f.Food, _food));
        }

        #region Rendering
        [Fact]
        public void ShouldRenderWithTitleAddNewFood()
        {
            // Arrange
            SetDefaults();
            // Act + Assert
            Assert.Contains("Add New Food", Sut.Markup);
        }

        [Fact]
        public void ShouldNotHaveADeleteButton()
        {
            // Arrange
            SetDefaults();
            // Act + Assert
            Assert.Null(GetDeleteButton(Sut));
        }

        [Fact]
        public void ShouldNotHaveACancelButton()
        {
            // Arrange
            SetDefaults();
            // Act + Assert
            Assert.Null(GetCancelButton(Sut));
        }

        [Fact]
        public void ShouldHaveAnAddNowButton()
        {
            // Arrange
            SetDefaults();
            // Act + Assert
            var saveButton = GetSaveButton(Sut);
            Assert.NotNull(saveButton);
            Assert.Contains(SaveFooter.ADD_LABEL, saveButton.InnerHtml);
        }
        #endregion
        [Fact]
        public void ShouldReRenderToBeEditMode()
        {
            // Arrange
            SetDefaults();
            // Act
            Sut.InvokeAsync(() =>
            {
                Sut.Instance.SetFood(new FoodModel
                {
                    Id = 1,
                    Name = "Orange"
                });
            }).GetAwaiter().GetResult();
            // Assert
            Assert.Contains("Editing Orange", Sut.Markup);
        }

        #region SaveEvent
        [Fact]
        public void ShouldInvokeApiRequestServicesAddMethod()
        {
            // Arrange
            SetDefaults();
            var saveButton = GetSaveButton(Sut);
            // Act
            saveButton.Click();
            // Assert
            MockApiRequestService.Verify(m => m.Add(It.IsAny<FoodModel>()), Times.Once);
        }

        [Fact]
        public void ShouldInvokeCallbackToNotifyOfChange()
        {
            // Arrange
            SetDefaults();
            var saveButton = GetSaveButton(Sut);
            // Act
            saveButton.Click();
            // Assert
            Assert.Equal(1, OnFoodsChangeCallbackInvokedCount);
        }

        [Fact]
        public void ShouldNotInvokeCallbackToNotifyOfChangeWhenAddFails()
        {
            // Arrange
            SetDefaults();
            MockApiRequestService
                .Setup(m => m.Add(It.IsAny<FoodModel>()))
                .ThrowsAsync(new Exception());
            var saveButton = GetSaveButton(Sut);
            // Act
            saveButton.Click();
            // Assert
            Assert.Equal(0, OnFoodsChangeCallbackInvokedCount);
        }



        #endregion
    }

    public class FoodForm_EditingFood_Tests : FoodForm_Tests
    {
        private readonly FoodModel _food = new FoodModel
        {
            AmountOnHand = 1,
            Id = 14,
            Name = "Banana",
            QuantityType = "Items"
        };

        private void SetDefaults()
        {
            SetParameters(p =>
                AddTestBase(p)
               .Add(f => f.Food, _food)
           );
        }

        #region Rendering
        [Fact]
        public void ShouldRenderWithTitleEditingBanana()
        {
            // Arrange
            SetDefaults();
            // Act + Assert
            Assert.Contains("Editing Banana", Sut.Markup);
        }

        [Fact]
        public void ShouldHaveADeleteButton()
        {
            // Arrange
            SetDefaults();
            // Act + Assert
            Assert.NotNull(SaveFooterHelpers.GetDeleteButton(Sut));
        }

        [Fact]
        public void ShouldHaveACancelButton()
        {
            // Arrange
            SetDefaults();
            // Act + Assert
            Assert.NotNull(SaveFooterHelpers.GetCancelButton(Sut));
        }

        [Fact]
        public void ShouldHaveASaveChangesButton()
        {
            // Arrange
            SetDefaults();
            // Act + Assert
            var saveButton = SaveFooterHelpers.GetSaveButton(Sut);
            Assert.NotNull(saveButton);
            Assert.Contains(SaveFooter.SAVE_LABEL, saveButton.InnerHtml);
        }
        #endregion

        [Fact]
        public void ShouldSetToAddMode()
        {
            // Arrange
            SetDefaults();
            // Act
            var clearButton = SaveFooterHelpers.GetCancelButton(Sut);
            clearButton.Click();
            // Assert
            Assert.Contains("Add New Food", Sut.Markup);
        }

        #region SaveEvent
        [Fact]
        public void ShouldInvokeApiRequestServicesEditMethod()
        {
            // Arrange
            SetDefaults();
            var saveButton = GetSaveButton(Sut);
            // Act
            saveButton.Click();
            // Assert
            MockApiRequestService.Verify(m => m.Edit(_food.Id, It.IsAny<FoodModel>()), Times.Once);
        }

        [Fact]
        public void ShouldInvokeCallbackToNotifyOfChange()
        {
            // Arrange
            SetDefaults();
            var saveButton = GetSaveButton(Sut);
            // Act
            saveButton.Click();
            // Assert
            Assert.Equal(1, OnFoodsChangeCallbackInvokedCount);
        }

        #endregion
    }
}
