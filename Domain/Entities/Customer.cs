using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class Customer
{
    [Key]
    public Guid ID { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public short? Age { get; set; }

    public string? Email { get; set; }

    public bool? IsActive { get; set; }
}
