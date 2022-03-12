using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExcepctionValidation.When(id < 0, "Invalid Id value");
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExcepctionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExcepctionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExcepctionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Descrption is required");

            DomainExcepctionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 3 characters");

            DomainExcepctionValidation.When(price < 0,
                "Invalid price value");

            DomainExcepctionValidation.When(stock < 0,
                "Invalid stock value");

            DomainExcepctionValidation.When(image.Length > 250,
                "Invalid image, too long, maximum 250 characters");
        }
    }
}
