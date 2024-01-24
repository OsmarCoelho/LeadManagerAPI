using System;

namespace LeadManagerAPI.Entities
{
	public class Lead
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

        public Lead() { }

        public Lead(
            int _Id,
            float _Price,
            string _FirstName,
            string _Surname,
            string _Category,
            string _Description,
            string _Email,
            string _PhoneNumber,
            string _Suburb,
            int _Number,
            bool _Accepted
        )
        {
            Id = _Id;
            Price = _Price;
            FirstName = _FirstName;
            Surname = _Surname;
            Category = _Category;
            Description = _Description;
            Email = _Email;
            PhoneNumber = _PhoneNumber;
            Suburb = _Suburb;
            Number = _Number;
            Accepted = _Accepted;
        }
    }
}

