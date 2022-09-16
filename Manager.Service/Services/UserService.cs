using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Service.DTO;
using Manager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            User userExists = await _userRepository.Get(userDTO.Id);

            if (userExists != null)
                throw new DomainException("Já existe um usuário cadastrado com o email informado");

            User user = _mapper.Map<User>(userDTO);
            user.Validate();

            User userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Get(long id)
        {
            User user = await _userRepository.Get(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
            List<User> users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            User user = await _userRepository.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            List<User> allUsers = await _userRepository.SearchByEmail(email);
            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            List<User> allUsers = await _userRepository.SearchByName(name);
            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            User userExists = await _userRepository.Get(userDTO.Id);

            if (userExists == null)
                throw new DomainException("Não Existe nenhum Usuário com os dados informados");

            User user = _mapper.Map<User>(userDTO);
            user.Validate();

            User userUpdate = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
