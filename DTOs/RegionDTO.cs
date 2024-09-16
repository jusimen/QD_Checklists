﻿using System.ComponentModel.DataAnnotations;

namespace QD_Checklists.DTOs
{
    public class RegionDTO
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
