using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IAdGalleryRepository : IBaseRepository<AdGallery>
    {
        Task<int> GetAdGalleryCount(int adId);
    }
    public class AdGalleryRepository : BaseRepository<AdGallery>, IAdGalleryRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public AdGalleryRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> GetAdGalleryCount(int adId)
        {
            return await base.GetDefaultQuery().AsQueryable().Where(a => a.AdId == adId).CountAsync();
        }
    }
}
