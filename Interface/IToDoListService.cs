using IdentityPractice.Models;
using IdentityPractice.ViewModels;


namespace ToDoApp.Interface
{
    public interface IToDoListService
    {
        bool AddList(ToDo toDo);
        ToDo GetList(int id);
        bool UpdateList(ToDo toDo);
        bool UpdateListNoPhoto(ToDo toDo);
        bool DeleteList(int id);
        List<ToDo> GetAllList();
        Task<List<ToDo>> GetAllListByUserId(string id);
        string GenerateTokenString(LoginViewModel user);
    }
}
