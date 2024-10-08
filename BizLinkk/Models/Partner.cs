using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BizLinkk.Models;

public partial class Partner
{
    [Key]
    [Column("Partner_id")]
    public int PartnerId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string RegistrationNo { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? VatRegNo { get; set; }

    [Column("rcoc")]
    [StringLength(30)]
    [Unicode(false)]
    public string Rcoc { get; set; } = null!;

    [Column("rcoe")]
    [StringLength(30)]
    [Unicode(false)]
    public string Rcoe { get; set; } = null!;

    [Column("rctc", TypeName = "datetime")]
    public DateTime Rctc { get; set; }

    [Column("rcte", TypeName = "datetime")]
    public DateTime Rcte { get; set; }
}
