using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExcepctionValidation.When(id < 0, "Invalid id value");
            ValidateDomain(name);
        }

        public string ?Name { get; private set; }

        public ICollection<Product>? Products { get; set; }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExcepctionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is required");

            DomainExcepctionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
