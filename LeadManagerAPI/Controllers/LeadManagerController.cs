using System;
using Microsoft.AspNetCore.Mvc;
using LeadManagerAPI.Entities;
using PostgreSQL.Data;
using LeadManagerAPI.Services;

namespace LeadManagerAPI.Controllers
{
    [ApiController]
    [Route("LeadManager/[action]")]
    public class LeadManagerController : ControllerBase
    {

        private readonly ApiDbContext _context;

        public LeadManagerController( ApiDbContext context)
        {
            this._context = context;
        }
        
        [HttpPost]
        public JsonResult CreateLead(Lead lead)
        {
            if(lead.Id == 0)
            {
                _context.Leads.Add(lead);
                _context.SaveChanges();

                return new JsonResult(Ok());
            }
            else
            {
                var leadInDb = _context.Leads.Find(lead.Id);

                if (leadInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                else
                {
                    return new JsonResult(NoContent());
                }
            }
        }

        [HttpPatch]
        public JsonResult EditLead(Lead lead)
        {
            
                var leadInDb = _context.Leads.Find(lead.Id);

                if (leadInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                else
                {
                    _context.Leads.Remove(leadInDb);
                    _context.Leads.Add(lead);
                    _context.SaveChanges();

                return new JsonResult(Ok(lead));
                }
        }

        [HttpGet]
        public JsonResult GetAll()
        {

            var leads = _context.Leads.ToList().OrderBy(lead => lead.Id);
            return new JsonResult(Ok(leads));
            
        }

        [HttpGet]
        public JsonResult GetAllInvites()
        {

            var leads = _context.Leads.ToList()
                .Where(lead => !lead.Accepted && !lead.Rejected)
                .OrderBy(lead => lead.Id);
            return new JsonResult(Ok(leads));

        }

        [HttpGet]
        public JsonResult GetAllAccepted()
        {
            var leads = _context.Leads.ToList()
                .Where(lead => lead.Accepted && !lead.Rejected)
                .OrderBy(lead => lead.Id);

            return new JsonResult(Ok(leads));

        }

        [HttpGet]
        public JsonResult GetById(int Id)
        {
            var lead = _context.Leads.Find(Id);
            return new JsonResult(Ok(lead));

        }

        [HttpPatch]
        public JsonResult AcceptLead(int Id)
        {
            var notification = new NotificationService();
            var leadInDb = _context.Leads.Find(Id);

            if (leadInDb == null || leadInDb.Accepted)
            {
                notification.SendNotification("Proposta já aceita.");
                return new JsonResult(NotFound());
            }
            else
            {
                var newLead = new LeadService().AcceptLead(leadInDb);

                _context.Leads.Remove(leadInDb);
                _context.Leads.Add(newLead);
                _context.SaveChanges();

                notification.SendNotification("Proposta aceita com sucesso.");
                return new JsonResult(Ok(newLead));                
            }
        }

        [HttpPatch]
        public JsonResult DeclineLead(int Id)
        {
            var notification = new NotificationService();
            var leadInDb = _context.Leads.Find(Id);

            if (leadInDb == null || leadInDb.Rejected)
            {
                notification.SendNotification("Proposta já recusada.");
                return new JsonResult(NotFound());
            }
            else
            {
                var newLead = new LeadService().RejectLead(leadInDb);

                _context.Leads.Remove(leadInDb);
                _context.Leads.Add(newLead);
                _context.SaveChanges();

                notification.SendNotification("Proposta recusada.");
                return new JsonResult(Ok(newLead));
            }
        }
    }
}

