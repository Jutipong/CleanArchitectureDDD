using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Keyless]
public partial class vEmployee
{
    [StringLength(6)]
    [Unicode(false)]
    public string Emp_Code { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? TH_Name { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ADUser { get; set; }
}
