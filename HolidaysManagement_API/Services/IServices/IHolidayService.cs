using HolidaysManagement_API.Dtos;
using HolidaysManagement_API.Models;

namespace HolidaysManagement_API.Services.IServices
{
    public interface IHolidayService
    {
        HolidayRequestDTO GetHolidayRequestById(int id);
        IEnumerable<HolidayRequestDTO> GetAllHolidayRequests();
        void CreateHolidayRequest(HolidayRequestDTO intput);
        Task<HolidayRequestDTO> UpdateHolidayRequest(HolidayRequestDTO input);
        void DeleteHolidayRequest(int id);
    }
}
