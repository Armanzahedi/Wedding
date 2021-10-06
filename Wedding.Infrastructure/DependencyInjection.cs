using Wedding.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            #region Add Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ISystemParameterRepository, SystemParameterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IArticleCommentRepository, ArticleCommentRepository>();
            services.AddScoped<IContactUsFormRepository, ContactUsFormRepository>();
            services.AddScoped<IGeoDivisionRepository, GeoDivisionRepository>();
            services.AddScoped<IJobTypeRepository, JobTypeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            #endregion

            return services;
        }
    }
}
