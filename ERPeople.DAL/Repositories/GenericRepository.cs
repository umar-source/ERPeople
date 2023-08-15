using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ERPeople.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ERPeopleDbContext _dbContext;
        private readonly DbSet<T> _entitiySet;

        public GenericRepository(ERPeopleDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }

        public void Add(T item)
        {
            _entitiySet.Add(item);
        }

        public void Delete(T item)
        {
            _entitiySet.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _entitiySet.AsNoTracking().AsEnumerable();
        }

        public T GetById(int id)
        {
            T item = _entitiySet.Find(id);
            if (id == null)
            {
                throw new InvalidOperationException($"Entity of type {typeof(T).Name} with ID {id} not found in database.");
            }
            return item;
        }

        public void Update(T item)
        {
            _entitiySet.Update(item);
            // We are not doing save changes at repo level becaus ewe do single save transaction
            // at unitofwork if we do save changes here there unit of work savechanges have no meaning to use 
            // and if we want to implement rollback it will not
            // _dbContext.SaveChanges();
        }
    }
}
