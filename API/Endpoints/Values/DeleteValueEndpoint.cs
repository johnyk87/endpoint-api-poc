namespace API.Endpoints.Values
{
    using API.Repositories;
    using Microsoft.AspNetCore.Mvc;

    public class DeleteValueEndpoint : ValuesEndpoint
    {
        private readonly IValueRepository repository;

        public DeleteValueEndpoint(IValueRepository repository)
        {
            this.repository = repository;

        }

        [HttpDelete("{id}")]
        public void Handle(int id)
        {
            this.repository.Delete(id);
        }
    }
}
