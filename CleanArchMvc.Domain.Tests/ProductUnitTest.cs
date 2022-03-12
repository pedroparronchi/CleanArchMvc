using CleanArchMvc.Domain.Entities;
using Xunit;
using FluentAssertions;
using System;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParamters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10, 10, "www.testimage.com");
            action.Should()
                .NotThrow<Validation.DomainExcepctionValidation>();
        }

        [Fact(DisplayName = "Create Product With Valid State and No Null Reference Excepction")]
        public void CreateProduct_WithNullImage_NoNullReferenceExcepction()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10, 10, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_NegativeIdValue_DomainExcepctionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 10, 10, "www.testimage.com");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Invalid Name")]
        public void CreateProduct_MissingNameValue_DomainExcepctionInvalidName()
        {
            Action action = () => new Product(1, "", "Product Description", 10.10m, 10, "www.testimage.com");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product With Short Name Value")]
        public void CreateProduct_ShortNameValue_DomainExcepctionShortName()
        {
            Action action = () => new Product(1, "te", "Product Description", 10.10m, 10, "www.testimage.com");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Invalid Description")]
        public void CreateProduct_MissingDescriptionValue_DomainExcepctionInvalidDescription()
        {
            Action action = () => new Product(1, "Product", "", 10.10m, 10, "www.testimage.com");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid description. Descrption is required");
        }

        [Fact(DisplayName = "Create Product With Short Description Value")]
        public void CreateProduct_ShortDescriptionValue_DomainExcepctionShortDescription()
        {
            Action action = () => new Product(1, "Product", "Pr", 10.10m, 10, "www.testimage.com");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product With Invalid Price Value")]
        public void CreateProduct_NegativePriceValue_DomainExcepctionNegativePriceValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -10, 10, "www.testimage.com");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock Value")]
        public void CreateProduct_NegativStockValue_DomainExcepctionNegativStockValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10, -10, "www.testimage.com");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product With Long Image Name")]
        public void CreateProduct_LongImageName_DomainExcepctionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10, 10, "www.testimage.com is tooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid image, too long, maximum 250 characters");
        }
    }
}