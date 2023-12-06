using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class Ms_TopicType
{
    [Key]
    public Guid ID { get; set; }

    [StringLength(10)]
    public string Code { get; set; } = null!;

    [StringLength(150)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [StringLength(20)]
    public string CreateBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    [StringLength(20)]
    public string? UpdateBy { get; set; }

    public int? Order { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string IsActive { get; set; } = null!;
}
