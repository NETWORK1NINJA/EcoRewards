using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRewards.Models;

namespace EcoRewards.Services
{
    public class RewardCalculator
    {
        // Calculate reward points
        public decimal CalculatePoints(decimal weight, MaterialType material)
        {
            return weight * material.PointsPerKg;
        }

        // Calculate CO₂ savings
        public decimal CalculateCO2Saved(decimal weight, MaterialType material)
        {
            return weight * material.CO2PerKg;

        }
}   }