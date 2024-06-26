﻿using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Models.UserModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class ClassServices: CommonServices<Class>, IClassServices
    {
        private readonly ApplicationDbContext _context;
        public ClassServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

       

        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            try
            {
                _context.Set<Schedule>().Add(schedule);
                await _context.SaveChangesAsync();
                return schedule;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<TuitionFee> CreateTuitionFeeAsync(TuitionFee tuitionFee)
        {
            try
            {
                _context.Set<TuitionFee>().Add(tuitionFee);
                await _context.SaveChangesAsync();
                return tuitionFee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<bool> ClassNameExistsAsync(string className, string grade, int year)
        {
            return await _context.Classes.AnyAsync(c => c.ClassName == className && c.Grade == grade && c.Year == year);
        }
            }
}
