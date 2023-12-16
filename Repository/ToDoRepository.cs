using IdentityPractice.Data;
using IdentityPractice.Models;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Interface;

namespace ToDoApp.Repository
{
    public class ToDoRepository : IToDoListService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;

        public ToDoRepository(ApplicationDbContext context, IPhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
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

        public List<ToDo> GetAllListByUserId(string id)
        {
            var lists =  _context.ToDo.Where(x => x.User.Id.ToString() == id).ToList();
            return lists;
        }
    }
}
