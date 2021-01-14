using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Server.Features.Foods;
using FoodApp.Shared.Models.Foods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Food> _foodRepository;

        public FoodsController(IMediator mediator, IRepository<Food> foodRepository)
        {
            _mediator = mediator;
            _foodRepository = foodRepository;
        }

        // GET: api/Foods
        [HttpGet]
        public Task<IEnumerable<FoodModel>> Get()
        {
            return _mediator.Send(new GetMyFoods());
        }

        // GET api/Foods/5
        [HttpGet("{id}")]
        public Task<FoodModel> Get(int id)
        {
            return _mediator.Send(new GetFood(id));
        }

        // POST api/Foods
        [HttpPost]
        public Task<FoodModel> Post([FromBody] FoodModel food)
        {
            return _mediator.Send(new CreateNewFood(food.Name, food.AmountOnHand.GetValueOrDefault(0), food.QuantityType));
        }

        // PUT api/Foods/5
        [HttpPut("{id}")]
        public Task<FoodModel> Put(int id, [FromBody] FoodModel food)
        {
            return _mediator.Send(new EditFood(id, food.Name, food.AmountOnHand.GetValueOrDefault(0), food.QuantityType));
        }

        // DELETE api/Foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _foodRepository.GetByIdAsync(id);
            if (food == null)
            {
                return BadRequest();
            }
            await _foodRepository.DeleteAsync(food);
            return Ok();
        }
    }
}
