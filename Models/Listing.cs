﻿using System.ComponentModel.DataAnnotations;

namespace sahibinden_project;

public class Listing
{
    [Key]
    public int Id { get; set; }
    public string? Category { get; set; }
    public string? Title { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public string? ImageFileName { get; set; }

}
