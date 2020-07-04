using System;
using System.Collections.Generic;

namespace meucaixa.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public DateTime DataCaixa { get; set; }
        public int Notas2 { get; set; }
        public int TotalNotas2 { get; set; }
        public int Notas5 { get; set; }
        public int TotalNotas5 { get; set; }
        public int Notas10 { get; set; }
        public int TotalNotas10 { get; set; }
        public int Notas20 { get; set; }
        public int TotalNotas20 { get; set; }
        public int Notas50 { get; set; }
        public int TotalNotas50 { get; set; }
        public int Notas100 { get; set; }
        public int TotalNotas100 { get; set; }
        public decimal ValorAberturaCaixa { get; set; }
        public decimal Total { get; set; }
        public decimal TotalMenosDespesas { get; set; }
        public decimal TotalMenosDespesasMenosProximoCaixa { get; set; }
        public decimal TotalCielo { get; set; }
        public decimal TotalStelo { get; set; }
        public List<Despesa> Despesas { get; set; }
    }
}
