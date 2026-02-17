using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlimStesiMvc.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Year { get; set; }
    public string? Photo { get; set; }
}
