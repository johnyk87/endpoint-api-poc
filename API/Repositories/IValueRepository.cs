namespace API.Repositories
{
    using System.Collections.Generic;
    using API.Models;

    public interface IValueRepository
    {
        IEnumerable<Value> Get();

        Value Get(int id);

        Value Upsert(Value value);

        void Delete(int id);
    }
}
