using FoodApp.Shared.Models.Foods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace FoodApp.Server.Features.QuantityTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuantityTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/QuantityTypes
        [HttpGet]
        public Task<IEnumerable<QuantityTypeModel>> Get()
        {
            return _mediator.Send(new Listing.Query());
        }

        // GET api/QuantityTypes/5
        [HttpGet("{id}")]
        public Task<QuantityTypeModel> Get(int id)
        {
            // todo -> implement
            throw new NotImplementedException();
        }

        // POST api/QuantityTypes
        [HttpPost]
        public Task<QuantityTypeModel> Post([FromBody] QuantityTypeModel quantityTypeModel)
        {
            return _mediator.Send(new Create.Command(quantityTypeModel.Type));
        }

        // PUT api/QuantityTypes/5
        [HttpPut("{id}")]
        public Task<QuantityTypeModel> Put(int id, [FromBody] QuantityTypeModel quantityTypeModel)
        {
            return _mediator.Send(new Edit.Command(id, quantityTypeModel.Type));
        }

        // DELETE api/QuantityTypes/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _mediator.Send(new Delete.Command(id));
        }
    }
}
