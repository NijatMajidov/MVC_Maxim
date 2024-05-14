using Maxim.Business.Exceptions;
using Maxim.Business.Services.Abstracts;
using Maxim.Core.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Maxim.NET_v6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public IActionResult Index()
        {
            var services = _serviceService.GetAllServices();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service service) 
        {
            if(!ModelState.IsValid) return View();

            try
            {
                _serviceService.CreateService(service);
            }
            catch(FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(DuplicateServiceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existService = _serviceService.GetService(x=>x.Id == id);
            if (existService == null) return NotFound();
            return View(existService);
        }
        [HttpPost]
        public IActionResult DeleteService(int id) 
        {
            var existService = _serviceService.GetService(x => x.Id == id);
            if (existService == null) return NotFound();
            try
            {
                _serviceService.DeleteService(id);
            }catch(Business.Exceptions.FileNotFoundException ex)
            {
                
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return RedirectToAction("Index");
        }
    }
}
