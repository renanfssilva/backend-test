using System.Collections.Generic;
using System.Linq;
using ScoreCombination.Domain.Interfaces.Repositories;
using ScoreCombination.Infrastructure.Data.Database;

namespace ScoreCombination.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ScoreCombinationDbContext _context;

        public RepositoryBase(ScoreCombinationDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
