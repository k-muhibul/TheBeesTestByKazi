using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeesApplication.Models
{
    public class WorkerBee:IBee
    {
        public string reference { get; set; }
        public string Type { get; } = "Worker";
        public string ImageURL { get; } = "./images/workerBee.png";
        private float health = 100;
        public float Health => health;
        public bool Dead
        {
            get
            {
                if (this.health <70)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public WorkerBee(string reference)
        {
            this.reference = reference;
        }
        public void Damage(int percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentException("Damage percentage has to be in range of 0 to 100");
            }
            if (this.Dead == true) { return; }
            float damage = this.health * percentage / 100f;
            health -= damage;
           
        }
    }
}
