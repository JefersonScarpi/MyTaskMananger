using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validation;

namespace Domain.Entities
{
    public sealed class ListIndex : Entity   
    {        
        public string Name { get; private set; }

        public ICollection<Chore> Chores { get; set; }

        public ListIndex(string name)
        {
            ValidateDomain(name);

        }

        public ListIndex(int id, string name)
        {
            DomainExceptionValidation.When(id < 0,"Invalid Id value");
            Id = id;
            ValidateDomain(name);     
        }

        public void Update(string name)
        {
            ValidateDomain(name);

        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid name. Name is required");


            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 charecters");

            Name = name;

        }


    }
}
