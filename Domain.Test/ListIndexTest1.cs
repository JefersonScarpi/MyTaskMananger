using Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Test
{
    public class ListIndexTest1
    {
        [Fact(DisplayName = "Create ListIndex with Valid State")]
        public void CreateListIndex_WithValidParameters_ResusltObjectValidState()
        {
            Action action = () => new ListIndex(1, "ListIndex name");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create ListIndex with Invalid State")]
        public void CreateListIndex_WithValidParameters_ResusltObjectInvalidState()
        {
            Action action = () => new ListIndex(-1, "ListIndex name");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateListIndex_ShortNameValue_DomainExceptionShorName()
        {
            Action action = () => new ListIndex(1, "ca");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 charecters");
        }

        [Fact]
        public void CreateListIndex_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new ListIndex(1, "");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateListIndex_MissingNameValue_DomainExceptionNullValue()
        {
            Action action = () => new ListIndex(1, null);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>();
        }
    }
}
