using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeholderThumbnailConverter.Models
{
    [Table("Beholder.MediaImage")]
    public partial class MediaImage
    {

        public int Id { get; set; }
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }
        [Display(Name = "Image Type")]
        public int? ImageTypeId { get; set; }
        [Display(Name = "Image Title")]
        public string ImageTitle { get; set; }
        [Display(Name = "Photographer/Artist")]
        [RegularExpression(@"^([a-zA-Z]+\s)*[a-zA-Z]+$", ErrorMessage = "Enter a valid Photgrapher/Artist. Letter characters only")]
        public string PhotographerArtist { get; set; }
        [Display(Name = "Date Published")]
        public DateTime? DatePublished { get; set; }
        [Display(Name = "Roll/Frame Number")]
        //[Range(0, int.MaxValue, ErrorMessage = "Enter valid number.")]
        public string RollFrameNumber { get; set; }
        [Display(Name = "News Source")]
        public int? NewsSourceId { get; set; }
        [Display(Name = "Contact/Owner")]
        public string ContactOwner { get; set; }
        [Display(Name = "Movement Class")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        [Required(ErrorMessage = "Select a valid Confidentiality Type")]
        public int ConfidentialityTypeId { get; set; }
        [Display(Name = "Renewal Date")]
        public DateTime? DateRenewalPermission { get; set; }
        [Display(Name = "Renewal Permission Type")]
        public int? RenewalPermissionTypeId { get; set; }
        [Display(Name = "Renewal Permission")]
        public string RenewalPermission { get; set; }
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "City contains invalid characters.")]
        public string City { get; set; }
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "County contains invalid characters.")]
        public string County { get; set; }
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Display(Name = "Batch Sort Order")]
        public int? BatchSortOrder { get; set; }
        [Display(Name = "File Name")]
        public string ImageFileName { get; set; }
        [Display(Name = "Date Taken")]
        public DateTime? DateTaken { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }
        [Display(Name = "Image")]
        public int? ImageId { get; set; }
        [Display(Name = "Catalog Id")]
        public string CatalogId { get; set; }

        public virtual ICollection<ChapterMediaImageRel> ChapterMediaImageRels { get; set; }
    }
}
