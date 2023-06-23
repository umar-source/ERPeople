using ERPeople.DAL.Data;


namespace ERPeople.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ERPeopleDbContext _dbContext;

        public UnitOfWork( ERPeopleDbContext dbContext )
        {
            _dbContext = dbContext;
         
        }


        /* public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
         {
             // Get the appropriate repository interface based on the entity type
             if (typeof(TEntity) == typeof(Customer))
             {
                 return (IGenericRepository<TEntity>)CustomerRepo;
             }
             else if (typeof(TEntity) == typeof(Product))
             {
                 return (IGenericRepository<TEntity>)ProductRepo;
             }
             if (typeof(TEntity) == typeof(CustomerAddress))
             {
                 return (IGenericRepository<TEntity>)CustomerAddressRepo;
             }
             else if (typeof(TEntity) == typeof(ProductCategory))
             {
                 return (IGenericRepository<TEntity>)ProductCategoryRepo;
             }
             if (typeof(TEntity) == typeof(OrderPayment))
             {
                 return (IGenericRepository<TEntity>)OrderPaymentRepo;
             }
             else if (typeof(TEntity) == typeof(Order))
             {
                 return (IGenericRepository<TEntity>)OrderRepo;
             }
             // Add other repository interfaces here as needed

             throw new ArgumentException($"No repository found for entity type {typeof(TEntity)}");
         } */


        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

    }
}
