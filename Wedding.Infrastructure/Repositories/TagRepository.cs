using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding.Infrastructure.Repositories
{
    public interface ITagRepository
    {
        IQueryable<Tag> GetDefaultQuery();
        Task<Tag> Save(string name);
    }
    public class TagRepository : ITagRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public TagRepository(MyDbContext context, ILogRepository logger)
        {
            _context = context;
            _logger = logger;
        }

        public IQueryable<Tag> GetDefaultQuery()
        {
            return _context.Tags;
        }

        public async Task<Tag> Save(string name)
        {
            var tag = _context.Tags.FirstOrDefault(t => t.Title.ToLower().Trim() == name.ToLower().Trim()) ?? new Tag { Title = name };
            if (tag.Id != 0)
                _context.Entry(tag).State = EntityState.Modified;
            else
                _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
