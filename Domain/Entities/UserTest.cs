using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class UserTest
{
    /// <summary>
    /// aaaaa
    /// </summary>
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// aaaaaa
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// ccccc
    /// </summary>
    [StringLength(50)]
    public string Last { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [StringLength(50)]
    public string CreateBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    [StringLength(50)]
    public string? UpdateBy { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? IsActive { get; set; }
}
