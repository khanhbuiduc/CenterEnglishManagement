using CenterEnglishManagement.Dto.ModelDto;
using CenterEnglishManagement.Models.OtherModels;

namespace CenterEnglishManagement.Service.IService.IOtherServices
{
    public interface IStudentAttendanceServices: ICommonServices<StudentAttendance>
    {
       List<MonthlyStudentStatisticDto> GetMonthlyStudentAttendanceAsync();
        List<QuarterlyStudentStatisticDto> GetQuarterlyStudentAttendanceAsync();
        List<YearlyStudentStatisticDto> GetYearlyStudentAttendanceAsync();
    }
}
