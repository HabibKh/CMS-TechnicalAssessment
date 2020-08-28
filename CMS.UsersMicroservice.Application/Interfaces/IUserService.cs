using CMS.UsersMicroservice.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.UsersMicroservice.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByName(string name);
        Task<int> Add(UserDto userDto);
        Task Update(UserDto userDto);
        Task DeleteById(int id);
    }
}
