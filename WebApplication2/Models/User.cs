using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        [AllowNull]
        public DateTime CreatedOn { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}
