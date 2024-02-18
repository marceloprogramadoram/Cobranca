using Cobranca.Domain.Repository;
using Cobranca.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.InfraStructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly CobrancaContext _context;

        public Repository(CobrancaContext context) => _context = context;
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task AddRangeAsync(List<T> entity) => await _context.Set<T>().AddRangeAsync(entity);

        public async Task DeleteAsync(T entity) => await Task.Run(() => { _context.Set<T>().Remove(entity); });
        public async Task DeleteRangeAsync(List<T> entity) => await Task.Run(() => { _context.Set<T>().RemoveRange(entity); });

        public async Task UpdateAsync(T entity) => await Task.Run(() => { _context.Set<T>().Update(entity); });

        public async Task UpdateRangeAsync(List<T> entity) => await Task.Run(() => { _context.Set<T>().UpdateRange(entity); });

        public async Task<T> Get(Expression<Func<T, bool>> expression) => await _context.Set<T>().Where(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null) => expression == null
            ? await _context.Set<T>().ToListAsync()
            : await _context.Set<T>().Where(expression).ToListAsync();

        public async Task<T> GetById(int key) => await _context.Set<T>().FindAsync(key);


    }
}
