﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace QuanLyTourDuLichBE.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<UserRole> UserRole { get; set; } = new List<UserRole>();
}