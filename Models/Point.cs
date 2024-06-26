using System;
using System.Collections.Generic;

namespace SemaineDevOps.Models;

public partial class Point
{
    public int Id { get; set; }

    public int Valeur { get; set; }

    public string Descriptif { get; set; } = null!;

    public int? QuestionId { get; set; }

    public virtual Question? Question { get; set; }
}
