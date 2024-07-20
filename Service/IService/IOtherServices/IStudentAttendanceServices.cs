using CenterEnglishManagement.Dto.ModelDto;
using CenterEnglishManagement.Models.OtherModels;

namespace CenterEnglishManagement.Service.IService.IOtherServices
{
    public interface IStudentAttendanceServices: ICommonServices<StudentAttendance>
    {
        Task<int[]> GetMonthlyStudentAttendanceAsync(int year);
        Task<int[]> GetQuarterlyStudentAttendanceAsync(int year);
        Task<int[]> GetYearlyStudentAttendanceAsync(int year);
    }
}
