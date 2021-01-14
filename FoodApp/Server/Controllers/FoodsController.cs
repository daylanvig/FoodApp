using FoodApp.Core.Interfaces;
using FoodApp.Server.Features.Foods;
using FoodApp.Shared.Models.Foods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public void Delete(int id)
        {
            // todo -> implement
            throw new NotImplementedException();
        }
    }
}
