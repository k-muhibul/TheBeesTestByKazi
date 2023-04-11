using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeesApplication.Models
{
   public interface IBee
    {
        string reference { get; set; }
        string Type { get;}
        string ImageURL { get; }
        float Health { get; }
        bool Dead { get; }
        public void Damage(int percentage);
    }
}
