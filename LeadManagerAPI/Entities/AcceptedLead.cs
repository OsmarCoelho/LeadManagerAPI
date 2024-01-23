using System;
namespace LeadManagerAPI.Entities
{
	public class AcceptedLead
	{
		public Lead Lead { get; set; }
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

