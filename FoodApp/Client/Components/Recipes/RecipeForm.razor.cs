using FoodApp.Client.Constants;
using FoodApp.Client.Services.System;
using FoodApp.Client.Shared;
using FoodApp.Core.Common;
using FoodApp.Core.Common.Guards;
using FoodApp.Shared.Models.Recipes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Recipes
{
    public partial class RecipeForm : ComponentBase
    {
        #region Dependencies
        [Inject]
        IApiRequestService ApiRequestService { get; set; }
        [Inject]
        ISnackbar SnackBar { get; set; }
        #endregion

        protected MudForm form;
        protected RecipeModel recipe = new()
        {
            Ingredients = new(),
            Steps = new()
            {
                new RecipeStepModel
                {
                    StepNumber = 1,
                    Direction = string.Empty
                }
            }
        };

        /// <summary>
        /// Adds the or updates an ingredient in the recipe
        /// </summary>
        /// <param name="entity">The ingredient.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        private void AddOrUpdateIngredient(RecipeIngredientModel entity, int? rowIndex)
        {
            if (rowIndex.HasValue)
            {
                recipe.Ingredients[rowIndex.Value] = entity;
            }
            else
            {
                recipe.Ingredients.Add(entity);
            }
            StateHasChanged();
        }

        /// <summary>
        /// Called invoked when row is updated to a valid value
        /// </summary>
        /// <param name="eventCallbackEntity">The event callback entity.</param>
        /// <returns></returns>
        protected void OnIngredientComplete(IndexedEntity<RecipeIngredientModel> eventCallbackEntity)
        {
            Guard.AgainstNull(eventCallbackEntity, nameof(RecipeIngredientModel), "No value received from callback");
            Guard.AgainstNull(eventCallbackEntity.Entity, nameof(RecipeIngredientModel), "Event value received but entity was null");
            AddOrUpdateIngredient(eventCallbackEntity.Entity, eventCallbackEntity.Index);
        }

        /// <summary>
        /// Event callback invoked by rows when delete/clear button is pressed
        /// </summary>
        /// <param name="ingredientIndex">Index of the ingredient.</param>
        /// <returns></returns>
        protected void OnIngredientRequestsDelete(int? ingredientIndex)
        {
            // if it has a value it's in the list, otherwise its just in the last row
            if (ingredientIndex.HasValue)
            {
                recipe.Ingredients.RemoveAt(ingredientIndex.Value);
            }
            // if it was the last row, this will just clear out the values
            StateHasChanged();
        }

        protected void OnKeyPressDirectionInput(KeyboardEventArgs e)
        {
            // if enter is pressed add a row unless shift enter is pressed (which is used for adding a new line)
            if (e.Key == Key.Enter && !e.ShiftKey)
            {
                OnAddStepRequested();
            }
        }

        protected void OnAddStepRequested()
        {
            recipe.Steps.Add(new RecipeStepModel
            {
                StepNumber = recipe.Steps.MaxOrDefault(m => m.StepNumber) + 1,
                Direction = string.Empty
            });
            // FUTURE: Focus the new input
        }

        protected void OnDeleteStepRequested(int stepNumber)
        {
            recipe.Steps.RemoveAll(s => s.StepNumber == stepNumber);
            recipe.Steps.ForEachWithIndex((step, index) =>
            {
                step.StepNumber = index + 1;
            });
        }

        protected async Task SaveRecipe()
        {
            form.Validate();
            if (!form.IsValid)
            {
                SnackBar.Add("Invalid. Adjust form and try again.", Severity.Error);
                return;
            }
            try
            {
                await ApiRequestService.Add(recipe);
                // TODO -> navigate to edit page
            }
            catch (Exception e)
            {
                SnackBar.Add($"Error saving: {e.Message}", Severity.Error);
            }
        }
    }
}
