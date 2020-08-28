using AutoMapper;
using CMS.UsersMicroservice.Application.Interfaces;
using CMS.UsersMicroservice.Data.Interfaces;
using CMS.UsersMicroservice.Domain.Models;
using CMS.UsersMicroservice.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.UsersMicroservice.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Add(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var id = await _repository.CreateAsync(user);
            return id;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetManyAsync().OrderBy(u => u.Id).ToListAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _repository.GetSingleOrDefaultAsync(u => u.Id == id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> GetByName(string name)
        {
            var user = await _repository.GetSingleOrDefaultAsync(u => u.Name == name);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task Update(UserDto userDto)
        {
            var user = await _repository.GetSingleOrDefaultAsync(u => u.Id == userDto.Id);
            if (user.Name != userDto.Name)
            {
                await _repository.UpdateAsync(user);
            }
        }
        public async Task DeleteById(int id)
        {
            var user = await _repository.GetSingleOrDefaultAsync(u => u.Id == id);
            
            if (user != null)
            {
                await _repository.DeleteAsync(user);
            }
            
        }

    }
}
