﻿using System.ComponentModel.DataAnnotations;

namespace Court_Of_Justice.Models
{
    public class CaseSource
    {
        public int ID { get; set; }
        [MinLength(5)]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}