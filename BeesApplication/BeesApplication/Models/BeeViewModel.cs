using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeesApplication.Models
{
    public class BeeViewModel
    {
        public string reference { get; set; }
        public string type { get; set; }
        public string imageURL { get; set; }
        public float health { get; set; }
        public bool dead { get; set; }
    }
}
