﻿using LokusAPI.Models;

namespace LokusAPI.Dtos.SpaceDtos
{
    public class SpaceUpdateDto
    {
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public PriceEnum PriceEnum { get; set; }
    }
}
