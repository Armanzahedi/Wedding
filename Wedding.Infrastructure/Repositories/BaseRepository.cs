using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Wedding.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<int> GetCount();
        Task<List<T>> GetListPaged(int pageNumber, int itemsPerPage);
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> AddOrUpdate(T entity);
        Task<T> Delete(int id);
        Task<T> Delete(T entity);
        Task<T> Remove(int id);
        IEnumerable<T> GetDefaultQuery();
    }
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        protected BaseRepository(MyDbContext context, ILogRepository logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().Where(x=>x.IsDeleted == false).ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<List<T>> GetListPaged(int pageNumber = 1, int itemsPerPage = 10)
        {
            var entity = await _context.Set<T>().Skip((pageNumber - 1) * itemsPerPage).Where(e => e.IsDeleted == false)
                .Take(itemsPerPage).ToListAsync();

            return entity;

        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            entity.InsertDate = DateTime.Now;
            entity.InsertUser = GetCurrentUsersName();
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            await _logger.LogEvent(entity.GetType().Name, entity.Id, "Add");

            return entity;
        }
        public async Task<T> Update(T entity)
        {
            var oldEntity = await _context.Set<T>().FindAsync(entity.Id);
            entity.InsertDate = oldEntity.InsertDate;
            entity.InsertUser = oldEntity.InsertUser;

            Detach(oldEntity);

            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser = GetCurrentUsersName();

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

           await _logger.LogEvent(entity.GetType().Name, entity.Id, "Update");

            return entity;
        }
        public async Task<T> AddOrUpdate(T entity)
        {
            var a = await _context.Set<T>().FindAsync(entity.Id);

            if (a != null)
            {
                return await Update(entity);
            }
            else
            {
                return await Add(entity);
            }
        }
        public async Task<T> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            entity.IsDeleted = true;
            return await Update(entity);
        }
        public async Task<T> Delete(T entity)
        {
            entity.IsDeleted = true;
            return await Update(entity);
        }
        public async Task<T> Remove(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public IEnumerable<T> GetDefaultQuery()
        {
            return _context.Set<T>().Where(m => m.IsDeleted == false);
        }

        #region Private Methods
        private void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.SaveChanges();
        }

        private string GetCurrentUsersName()
        {
            var userName = "";
            if (MyAppContext.Current?.User?.Identity?.Name != null)
            {
                userName = MyAppContext.Current.User.Identity.Name;
            }
            return userName;
        }

        #endregion
    }

}
