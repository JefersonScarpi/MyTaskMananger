using Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Test
{
    public class ChoreTest1
    {
        [Fact]
        public void CreateChore_WithValidParameters_ResusltObjectValidState()
        {
            Action action = () => new Chore("Study english","To improve reading and writing skill", false);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateChore_WithInvalidTitle_DomainExceptionShortTitle()
        {
            Action action = () => new Chore("ca", "To improve reading and writing skill", false);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid title, too short, minimum 3 and maximum 20 characters");
        }

        [Fact]
        public void CreateChore_WithInvalidTitle_DomainException()
        {
            Action action = () => new Chore("", "To improve reading and writing skill", false);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid title. Title is required");
        }


        

        [Fact]
        public void CreateChore_WithInvalidTitle_DomainExceptionNullValue()
        {
            Action action = () => new Chore(null, "To improve reading and writing skill", false);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateChore_WithInvalidDescription_ResusltExceptionShortDescription()
        {
            Action action = () => new Chore("Study english", "cd", false);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 3 and maximum 100 characters");
        }

        [Fact]
        public void CreateChore_WithInvalidDescription_ResusltException()
        {
            Action action = () => new Chore("Study english", "", false);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
        }

        [Fact]
        public void CreateChore_WithInvalidDescription_ResusltExceptionNullValue()
        {
            Action action = () => new Chore("Study english", "", false);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>();
        }
    }
}
