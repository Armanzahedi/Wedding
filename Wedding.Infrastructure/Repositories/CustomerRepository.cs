using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using Wedding.Infrastructure.DTOs;

namespace Wedding.Infrastructure.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        CustomerDetailsDto GetCustomerDetails(int customerId);
        CustomerEditDto GetCustomerEdit(int customerId);
    }
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public CustomerRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
        public IQueryable<Customer> GetCustomerWithRelations(int customerId)
        {
            return _context.Customers.Include(c => c.User).Include(c => c.JobType).Include(c => c.GeoDivision).Where(c => c.Id == customerId);
        }
        public CustomerDetailsDto GetCustomerDetails(int customerId)
        {
            return this.GetCustomerWithRelations(customerId).Select(c =>
            new CustomerDetailsDto
            {
                Id = c.Id,
                FirstName = c.User.FirstName,
                LastName = c.User.LastName,
                Image = c.User.Avatar ?? "user-avatar.png",
                PhoneNumber = c.User.PhoneNumber,
                Address = c.Address,
                Email = c.User.Email,
                JobType = c.JobType.Title,
                Region = c.GeoDivision.Title,
                JobTitle = c.JobTitle
            }
            ).FirstOrDefault();
        }

        public CustomerEditDto GetCustomerEdit(int customerId)
        {
            return this.GetCustomerWithRelations(customerId).Select(c =>
            new CustomerEditDto
            {
                Id = c.Id,
                UserId = c.User.Id,
                FirstName = c.User.FirstName,
                LastName = c.User.LastName,
                Image = c.User.Avatar,
                PhoneNumber = c.User.PhoneNumber,
                Address = c.Address,
                Email = c.User.Email,
                JobTypeId = c.JobType.Id,
                GeoDivisionId = c.GeoDivision.Id,
                JobTitle = c.JobTitle

            }
            ).FirstOrDefault();
        }
    }
}
