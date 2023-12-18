using IdentityPractice.Models;

namespace ToDoApp.ViewModels
{
    public class CreateListViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime Deadline { get; set; }
        public string? ImageUrl { get; set; }
        public string? AppUserId { get; set; }
    }
}
