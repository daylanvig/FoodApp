using FoodApp.Core.Interfaces;
using FoodApp.Server.Features.Foods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITenantProvider _tenantProvider;

        public FoodsController(IMediator mediator, ITenantProvider tenantProvider)
        {
            _mediator = mediator;
            _tenantProvider = tenantProvider;
        }

        // GET: api/Foods
        [HttpGet]
        public Task<IEnumerable<Shared.Models.Foods.Food>> Get()
        {
            return _mediator.Send(new GetMyFoods());
        }

        // GET api/Foods/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Foods
        [HttpPost]
        public Task<Shared.Models.Foods.Food> Post([FromBody] Shared.Models.Foods.Food food)
        {
            return _mediator.Send(new CreateNewFood(food.Name, food.AmountOnHand.Value, food.QuantityType));
        }

        // PUT api/Foods/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Shared.Models.Foods.Food food)
        {

        }

        // DELETE api/Foods/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
