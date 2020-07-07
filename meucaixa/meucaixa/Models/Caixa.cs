﻿using System;
using System.Collections.Generic;

namespace meucaixa.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public DateTime DataCaixa { get; set; }
        public string Notas2 { get; set; }
        public int TotalNotas2 { get; set; }
        public string Notas5 { get; set; }
        public int TotalNotas5 { get; set; }
        public string Notas10 { get; set; }
        public int TotalNotas10 { get; set; }
        public string Notas20 { get; set; }
        public int TotalNotas20 { get; set; }
        public string Notas50 { get; set; }
        public int TotalNotas50 { get; set; }
        public string Notas100 { get; set; }
        public int TotalNotas100 { get; set; }
        public string ValorAberturaNovoCaixa { get; set; }
        public string Total { get; set; }
        public string TotalMenosDespesas { get; set; }
        public string TotalMenosDespesasMenosProximoCaixa { get; set; }
        public string TotalCielo { get; set; }
        public string TotalStelo { get; set; }
        public List<Despesa> Despesas { get; set; }
    }
}
