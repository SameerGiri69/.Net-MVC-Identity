using IdentityPractice.Models;

namespace ToDoApp.ViewModels
{
    public class UpdateListViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime Deadline { get; set; }
        public AppUser? User { get; set; }
    }
}
