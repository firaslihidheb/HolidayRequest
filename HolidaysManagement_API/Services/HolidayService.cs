using HolidaysManagement_API.Data;
using HolidaysManagement_API.Dtos;
using HolidaysManagement_API.Models;
using HolidaysManagement_API.Services.IServices;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;

namespace HolidaysManagement_API.Services
{
    public class HolidayService: IHolidayService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public HolidayService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void CreateHolidayRequest(HolidayRequestDTO intput)
        {
            var objectToCreate = _mapper.Map<HolidayRequestDTO, HolidayRequest>(intput);
            objectToCreate.CreatedOn = DateTime.Now;
            _dbContext.Requests.AddAsync(objectToCreate);
            _dbContext.SaveChanges();
        }

        public void DeleteHolidayRequest(int id)
        {
            try
            {
                HolidayRequest request = _dbContext.Requests.FirstOrDefault(el => el.RequestId == id);
                _dbContext.Requests.Remove(request);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<HolidayRequestDTO> GetAllHolidayRequests()
        {
            try
            {
                return _mapper.Map<IEnumerable<HolidayRequest>, IEnumerable<HolidayRequestDTO>>(_dbContext.Requests);
                 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public HolidayRequestDTO GetHolidayRequestById(int id)
        {
            HolidayRequest request = _dbContext.Requests.FirstOrDefault(f => f.RequestId == id);
            return _mapper.Map<HolidayRequest, HolidayRequestDTO>(request);
        } 

        public async Task<HolidayRequestDTO> UpdateHolidayRequest(HolidayRequestDTO input)
        {
            var request =  _dbContext.Requests.FirstOrDefault(el => el.RequestId == input.RequestId);
            if(request != null)
            {
                request.ApprovalMappingId = input.ApprovalMappingId;
                request.Status = input.Status;
                request.Reason = input.Reason;  
                request.StartDate = input.StartDate;
                request.EndDate = input.EndDate;
            }

            _dbContext.Requests.Update(request);
            _dbContext.SaveChanges();
            return _mapper.Map<HolidayRequest, HolidayRequestDTO>(request);
        }
    }
}
