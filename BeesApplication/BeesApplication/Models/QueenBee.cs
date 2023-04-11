using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeesApplication.Models
{
    public class QueenBee : IBee

    {
        public string reference { get; set; }
        public string Type { get; } = "Queen";
        public string ImageURL { get; } = "./images/queenBee.png";
        private float health = 100;
        public float Health => health;
        public bool Dead { get
            {
                if(this.health<20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } }
        public QueenBee(string reference)
        {
            this.reference = reference;
        }
        public void Damage (int percentage)
        {
            if (this.Dead == true) { return; }
            if (percentage<0 || percentage > 100)
            {
                throw new ArgumentException("Damage percentage has to be in range of 0 to 100");
            }
            float damage = this.health * percentage / 100f;
            health -= damage;
        }
    }
}
