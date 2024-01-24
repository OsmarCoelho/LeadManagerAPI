using System;

namespace LeadManagerAPI.Entities
{
	public class Lead : LeadModel
	{ 
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

