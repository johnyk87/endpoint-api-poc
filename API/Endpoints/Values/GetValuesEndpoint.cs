namespace API.Endpoints.Values
{
    using System.Collections.Generic;
    using API.Models;
    using API.Repositories;
    using Microsoft.AspNetCore.Mvc;

    public class GetValuesEndpoint : ValuesEndpoint
    {
        private readonly IValueRepository repository;

        public GetValuesEndpoint(IValueRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Value> Handle()
        {
            return this.repository.Get();
        }
    }
}
