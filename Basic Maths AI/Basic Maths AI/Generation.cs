using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Maths_AI
{
    class Generation
    {
        public List<Organism> Organisms;

        public Generation()
        {
            Organisms = new List<Organism>();
        }

        public void AddOrganism(Organism o)
        {
            Organisms.Add(o);
        }

        public void Order(int fitness)
        {
            List<Organism> gen = Organisms.OrderBy(o => o.EvaluateFitness(fitness)).ToList();
            Organisms = gen;
        }

        public int GetAverage(int fitness)
        {
            int ret = 0;
            
            foreach (Organism o in Organisms)
            {
                ret += o.EvaluateFitness(fitness);
            }

            return ret / 20;
        }

        public void DisplayGeneration(int fitness)
        {
            Order(fitness);
            foreach (Organism o in Organisms)
            {
                //Console.WriteLine(b.DNA + " : " + b.EvaluateDNA() + " : " + b.EvaluateFitness(fitness));
                Console.WriteLine("dna : " + o.DNA);
                //Console.WriteLine("evl : " + b.EvaluateDNA());
                Console.Write("fit : ");
                int fit = o.EvaluateFitness(fitness);
                if (fit == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (fit <= fitness / 2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(o.EvaluateFitness(fitness) + "\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public List<Organism> GetBest(int fitness)
        {
            Order(fitness);
            int i = 0;
            List<Organism> ret = new List<Organism>();

            while (i < 5)
            {
                ret.Add(Organisms[i]);

                i++;
            }

            return ret;
        }
    }
}
