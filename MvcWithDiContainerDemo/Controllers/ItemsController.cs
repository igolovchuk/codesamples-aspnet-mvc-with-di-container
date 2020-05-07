using MvcWithDiContainerDemo.Data.Entities;
using MvcWithDiContainerDemo.Data.Infrastructure;
using MvcWithDiContainerDemo.Providers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWithDiContainerDemo.Controllers
{
    //api/items
   // [Authorize]
    public class ItemsController : ApiController
    {
        IUnitOfWork _unitOfWork;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            //using IOC
            //_unitOfWork = Ioc.Get<IUnitOfWork>();
            //also in startup.cs need to ucomment iocInit method

            // using only Dep Inj
            _unitOfWork = unitOfWork;
        }

        //GET api/items
        [HttpGet]
        public IQueryable<Message> Get()
        {          
                return _unitOfWork.Messages.GetAll();  
        }

        [HttpPost]
        public Message Post(Message model)
        {
            try
            {
                model.DatePosted = DateTime.Now;
                _unitOfWork.Messages.Add(model);
                _unitOfWork.Save();
                return model;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return null;
            }

        }
       
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var message = _unitOfWork.Messages.GetById(id);
                _unitOfWork.Messages.Remove(message);
                _unitOfWork.Save();
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }





    }

}
