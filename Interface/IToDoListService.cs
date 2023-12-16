using IdentityPractice.Models;


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
        List<ToDo> GetAllListByUserId(string id);
    }
}
