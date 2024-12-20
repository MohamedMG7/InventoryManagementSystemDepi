﻿using InventoryManagementSystem.BLL.Dto;
using InventoryManagementSystem.BLL.Dto.UserDtos;

using InventoryManagementSystem.DAL.Data.Models;
using InventoryManagementSystem.DAL.Reposatiries;
namespace InventoryManagementSystem.BLL.Manager.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;
        private readonly IShoppingCartRepo _shoppingCartRepo;

        public UserManager(IUserRepo userRepo, IShoppingCartRepo shoppingCartRepo)
        {
            _userRepo = userRepo;
            _shoppingCartRepo = shoppingCartRepo;
        }

        public void Add(UserAddDto UserAddDto)
        {
            var User = new User { 
                Name = UserAddDto.Name,
                Email = UserAddDto.Email,
                PasswordHash =  UserAddDto.Password,
                State = UserAddDto.State,
                City = UserAddDto.City,
                Street = UserAddDto.Street,
                PhoneNumber = UserAddDto.PhoneNumber,
                UserType = UserAddDto.UserType
            };

            _userRepo.Add(User);
            _userRepo.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _userRepo.GetbyID(id);
            var shoppingcart = _shoppingCartRepo.GetByUserId(id);
            if (user != null && !user.isDeleted) {
				_userRepo.Delete(user);
				_shoppingCartRepo.Delete(shoppingcart);
				_shoppingCartRepo.SaveChanges();
				_userRepo.SaveChanges();
			}
        }

        public IEnumerable<UserReadDto> GetAll()
        {
            var users = _userRepo.GetAll();
            var usersList = users.Select(x => new UserReadDto { 
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                State = x.State,
                City = x.City,
                Street = x.Street,
                PhoneNumber = x.PhoneNumber,
                isDeleted = x.isDeleted
            });
            return usersList;
        }

        public UserReadDto GetbyId(int id)
        {
            var userModel = _userRepo.GetbyID(id);
            UserReadDto userReadDto = new UserReadDto { 
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
                State = userModel.State,
                City = userModel.City,
                Street = userModel.Street,
                PhoneNumber = userModel.PhoneNumber,
                isDeleted = userModel.isDeleted,
            };

            return userReadDto;
        }

        public void SaveChanges()
        {
            _userRepo.SaveChanges();
        }

        public void Update(UserUpdateDto UserUpdateDto)
        {
            var userModel = _userRepo.GetbyID(UserUpdateDto.Id);
            
            userModel.Name = UserUpdateDto.Name;
            userModel.Email = UserUpdateDto.Email;
            userModel.State = UserUpdateDto.State;
            userModel.City = UserUpdateDto.City;
            userModel.Street = UserUpdateDto.Street;
            userModel.PhoneNumber = UserUpdateDto.PhoneNumber;
            userModel.PasswordHash = UserUpdateDto.Password;

            _userRepo.Update(userModel);
            _userRepo.SaveChanges();
        }
    }
}
