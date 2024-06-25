using System;
using System.Collections.Generic;

namespace ShopWave.Entities;

public partial class Patient
{
    public int PatientId { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string MobileNo { get; set; } = null!;
}
