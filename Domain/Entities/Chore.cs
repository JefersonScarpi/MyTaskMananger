using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Chore : Entity
    {       
        public string Title { get; private set; }
        public string Description { get; private set; }
        
        public bool Complete { get; private set; }

        public int ListIndexId { get; set; }
        public ListIndex ListIndex { get; set; }

        public Chore(string title, string description, bool complete)
        {
            ValidateDomain(title, description);
            Complete = complete;
        }

        public Chore(int id, string title, string description, bool complete)
        {
            DomainExceptionValidation.When(id < 0,"Invalid Id");
            Id = id;
            ValidateDomain(title, description);
            Complete = complete;
        }

        public void Update(string title, string description, int listId, bool complete)
        {
            
            Complete = complete;
            ListIndexId = listId;
            ValidateDomain(title, description);
        } 

        public void ValidateDomain(string title, string description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title),
                "Invalid title. Title is required");


            DomainExceptionValidation.When(title.Length < 3 || title.Length > 20,
                "Invalid title, too short, minimum 3 and maximum 20 characters");
            //--------------------------------------------------------------------

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");


            DomainExceptionValidation.When(description.Length < 3 || description.Length > 100,
                "Invalid description, too short, minimum 3 and maximum 100 characters");
            Title = title;
            Description = description;

        }
    }
}
