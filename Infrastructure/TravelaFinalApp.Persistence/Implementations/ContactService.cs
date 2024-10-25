using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.ContactDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class ContactService(IContactRepository contactRepository,TravelaDbContext _context,IMapper _mapper) : IContactService
    {
        public async Task CreateAsync(ContactCreateDto contactCreateDto)
        {
            var contact=_mapper.Map<Contact>(contactCreateDto);
            await contactRepository.CreateAsync(contact);
            await contactRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
                throw new CustomException(400, "Id", "Id can't be null!");
            var existContact=await contactRepository.GetByIdAsync(id);
            if (existContact == null)
                throw new CustomException(404, "Id", "Data can't be found..");
            existContact.IsDeleted = true;
            await contactRepository.SaveChangesAsync();
        }

        public async Task<ContactListDto> GetAllAsync(int page=1,string? search=null)
        {
            var query = _context.Contacts.Where(c => !c.IsDeleted).AsQueryable();
            if(search!= null)
                query = query.Where(t => t.FullName.Contains(search));
            var datas = await query
                .Skip((page - 1) * 3)
                .Take(3)
                .ToListAsync();

            ContactListDto contactListDto = new ContactListDto();
            contactListDto.TotalCount= datas.Count;
            contactListDto.CurrentPage = page;
            contactListDto.Contacts = _mapper.Map<List<ContactReturnDto>>(datas);

            return contactListDto;
        }

        public async Task<ContactReturnDto> GetByIdAsync(int id)
        {
            if (id == null)
                throw new CustomException(400, "Id", "Id can't be null!");
            var existContact = await contactRepository.GetByIdAsync(id);
            if (existContact == null)
                throw new CustomException(404, "Id", "Data can't be found..");
            return _mapper.Map<ContactReturnDto>(existContact);
        }
    }
}
