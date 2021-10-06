using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Infrastructure.Repositories
{
    public interface IArticleCategoryRepository : IBaseRepository<ArticleCategory>
    {
    }
    public class ArticleCategoryRepository : BaseRepository<ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public ArticleCategoryRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
