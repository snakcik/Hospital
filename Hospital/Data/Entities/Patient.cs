﻿using Hospital.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Data.Entities
{
    public class Patient:PersonBase
    {
        public string Illness { get; set; }
        public string Diagnosis { get; set; }
        public string PoliclinicId { get; set; }
        public string PersonellId { get; set; }

        public Policlinic Policlinic { get; set; }
        public Personell Personell { get; set; }
        public ICollection<Prescription> Prescription { get; set; }
       

  
    }
}
