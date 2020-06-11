namespace API.Endpoints.Values
{
    using API.Models;
    using API.Repositories;
    using Microsoft.AspNetCore.Mvc;

    public class PutValueEndpoint : ValuesEndpoint
    {
        private readonly IValueRepository repository;

        public PutValueEndpoint(IValueRepository repository)
        {
            this.repository = repository;

        }

        [HttpPut("{id}")]
        public ActionResult Handle(int id, Value value)
        {
            if (value.Id != id)
            {
                return this.ValidationProblem("Resource path does not match resource id.");
            }

            this.repository.Upsert(value);

            return this.Ok();
        }
    }
}
