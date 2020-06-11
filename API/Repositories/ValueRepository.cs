namespace API.Repositories
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using API.Models;

    public class ValueRepository : IValueRepository
    {
        private readonly ConcurrentDictionary<int, Value> store = new ConcurrentDictionary<int, Value>();

        public IEnumerable<Value> Get()
        {
            return this.store.Values;
        }

        public Value Get(int id)
        {
            this.store.TryGetValue(id, out var value);

            return value;
        }

        public Value Upsert(Value value)
        {
            this.store.AddOrUpdate(value.Id, value, (key, oldValue) => value);

            return value;
        }

        public void Delete(int id)
        {
            this.store.TryRemove(id, out _);
        }
    }
}
