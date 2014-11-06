using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeholderThumbnailConverter.Models
{
    [Table("Beholder.ChapterMediaImageRel")]
    public partial class ChapterMediaImageRel
    {
        [Key]
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public int MediaImageId { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? DateStart { get; set; }
        [Display(Name = "End Date")]
        public DateTime? DateEnd { get; set; }
        [Display(Name = "Relationship Type")]
        public int? RelationshipTypeId { get; set; }
        [Display(Name = "Approval Status")]
        public int? ApprovalStatusId { get; set; }
        [Display(Name = "Primary Status")]
        public int? PrimaryStatusId { get; set; }

        //[Display(Name = "Approval Status")]
        //public virtual ApprovalStatus ApprovalStatus { get; set; }
        //public virtual Chapter Chapter { get; set; }
        [Display(Name = "Image")]
        public virtual MediaImage MediaImage { get; set; }
        //[Display(Name = "Primary Status")]
        //public virtual PrimaryStatus PrimaryStatus { get; set; }
        //[Display(Name = "Relationship Type")]
        //public virtual RelationshipType RelationshipType { get; set; }
    }
}
