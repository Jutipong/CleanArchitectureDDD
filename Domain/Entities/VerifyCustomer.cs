using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class VerifyCustomer
{
    [Key]
    public Guid ID { get; set; }

    [StringLength(10)]
    public string ChannelCode { get; set; } = null!;

    [StringLength(100)]
    public string? PhoneNo { get; set; }

    [StringLength(20)]
    public string? PhoneSendOTP { get; set; }

    [StringLength(20)]
    public string CitizenID_TaxID { get; set; } = null!;

    [Column(TypeName = "decimal(19, 0)")]
    public decimal? CifNo { get; set; }

    [StringLength(10)]
    public string ProductTypeCode { get; set; } = null!;

    [StringLength(10)]
    public string? ServiceTypeCode { get; set; }

    [StringLength(10)]
    public string? TopicTypeCode { get; set; }

    [StringLength(10)]
    public string? CustomerTypeCode { get; set; }

    [StringLength(10)]
    public string EndCallReasonCode { get; set; } = null!;

    [StringLength(20)]
    public string? VerifyTypeCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [StringLength(20)]
    public string CreateBy { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string IsActive { get; set; } = null!;

    [StringLength(20)]
    public string? ResultOfVerify { get; set; }
}
