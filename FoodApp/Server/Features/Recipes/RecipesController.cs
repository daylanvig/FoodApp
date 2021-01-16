using FoodApp.Shared.Models.Foods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Recipes
{
    // todo -> implement
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Recipes
        [HttpGet]
        public Task<IEnumerable<RecipeModel>> Get()
        {
            return _mediator.Send(new Listing.Query());
        }

        // GET api/Recipes/5
        [HttpGet("{id}")]
        public Task<RecipeModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/Recipes
        [HttpPost]
        public Task<RecipeModel> Post([FromBody] RecipeModel food)
        {
            return _mediator.Send(new Create.Command(food.Name, food.Ingredients, food.Url));
        }

        // PUT api/Recipes/5
        [HttpPut("{id}")]
        public Task<RecipeModel> Put(int id, [FromBody] RecipeModel food)
        {
            throw new NotImplementedException();
        }

        // DELETE api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
