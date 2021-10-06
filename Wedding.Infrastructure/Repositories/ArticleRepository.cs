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
    public interface IArticleRepository : IBaseRepository<Article>
    {
        Task<int> SaveArticleTags(int articleId,List<string> tags);
        Task<List<string>> GetArticleTags(int articleId);
        Task UpdateViewCount(int articleId);
    }
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly MyDbContext _context;
        private readonly ITagRepository _tagRepo;
        private readonly ILogRepository _logger;

        public ArticleRepository(MyDbContext context, ILogRepository logger, ITagRepository tagRepo) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _tagRepo = tagRepo;
        }

        public async Task<List<string>> GetArticleTags(int articleId)
        {

            var tags = await _context.ArticleTags.Where(x => x.ArticleId == articleId).Select(x=>x.Tag.Title).ToListAsync();
            return tags;
        }

        public async Task<int> SaveArticleTags(int articleId, List<string> tags)
        {
            var existing = await _context.ArticleTags.Where(x => x.ArticleId == articleId).ToListAsync();
            _context.RemoveRange(existing);


            foreach (var tag in tags)
            {
                var savedTag = await _tagRepo.Save(tag);
                await _context.ArticleTags.AddAsync(new ArticleTag()
                {
                    ArticleId = articleId,
                    TagId = savedTag.Id,
                });
            }
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task UpdateViewCount(int articleId)
        {
            var article = await _context.Articles.Include(x => x.ArticleTags).FirstOrDefaultAsync(x => x.Id == articleId);
            article.ViewCount += 1;
            await base.Update(article);
            var tags = article.ArticleTags.Select(at => _context.Tags.FirstOrDefault(x => x.Id == at.TagId)).ToList();
            //foreach (var tag in tags)
            //{
            //    tag.ViewCount += 1;
            //    _context.Entry(tag).State = EntityState.Modified;
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
