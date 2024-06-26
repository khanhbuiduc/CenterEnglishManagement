﻿using CenterEnglishManagement.Context;
using CenterEnglishManagement.Extentions;
using CenterEnglishManagement.Models.UserModels;
using CenterEnglishManagement.Service.IService;
using CenterEnglishManagement.Service.IService.IUserServices;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Service.UserServices
{
    public class UserServices:CommonServices<User>, IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllStudentAsync(int pageIndex, int pageSize, string sortBy, bool sortDesc)
        {
            try
            {

                IQueryable<User> query = _context.Users.Where(u => u.Role == UserRole.Student);

                if (!string.IsNullOrEmpty(sortBy))
                {
                    query = sortDesc ? query.OrderByDescending(e => EF.Property<object>(e, sortBy))
                                     : query.OrderBy(e => EF.Property<object>(e, sortBy));
                }

                return await query.Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<IEnumerable<User>> GetAllByRoleAsync(int pageIndex, int pageSize, string sortBy, bool sortDesc, UserRole role)
        {
            try
            {

                IQueryable<User> query = _context.Users.Where(u => u.Role == role);

                if (!string.IsNullOrEmpty(sortBy))
                {
                    query = sortDesc ? query.OrderByDescending(e => EF.Property<object>(e, sortBy))
                                     : query.OrderBy(e => EF.Property<object>(e, sortBy));
                }

                return await query.Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
