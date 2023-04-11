using BeesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeesApplication.Services
{
    public class BeeDataService
    {
        private List<IBee> bees = new List<IBee>();
        public BeeDataService()
        {
            for (var i = 0; i < 10; i++)
            {
                bees.Add(new QueenBee(new Random().Next(0, 1000000).ToString("D6")));
                bees.Add(new WorkerBee(new Random().Next(0, 1000000).ToString("D6")));
                bees.Add(new DroneBee(new Random().Next(0, 1000000).ToString("D6")));
            }
        }

        public List<IBee> getBees()
        {
            return this.bees;
        }
        public void restart()
        {
            List<IBee> dup = new List<IBee>(this.bees);
            foreach(var i in dup)
            {
                var refNo= i.reference;
                this.bees.Remove(i);
                bees.Add(this.createBEE(i.Type));
            }
        }

        public IBee createBEE(string type)
        {
            switch (type)
            {
                case "Queen":
                    return new QueenBee(new Random().Next(0, 1000000).ToString("D6") );
                case "Worker":
                    return new WorkerBee(new Random().Next(0, 1000000).ToString("D6"));
                case "Drone":
                    return new DroneBee(new Random().Next(0, 1000000).ToString("D6"));
                default:
                    return null;
            }
        }

    }
}
