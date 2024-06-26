using System;
using System.Collections.Generic;

namespace SemaineDevOps.Models;

public partial class Categorie
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int AxeId { get; set; }

    public virtual Axe Axe { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
