using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeholderThumbnailConverter.Models
{
    [Table("Beholder.AddressChapterRel")]
    public partial class AddressChapterRel
    {
        public int Id { get; set; }

        public int ChapterId { get; set; }

        public int AddressId { get; set; }

        public int? AddressTypeId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FirstKnownUseDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastKNownUsedate { get; set; }

        public int PrimaryStatusId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        public int CreatedUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateModified { get; set; }

        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateDeleted { get; set; }

        public int? DeletedUserId { get; set; }

        public virtual Address Address { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}
