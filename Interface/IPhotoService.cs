using CloudinaryDotNet.Actions;

namespace ToDoApp.Interface
{
    public interface IPhotoService
    {
        public string AddPhotoAsync(IFormFile file);
        public Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
