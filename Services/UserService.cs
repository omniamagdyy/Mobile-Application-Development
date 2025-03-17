using assignment1.Data;
using assignment1.Models;
using assignment1.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using assignment1.Controllers;
using System;

namespace assignment1.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user != null ? "Login Success" : "Login Failed";
        }
        public async Task<string> Signup(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                return "Signup Failed: Email already exists";

            if (user.Email.Split('@')[0] != user.StudentID)
                return "Signup Failed: Student ID does not match Email";

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "Signup Success";
        }

        public async Task<User> GetUser(int id) => await _context.Users.FindAsync(id);

        public async Task<string> UpdateProfile(int id, User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return "User Not Found";

            user.Name = updatedUser.Name;
            user.Gender = updatedUser.Gender;
            user.Password = updatedUser.Password;

            await _context.SaveChangesAsync();
            return "Profile Updated";
        }

        public async Task<string> UploadProfilePhoto(int id, string photoUrl)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return "User Not Found";

            user.ProfilePhoto = photoUrl;
            await _context.SaveChangesAsync();
            return "Photo Uploaded";
        }
    }
}


    
