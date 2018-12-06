﻿using ELibrary.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELibrary.Entities.Concrete
{
   public class Books:EntityBase<Guid>
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string BookName { get; set; }
        [StringLength(maximumLength: 4000)]
        public string BookSummary { get; set; }
        public DateTime? EditionDate { get; set; }
        public int NumberPages { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public Guid PublisherId { get; set; }
        public Base64FormattingOptions BooksPhoto { get; set; }
        public override Guid? CreatedBy { get => base.CreatedBy; set => base.CreatedBy = value; }
        public override DateTime? CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }
        public override Guid? ModifiedBy { get => base.ModifiedBy; set => base.ModifiedBy = value; }
        public override DateTime? ModifiedDate { get => base.ModifiedDate; set => base.ModifiedDate = value; }
    }
}
