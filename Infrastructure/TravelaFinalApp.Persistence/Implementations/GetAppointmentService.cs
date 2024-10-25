using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.GetAppointmentDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class GetAppointmentService(IGetAppointmentRepository getAppointmentRepository,TravelaDbContext _context,IMapper _mapper) : IGetAppointmentService
    {
        public async Task CreateAsync(GetAppointmentCreateDto getAppointmentCreateDto)
        {
            if (getAppointmentCreateDto.DateTime < DateTime.UtcNow)
                throw new CustomException(400, "DateTime", "Appointment date cannot be in the past.");
            var appointment=_mapper.Map<GetAppointment>(getAppointmentCreateDto);
            await getAppointmentRepository.CreateAsync(appointment);
            await getAppointmentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
                throw new CustomException(400, "Id", "Id can't be null!");
            var existAppointment = await getAppointmentRepository.GetByIdAsync(id);
            if (existAppointment == null)
                throw new CustomException(404, "Id", "Data can't be found..");
            existAppointment.IsDeleted = true;
            await getAppointmentRepository.SaveChangesAsync();
        }

        public async Task<GetAppointmentListDto> GetAllAsync(int page = 1, string? search = null)
        {
            var query = _context.GetAppointments.Where(a => !a.IsDeleted).AsQueryable();
            if (search != null)
                query = query.Where(t => t.FullName.Contains(search));
            var datas = await query
                .Skip((page - 1) * 3)
                .Take(3)
                .ToListAsync();

            GetAppointmentListDto getAppointmentListDto = new GetAppointmentListDto();
            getAppointmentListDto.TotalCount = datas.Count;
            getAppointmentListDto.CurrentPage = page;
            getAppointmentListDto.GetAppointments = _mapper.Map<List<GetAppointmentReturnDto>>(datas);

            return getAppointmentListDto;
        }

        public async Task<GetAppointmentReturnDto> GetByIdAsync(int id)
        {
            if (id == null)
                throw new CustomException(400, "Id", "Id can't be null!");
            var existAppointment = await getAppointmentRepository.GetByIdAsync(id);
            if (existAppointment == null)
                throw new CustomException(404, "Id", "Data can't be found..");
            return _mapper.Map<GetAppointmentReturnDto>(existAppointment);
        }
    }
}
