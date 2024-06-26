using System;
using System.Collections.Generic;

namespace SemaineDevOps.Models;

public partial class Question
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int CategorieId { get; set; }

    public virtual Categorie Categorie { get; set; } = null!;

    public virtual ICollection<Point> Points { get; set; } = new List<Point>();

    public virtual ICollection<Regrouper> Regroupers { get; set; } = new List<Regrouper>();

    public virtual ICollection<Reponse> Reponses { get; set; } = new List<Reponse>();
}
