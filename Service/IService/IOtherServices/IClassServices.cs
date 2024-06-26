﻿using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Models.UserModels;

namespace CenterEnglishManagement.Service.IService.IOtherServices
{
    public interface IClassServices: ICommonServices<Class>
    {
        Task<TuitionFee> CreateTuitionFeeAsync(TuitionFee tuitionFee);
        Task<Schedule> CreateScheduleAsync(Schedule schedule);
        Task<bool> ClassNameExistsAsync(string className, string grade, int year);
    }
}
