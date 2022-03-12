using CleanArchMvc.Domain.Entities;
using Xunit;
using FluentAssertions;
using System;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParamters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<Validation.DomainExcepctionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_NegativeIdValue_DomainExcepctionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Invalid Name")]
        public void CreateCategory_MissingNameValue_DomainExcepctionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Category With Short Name Value")]
        public void CreateCategory_ShortNameValue_DomainExcepctionShortName()
        {
            Action action = () => new Category(1, "te");
            action.Should()
                .Throw<Validation.DomainExcepctionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }
    }
}