using AutoMapper;
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
        private readonly IMapper _mapper;

        public ToDoController(IToDoListService service, IPhotoService photoService, UserManager<AppUser> userManager, 
            IHttpContextAccessor context, IMapper mapper)
        {
            _service = service;
            _photoService = photoService;
            _userManager = userManager;
            _httpcontext = context;
            _mapper = mapper;
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
        public IActionResult Create(CreateListViewModel listsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            
            else
            {
                if (listsViewModel.Image != null)
                {
                    listsViewModel.ImageUrl = _photoService.AddPhotoAsync(listsViewModel.Image);
                    var toDoMapped = _mapper.Map<ToDo>(listsViewModel);
                    _service.AddList(toDoMapped);
                    return View("Detail", toDoMapped);
                }
                else
                {
                    var autoMapped = _mapper.Map<ToDo>(listsViewModel);
                    _service.AddList(autoMapped);
                    return View("Detail", autoMapped);
                }
            }

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _service.GetList(id);
            var mapped = _mapper.Map<UpdateListViewModel>(result);
            
            return View(mapped);
        }
        [HttpPost]
        public IActionResult Update(UpdateListViewModel listsViewModel)
        {
            if (listsViewModel.Image != null)
            {
                listsViewModel.ImageUrl = _photoService.AddPhotoAsync(listsViewModel.Image);
                var mapped = _mapper.Map<ToDo>(listsViewModel);

                _service.UpdateList(mapped);
                
                return View("Detail", mapped);
            }
            else
            {
                var mapped = _mapper.Map<ToDo>(listsViewModel);
                _service.UpdateListNoPhoto(mapped);
                var image = _service.GetList(listsViewModel.Id);
                mapped.ImageUrl = image.ImageUrl;
                return View("Detail", mapped);
            }

        }

        public IActionResult Delete(int id)
        {
            var result = _service.DeleteList(id);
            return View("Delete");
        }
    }

}

