using Maxim.Business.Exceptions;
using Maxim.Business.Services.Abstracts;
using Maxim.Core.Models;
using Maxim.Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Services.Concretes
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceService(IServiceRepository serviceRepository,IWebHostEnvironment webHostEnvironment)
        {
            _serviceRepository = serviceRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public void CreateService(Service service)
        {
            if (!service.ImageFile.ContentType.Contains("image/"))
                throw new FileContentTypeException("ImageFile","File content type error!");
            if (service.ImageFile.Length > 2097152)
                throw new FileSizeException("ImageFile", "File size error!");
            if (service == null) 
                throw new NullReferenceException("Null service");

            string fileName = Guid.NewGuid().ToString() +Path.GetExtension(service.ImageFile.FileName);
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Services\" + fileName;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                service.ImageFile.CopyTo(stream);
            }

           // if (!_serviceRepository.GetAll().Any(x => x.Title == service.Title))
           // {
                service.ServicesImg = fileName;
                _serviceRepository.Add(service);
                _serviceRepository.Commit();
           // }
           //throw new DuplicateServiceException("Service","Bu servis artiq movcuddur");
        }
        
        public void DeleteService(int id)
        {
            var existService = _serviceRepository.Get(x=>x.Id == id);
            if(existService == null) throw new NullReferenceException("Null service");
           

            string path = _webHostEnvironment + @"\Upload\Services" + existService.ImageFile.FileName;
            if(!File.Exists(path)) throw new Exceptions.FileNotFoundException("ImageFile","File not found!");
            File.Delete(path);

            _serviceRepository.Delete(existService);
            _serviceRepository.Commit();
            
        }

        public List<Service> GetAllServices(Func<Service, bool>? func = null)
        {
            return _serviceRepository.GetAll(func);
        }

        public Service GetService(Func<Service, bool>? func = null)
        {
            return _serviceRepository.Get(func);
        }

        public void UpdateService(int id, Service service)
        {
            
        }
    }
}
