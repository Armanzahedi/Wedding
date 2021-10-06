using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Infrastructure.Repositories
{
    public interface IArticleCommentRepository : IBaseRepository<ArticleComment>
    {
    }
    public class ArticleCommentRepository : BaseRepository<ArticleComment>, IArticleCommentRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public ArticleCommentRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
