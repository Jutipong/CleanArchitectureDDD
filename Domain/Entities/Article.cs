using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class Article
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(100)]
    public string Content { get; set; } = null!;

    [StringLength(100)]
    public string? Tags { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateOnUtc { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PublishedOnUtc { get; set; }
}
