using System.ComponentModel.DataAnnotations;

namespace Ensek.Smart.Data.Model
{

    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [Timestamp]
        public required byte[] Version { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}