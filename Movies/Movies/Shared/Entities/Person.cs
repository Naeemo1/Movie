﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Shared.Entities
{
    [Table(nameof(Person))]
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        [NotMapped]
        public List<string> Picture { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }

        public List<MoviesActors> MoviesActors { get; set; } = new List<MoviesActors>();

        [NotMapped]
        public string Character { get; set; }
    }
}
