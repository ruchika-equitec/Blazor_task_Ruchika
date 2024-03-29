﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models;

public partial class StudTable
{
    public int StudentId { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Age is required.")]
    public int? Age { get; set; }
    [Required(ErrorMessage = "Fees is required.")]
    public int? Fees { get; set; }
    [Required(ErrorMessage = "Gender is required.")]
    public string Gender { get; set; }

    public bool IsDeleted { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    public string EmailId { get; set; }
    [Required(ErrorMessage = "Skills is required.")]
    public string Skills { get; set; }

    public virtual ICollection<SkillsTable> SkillsNavigation { get; set; } = new List<SkillsTable>();
}