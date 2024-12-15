﻿using System.ComponentModel.DataAnnotations;

namespace WaterLogger.Dejmenek.Models;

public class DrinkingWaterModel
{
    public int Id { get; set; }
    [Range(0, Double.MaxValue, ErrorMessage = "Value for {0} must be positive.")]
    public double Quantity { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
}
