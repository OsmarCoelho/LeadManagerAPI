using System;
using System.Security.Cryptography;
using LeadManagerAPI.Entities;

namespace LeadManagerAPI.Services
{
	public class LeadService
	{
		private float DiscountPercentage  = 0.9F;

        public LeadService() { }

        public LeadService(float _DiscountPercentage) {
            DiscountPercentage = _DiscountPercentage;
        }

        public Lead AcceptLead(Lead _Lead) {
            var _Price = this.CalculateNewPrice(_Lead.Price);

            var newLead = new Lead(
                _Lead.Id,
                _Price,
                _Lead.FirstName,
                _Lead.Surname,
                _Lead.Category,
                _Lead.Description,
                _Lead.Email,
                _Lead.PhoneNumber,
                _Lead.Suburb,
                _Lead.Number,
				true
            );

			return newLead;
        }

		private float CalculateNewPrice(float _Price) {
            if (_Price >= 500)
            {
                return _Price * DiscountPercentage;
            }
            else
            {
                return _Price;
            }
        }
	}
}

