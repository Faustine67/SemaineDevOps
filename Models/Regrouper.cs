using System;
using System.Collections.Generic;

namespace SemaineDevOps.Models;

public partial class Regrouper
{
    public int Id { get; set; }

    public int EntrepriseId { get; set; }

    public int QuestionId { get; set; }

    public int ReponseId { get; set; }

    public virtual Entreprise Entreprise { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual Reponse Reponse { get; set; } = null!;
}
