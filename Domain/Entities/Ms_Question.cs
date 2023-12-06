using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class Ms_Question
{
    [Key]
    public Guid ID { get; set; }

    public string Question { get; set; } = null!;

    public string? Answer { get; set; }

    public string? FieldSelect { get; set; }

    [StringLength(10)]
    public string LevelCode { get; set; } = null!;

    [StringLength(10)]
    public string ChannelCode { get; set; } = null!;

    [StringLength(10)]
    public string ProductTypeCode { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [StringLength(20)]
    public string CreateBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    [StringLength(20)]
    public string? UpdateBy { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string IsActive { get; set; } = null!;
}
