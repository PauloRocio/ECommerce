using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using Minutrade.ECommerce.CommonObjects.RestFullRequests;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.WebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IEnumerable<StateDto> _statesList               = RestRequests.Get<List<StateDto>>(ConfigurationManager.AppSettings["ApiUrl"], "api/States");
        private readonly IEnumerable<MaritalStatuDto> _maritalStatusList = RestRequests.Get<List<MaritalStatuDto>>(ConfigurationManager.AppSettings["ApiUrl"], "api/MaritalStatus");

        // GET: Clients
        public ActionResult Index()
        {
            var clients = RestRequests.Get<List<ClientDto>>(ConfigurationManager.AppSettings["ApiUrl"], "api/Clients");
            return View(clients);
        }

        // GET: Clients/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var client = RestRequests.Get<ClientDto>(ConfigurationManager.AppSettings["ApiUrl"], "api/Clients/" + id);
            
            if (client == null)
                return HttpNotFound();
            
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(_statesList, "id", "StatesName");
            ViewBag.MaritalStatusId = new SelectList(_maritalStatusList, "id", "MaritalStatus");

            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaritalStatusId,StateId,Cpf,Name,Email,Street,Neighborhood,Number,CEP,Complement,ReferenceInformation")] ClientDto clientDto)
        {
            if (ModelState.IsValid)
            {
                RestRequests.Post(ConfigurationManager.AppSettings["ApiUrl"], "api/Clients", clientDto);

                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(_statesList, "id", "StatesName", clientDto.StateId);
            ViewBag.MaritalStatusId = new SelectList(_maritalStatusList, "id", "MaritalStatus", clientDto.MaritalStatusId);

            return View(clientDto);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var client = RestRequests.Get<ClientDto>(ConfigurationManager.AppSettings["ApiUrl"], "api/Clients/" + id);
            
            if (client == null)
                return HttpNotFound();

            ViewBag.StateId = new SelectList(_statesList, "id", "StatesName", client.StateId);
            ViewBag.MaritalStatusId = new SelectList(_maritalStatusList, "id", "MaritalStatus", client.MaritalStatusId);

            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaritalStatusId,StateId,Cpf,Name,Email,Street,Neighborhood,Number,CEP,Complement,ReferenceInformation")] ClientDto clientDto)
        {
            if (ModelState.IsValid)
            {
                RestRequests.Put(ConfigurationManager.AppSettings["ApiUrl"], "api/Clients/", clientDto, clientDto.Id);

                return RedirectToAction("Index");
            }


            ViewBag.StateId         = new SelectList(_statesList, "id", "StatesName", clientDto.StateId);
            ViewBag.MaritalStatusId = new SelectList(_maritalStatusList, "id", "MaritalStatus", clientDto.MaritalStatusId);

            return View(clientDto);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var client = RestRequests.Get<ClientDto>(ConfigurationManager.AppSettings["ApiUrl"], "api/Clients/" + id);
            
            if (client == null)
                return HttpNotFound();
            
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RestRequests.Delete(ConfigurationManager.AppSettings["ApiUrl"], "api/Clients/", id);

            return RedirectToAction("Index");
        }
    }
}
