namespace API.Endpoints.Values
{
    using API.Models;
    using API.Repositories;
    using Microsoft.AspNetCore.Mvc;

    public class GetValueEndpoint : ValuesEndpoint
    {
        private readonly IValueRepository repository;

        public GetValueEndpoint(IValueRepository repository)
        {
            this.repository = repository;

        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetValueEndpoint))]
        public ActionResult<Value> Handle(int id)
        {
            return this.repository.Get(id) ?? (ActionResult<Value>)this.NotFound();
        }
    }
}
