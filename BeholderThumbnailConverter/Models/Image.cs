using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeholderThumbnailConverter.Models
{

    [Table("Beholder.Image")]
    public partial class Image
    {

        public int Id { get; set; }

        public Guid FileStreamID { get; set; }

        public int MimeTypeId { get; set; }

        public int? ConfidentialityTypeId { get; set; }

        [Column("IMAGE")]
        public byte[] IMAGE1 { get; set; }

        [Column("Thumbnail")]
        public byte[] Thumbnail { get; set; }

        public virtual MimeType MimeType { get; set; }
        public virtual ICollection<MediaImage> MediaImages { get; set; }
    }
}

