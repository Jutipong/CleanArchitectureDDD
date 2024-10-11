using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Keyless]
public partial class DBD_Log
{
    public Guid id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? applicationId { get; set; }

    [Column(TypeName = "text")]
    public string? requestData { get; set; }

    [Column(TypeName = "text")]
    public string? reponseData { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? createdate { get; set; }
}
