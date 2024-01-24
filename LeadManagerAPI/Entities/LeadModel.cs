using System;
namespace LeadManagerAPI.Entities
{
	public class LeadModel
	{
        public int Id { get; set; }
        public float Price { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Suburb { get; set; }
        public int Number { get; set; }
        public bool Accepted { get; set; }
    }
}

