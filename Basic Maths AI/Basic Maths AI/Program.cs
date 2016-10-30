using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Maths_AI
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.Write("What's your aim: ");
            int aim = int.Parse(Console.ReadLine());
            int gen = 1;
            Generation g = GenerateRandomGeneration();
            Breed b = null;

            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Generation: " + gen + "\n");
                g.DisplayGeneration(aim);
                b = new Breed(g.GetBest(aim));
                g = b.GetGeneration();
                Console.ReadLine();
                gen++;
            }
        }

        static Organism GenerateRandomOrganism()
        {
            string dna = "";
            int nodes = rand.Next(1, 3);
            int basenode = rand.Next(1, 10);
            dna += basenode.ToString();
            int i = 1;
            
            while (i <= nodes)
            {
                int op = rand.Next(1, 5);

                if (op == 1)
                {
                    dna += "+";
                }
                else if (op == 2)
                {
                    dna += "-";
                }
                else if (op == 3)
                {
                    dna += "*";
                }
                else if (op == 4)
                {
                    dna += "/";
                }

                dna += rand.Next(1, 9).ToString();
                i++;
            }

            return new Organism(dna);
        }

        static Generation GenerateRandomGeneration()
        {
            Generation gen = new Generation();
            int i = 1;

            while (i <= 20)
            {
                gen.AddOrganism(GenerateRandomOrganism());

                i++;
            }

            return gen;
        }
    }
}
