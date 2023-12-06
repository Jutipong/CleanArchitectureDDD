using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class VerifyQuestion
{
    [Key]
    public Guid ID { get; set; }

    public int Running { get; set; }

    public Guid VerifyCustomerID { get; set; }

    [StringLength(10)]
    public string? LevelCode { get; set; }

    public Guid? QuestionID { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }

    public bool? Result { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [StringLength(20)]
    public string CreateBy { get; set; } = null!;
}
