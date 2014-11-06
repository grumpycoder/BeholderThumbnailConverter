using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeholderThumbnailConverter.Models
{
    [Table("Persons")]
    public partial class Person
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string Lastname { get; set; }

        [StringLength(250)]
        public string EmailAddress { get; set; }

        [StringLength(8)]
        public string ZipCode { get; set; }

        public bool? IsDonor { get; set; }

        public bool? isPriority { get; set; }
    }
}
