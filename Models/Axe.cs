using System;
using System.Collections.Generic;

namespace SemaineDevOps.Models;

public partial class Axe
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Categorie> Categories { get; set; } = new List<Categorie>();
}
