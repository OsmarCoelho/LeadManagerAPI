using System;
namespace LeadManagerAPI.Entities
{
	public class Lead
	{
        public int Id { get; set; }
        public float Price { get; set; }
        public string FirstName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool Accepted { get; set; }
        public DateTime CreatedDate { get; set; }
        public Address Address { get; set; }
	}
}

