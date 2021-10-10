using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;

namespace Wedding.Infrastructure.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        CustomerDetailsDto GetCustomerDetails(int customerId);
        CustomerEditDto GetCustomerEdit(int customerId);
        Task<bool> CreateCustomer(CustomerCreateDto model);
        Task<bool> EditCustomer(CustomerEditDto model);
        Task<Customer> DeleteCustomer(int customerId);
    }
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepo;



        public CustomerRepository(MyDbContext context, ILogRepository logger, UserManager<User> userManager, IUserRepository userRepo) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _userRepo = userRepo;
        }
        public IQueryable<Customer> GetCustomerWithRelations(int customerId)
        {
            return _context.Customers.Include(c => c.User).Where(c => c.Id == customerId);
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

        public async Task<bool> CreateCustomer(CustomerCreateDto model)
        {
            try
            {
                var user = new User
                {
                    PhoneNumber = model.PhoneNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, model.PhoneNumber);
                if (result.Succeeded == false)
                    return false;

                await _userManager.AddToRoleAsync(user, "Customer");
                var customer = new Customer
                {
                    UserId = user.Id,
                    RegisterDate = DateTime.Now,
                    JobTypeId = model.JobTypeId != 0 ? model.JobTypeId : null,
                    GeoDivisionId = model.GeoDivisionId != 0 ? model.GeoDivisionId : null,
                    JobTitle = model.JobTitle
                };
                await base.AddOrUpdate(customer);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> EditCustomer(CustomerEditDto model)
        {
            try
            {
                var customer = await base.GetById(model.Id);
                customer.JobTypeId = model.JobTypeId != 0 ? model.JobTypeId : null;
                customer.GeoDivisionId = model.GeoDivisionId != 0 ? model.GeoDivisionId : null;
                customer.Address = model.Address;
                customer.JobTitle = model.JobTitle;
                await base.Update(customer);
                var user = await _userRepo.GetById(customer.UserId);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.UserName = model.PhoneNumber;
                user.Email = model.Email;
                user.Avatar = model.Image;
                await _userRepo.UpdateUser(user);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            var customer = await base.GetById(customerId);

            var user = await _userRepo.GetById(customer.UserId);

            await base.Delete(customerId);
            await _userRepo.DeleteUser(user.Id);

            return customer;
        }
    }
}
