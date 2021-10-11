using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IAdGalleryRepository : IBaseRepository<AdGallery>
    {
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
    }
}
