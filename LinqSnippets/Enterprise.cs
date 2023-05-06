namespace LinqSnippets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Enterprise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Employe[] Employes { get; set; } = new Employe[0];
    }
}
