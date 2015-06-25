using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using Minutrade.ECommerce.CommonObjects.RestFullRequests;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.WebApp.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IEnumerable<ClientDto> _clientList = RestRequests.Get<List<ClientDto>>(ConfigurationManager.AppSettings["ApiUrl"], "api/Clients");

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var phones = RestRequests.Get<List<PhoneDto>>(ConfigurationManager.AppSettings["ApiUrl"], "api/Phones");
            return View(phones);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_clientList, "Id", "Cpf");
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ClientId,CodArea,Number")] PhoneDto phoneDto)
        {
            if (ModelState.IsValid)
            {
                RestRequests.Post(ConfigurationManager.AppSettings["ApiUrl"], "api/Phones", phoneDto);

                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientList, "Id", "Cpf", phoneDto.ClientId);

            return View(phoneDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var phone = RestRequests.Get<PhoneDto>(ConfigurationManager.AppSettings["ApiUrl"], "api/Phones/" + id);
            
            if (phone == null)
                return HttpNotFound();
            
            ViewBag.ClientId = new SelectList(_clientList, "Id", "Cpf", phone.ClientId);
            
            return View(phone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ClientId,CodArea,Number")] PhoneDto phoneDto)
        {
            if (ModelState.IsValid)
            {
                RestRequests.Put(ConfigurationManager.AppSettings["ApiUrl"], "api/Phones/", phoneDto, phoneDto.Id);

                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientList, "Id", "Cpf", phoneDto.ClientId);

            return View(phoneDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var phone = RestRequests.Get<PhoneDto>(ConfigurationManager.AppSettings["ApiUrl"], "api/Phones/" + id);
            
            if (phone == null)
                return HttpNotFound();
            
            return View(phone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RestRequests.Delete(ConfigurationManager.AppSettings["ApiUrl"], "api/Phones/", id);

            return RedirectToAction("Index");
        }
    }
}