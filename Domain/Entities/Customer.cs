using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class Customer
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(20)]
    public string? Code { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    public int? Age { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    public bool? IsActive { get; set; }
}
