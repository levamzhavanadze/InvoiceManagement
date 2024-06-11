﻿using WebAPIAuth.Users;

namespace WebAPIAuth.Interfaces
{
    public interface IUserRepository
    {
        string GetName();
        void AddUser(User user);
        void CreateUser(User user);
        User GetUser(UserDto user);
        List<User> GetAllUsers();


    }
}