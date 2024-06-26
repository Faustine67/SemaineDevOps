using System;
using System.Collections.Generic;

namespace SemaineDevOps.Models;

public partial class Reponse
{
    public int Id { get; set; }

    public int Score { get; set; }

    public string? Commentaire { get; set; }

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<Regrouper> Regroupers { get; set; } = new List<Regrouper>();
}
