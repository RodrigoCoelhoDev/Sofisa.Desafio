using System.Collections.Generic;

namespace Sofisa.Desafio.Models
{
    public class RepositorioProcura
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<Repositorio> items { get; set; } = new List<Repositorio>();
    }
}
