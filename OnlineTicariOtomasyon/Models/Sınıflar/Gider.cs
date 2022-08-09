﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama{ get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar{ get; set; }
    }
}