namespace API.Endpoints.Values
{
    using System;
    using API.Models;
    using API.Repositories;
    using Microsoft.AspNetCore.Mvc;

    public class PostValueEndpoint : ValuesEndpoint
    {
        private readonly IValueRepository repository;

        public PostValueEndpoint(IValueRepository repository)
        {
            this.repository = repository;

        }

        [HttpPost]
        public ActionResult<Value> Handle(Value value)
        {
            if (value.Id == default)
            {
                value.Id = new Random().Next();
            }

            var newValue = this.repository.Upsert(value);

            return this.CreatedAtRoute(nameof(GetValueEndpoint), new { id = value.Id }, newValue);
        }
    }
}
