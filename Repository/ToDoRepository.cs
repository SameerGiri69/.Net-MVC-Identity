using IdentityPractice.Data;
using IdentityPractice.Models;
using IdentityPractice.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApp.Interface;

namespace ToDoApp.Repository
{
    public class ToDoRepository : IToDoListService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;
        private readonly IConfiguration _configuration;

        public ToDoRepository(ApplicationDbContext context, IPhotoService photoService, IConfiguration configuration)
        {
            _context = context;
            _photoService = photoService;
            _configuration = configuration;
        }
        public bool AddList(ToDo toDo)
        {
            _context.Add(toDo);
            return Save();
        }

        public bool DeleteList(int id)
        {
            var todo = _context.ToDo.Where(x => x.Id  == id).FirstOrDefault();
            _context.Remove(todo);
            return Save();
        }

        public ToDo GetList(int id)
        {
            var todo = _context.ToDo.Where(x => x.Id == id).FirstOrDefault();
            return todo;
        }

        public bool UpdateList(ToDo toDo)
        {
            var oldToDo = _context.ToDo.Where(x => x.Id == toDo.Id).FirstOrDefault();
            oldToDo.Title = toDo.Title;
            oldToDo.Deadline = toDo.Deadline;
            oldToDo.User = toDo.User;
            oldToDo.Description = toDo.Description;
            oldToDo.ImageUrl = toDo.ImageUrl;
            return Save();
        }
        public bool UpdateListNoPhoto(ToDo toDo)
        {
            var oldToDo = _context.ToDo.Where(x => x.Id == toDo.Id).FirstOrDefault();
            oldToDo.Title = toDo.Title;
            oldToDo.Deadline = toDo.Deadline;
            oldToDo.User = toDo.User;
            oldToDo.Description = toDo.Description;
            return Save();
        }
        public bool Save()
        {
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected < 0)
                return false;
            return true;
        }

        public List<ToDo> GetAllList()
        {
            return _context.ToDo.ToList();
        }

        public async Task<List<ToDo>> GetAllListByUserId(string id)
        {
            var lists = await _context.ToDo
                .Where(x=>x.AppUserId == id)
                .ToListAsync();
            return lists;
        }

        public string GenerateTokenString(LoginViewModel user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.UserName),
                new Claim(ClaimTypes.Role,"admin")
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Key").Value));

            var signinCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer:_configuration.GetSection("JWT:Issuer").Value,
                audience:_configuration.GetSection("JWT:Audience").Value,

                signingCredentials: signinCred
                
                );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
