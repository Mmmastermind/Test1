﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeModul
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public int PreparationTime { get; set; }
        public string Type { get; set; }
        public string Difficulty { get; set; }
    }
}
