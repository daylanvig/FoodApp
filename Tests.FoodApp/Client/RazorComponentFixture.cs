using Bunit;
using FoodApp.Client.Services.System;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MudBlazor;
using System;

namespace Tests.FoodApp.Client
{
    public class RazorComponentFixture<TComponent> : TestContext where TComponent : IComponent
    {
        public RazorComponentFixture()
        {
            MockApiRequestService = new Mock<IApiRequestService>();
            MockSnackbar = new Mock<ISnackbar>();
            Services.AddSingleton(MockApiRequestService.Object);
            Services.AddSingleton(MockSnackbar.Object);
        }

        // backing to support single sut per test
        private IRenderedComponent<TComponent> _sut;

        private Action<ComponentParameterCollectionBuilder<TComponent>> _parameterBuilder;
        
        // Allow overrides via Virtual
        protected virtual IRenderedComponent<TComponent> GetSut() => _parameterBuilder != null ? RenderComponent<TComponent>(_parameterBuilder) : RenderComponent<TComponent>();
        protected IRenderedComponent<TComponent> Sut
        {
            get
            {
                // single instance per test
                if (_sut == null)
                {
                    _sut = GetSut();
                }

                return _sut;

            }
        }

        #region CommonMocks
        protected Mock<IApiRequestService> MockApiRequestService { get; }
        protected Mock<ISnackbar> MockSnackbar { get; }
        #endregion

        protected void SetParameters(Action<ComponentParameterCollectionBuilder<TComponent>> testParameterBuilder)
        {
            _parameterBuilder = testParameterBuilder;
        }

    }
}
