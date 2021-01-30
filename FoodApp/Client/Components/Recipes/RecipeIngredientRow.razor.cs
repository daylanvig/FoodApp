using FoodApp.Client.Services.System;
using FoodApp.Client.Shared;
using FoodApp.Shared.Models.Foods;
using FoodApp.Shared.Models.Recipes;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Recipes
{
    public partial class RecipeIngredientRow : ComponentBase
    {
        [Inject]
        IApiRequestService ApiRequestService { get; set; }
        [Parameter]
        public RecipeIngredientModel RecipeIngredient { get; set; }
        /// <summary>
        /// Ingredient index/position in recipe list
        /// </summary>
        /// <remarks>
        /// Will be null for an ingredient that has not yet been added to the ingredient list
        /// </remarks>
        /// <value>
        /// The index.
        /// </value>
        [Parameter]
        public int? Index { get; set; }
        /// <summary>
        /// Callback invoked when the row is complete (all fields have values)
        /// </summary>
        /// <value>
        /// The recipeingredient from the row
        /// </value>
        [Parameter]
        public EventCallback<IndexedEntity<RecipeIngredientModel>> OnRowComplete { get; set; }
        [Parameter]
        public EventCallback<int?> OnDeleteRequested { get; set; }
        protected MudForm form;
        protected RecipeIngredientModel recipeIngredient = new();
        protected IReadOnlyList<FoodModel> foods = Array.Empty<FoodModel>();
        protected IReadOnlyList<QuantityTypeModel> quantityTypes = Array.Empty<QuantityTypeModel>();


        protected QuantityTypeModel RecipeIngredientQuantityType
        {
            get
            {
                return quantityTypes.FirstOrDefault(q => q.Type == recipeIngredient.QuantityType);
            }
            set
            {
                recipeIngredient.QuantityType = value.Type;
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <remarks>
        /// This deals with displaying null vs non null values
        /// </remarks>
        /// <value>
        /// The amount.
        /// </value>
        protected decimal? Amount
        {
            get
            {
                if (recipeIngredient.Amount == 0)
                {
                    return null;
                }
                return recipeIngredient.Amount;
            }
            set
            {
                recipeIngredient.Amount = value.GetValueOrDefault(0);
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            form.Reset();
            recipeIngredient = RecipeIngredient;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            foods = await ApiRequestService.GetList<FoodModel>();
            quantityTypes = await ApiRequestService.GetList<QuantityTypeModel>();
        }

        protected async Task SaveChanges()
        {
            form.Validate();
            if (form.IsValid && OnRowComplete.HasDelegate)
            {
                await OnRowComplete.InvokeAsync(new IndexedEntity<RecipeIngredientModel>(recipeIngredient, Index));
            }
        }

        protected async Task DeleteRow()
        {
            await OnDeleteRequested.InvokeAsync(Index);
        }

        protected void OnValidChanged()
        {
            StateHasChanged();
        }

        protected string RecipeIngredientDisplay(int foodId)
        {
            return foods.First(f => f.Id == foodId)?.Name ?? string.Empty;
        }
    }
}
