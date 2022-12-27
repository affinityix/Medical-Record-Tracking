﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverline.Core.Entities;

public class TestHeader
{
    [Key]
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public DateTime OrderedDate { get; set; }

    public string PaymentStatus { get; set; }

    public float TotalAmount { get; set; }

    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }
}
