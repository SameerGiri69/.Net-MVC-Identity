using IdentityPractice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApp;
using ToDoApp.Interface;
using ToDoApp.ViewModels;

namespace IdentityPractice.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoListService _service;
        private readonly IPhotoService _photoService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpcontext;

        public ToDoController(IToDoListService service, IPhotoService photoService, UserManager<AppUser> userManager, IHttpContextAccessor context)
        {
            _service = service;
            _photoService = photoService;
            _userManager = userManager;
            _httpcontext = context;
        }
        public IActionResult Index()
        {
            var lists = _service.GetAllList();
            return View(lists);
        }
        public IActionResult Detail(int id)
        {
            var lists = _service.GetList(id);
            return View(lists);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateListViewModel lists)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            else
            {
                if (lists.Image != null)
                {
                    var imageResult = _photoService.AddPhotoAsync(lists.Image);
                    var newToDo = new ToDo()
                    {
                        Id = lists.Id,
                        Title = lists.Title,
                        Description = lists.Description,
                        Deadline = lists.Deadline,
                        ImageUrl = imageResult,
                    };
                    _service.AddList(newToDo);
                    return View("Detail", newToDo);
                }
                else
                {
                    var newToDo = new ToDo()
                    {
                        Id = lists.Id,
                        Title = lists.Title,
                        Description = lists.Description,
                        Deadline = lists.Deadline,
                    };
                    _service.AddList(newToDo);
                    return View("Detail", newToDo);
                }
            }

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _service.GetList(id);
            UpdateListViewModel newToDo = new UpdateListViewModel()
            {
                Title = result.Title,
                Description = result.Description,
                Deadline = result.Deadline,
            };
            return View(newToDo);
        }
        [HttpPost]
        public IActionResult Update(UpdateListViewModel lists)
        {
            if (lists.Image != null)
            {
                var photoResult = _photoService.AddPhotoAsync(lists.Image);
                ToDo newToDo = new ToDo()
                {
                    Id = lists.Id,
                    Title = lists.Title,
                    Description = lists.Description,
                    Deadline = lists.Deadline,
                    ImageUrl = photoResult,
                };
                _service.UpdateList(newToDo);
                newToDo.ImageUrl = photoResult;
                return View("Detail", newToDo);
            }
            else
            {
                ToDo newToDo = new ToDo()
                {
                    Id = lists.Id,
                    Title = lists.Title,
                    Description = lists.Description,
                    Deadline = lists.Deadline,
                };
                _service.UpdateListNoPhoto(newToDo);
                var image = _service.GetList(lists.Id);
                newToDo.ImageUrl = image.ImageUrl;
                return View("Detail", newToDo);
            }

        }

        public IActionResult Delete(int id)
        {
            var result = _service.DeleteList(id);
            return View("Delete");
        }
    }

}

