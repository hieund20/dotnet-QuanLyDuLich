﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace QuanLyTourDuLichBE.Models;

public partial class Tour
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal PriceAdult { get; set; }

    public decimal PriceChild { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();

    public virtual ICollection<TourImage> TourImage { get; set; } = new List<TourImage>();
}