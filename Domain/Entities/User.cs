using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Users")]
    public class User : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "E-mail address is required.")]
        [MaxLength(320, ErrorMessage = "E-mail address must not exceed 320 characters.")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "Firs tName must not exceed 50 characters.")]
        public string? FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Last Name must not exceed 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(1000, ErrorMessage = "Password must not exceed 1000 characters.")]
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }

        public User() { }
        public User (int id, string email, string firstName, string lastName, string passwordHash)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PasswordHash = passwordHash;
            RoleId = RoleId;
        }
    }
}
