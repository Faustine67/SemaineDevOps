using System;
using System.Collections.Generic;

namespace SemaineDevOps.Models;

public partial class Entreprise
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? Domaine { get; set; }

    public string? Adresse { get; set; }

    public int Cp { get; set; }

    public string Ville { get; set; } = null!;

    public virtual ICollection<Regrouper> Regroupers { get; set; } = new List<Regrouper>();
}
