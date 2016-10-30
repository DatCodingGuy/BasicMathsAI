using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Maths_AI
{
    class Organism
    {
        public string DNA;

        public Organism(string dna)
        {
            DNA = dna;
        }

        public int EvaluateDNA()
        {
            int ret = 0;
            int op = 0;

            foreach (char c in DNA)
            {
                if (char.IsDigit(c))
                {
                    if (op == 0)
                    {
                        ret = int.Parse(c.ToString());
                    }
                    else if (op == 1)
                    {
                        ret += int.Parse(c.ToString());
                    }
                    else if (op == 2)
                    {
                        ret -= int.Parse(c.ToString());
                    }
                    else if (op == 3)
                    {
                        ret *= int.Parse(c.ToString());
                    }
                    else if (op == 4)
                    {
                        ret /= int.Parse(c.ToString());
                    }
                }
                else if (c == '+')
                {
                    op = 1;
                }
                else if (c == '-')
                {
                    op = 2;
                }
                else if (c == '*')
                {
                    op = 3;
                }
                else if (c == '/')
                {
                    op = 4;
                }
            }

            return ret;
        }

        public int EvaluateFitness(int fitness)
        {
            int eval = EvaluateDNA();

            if (eval > fitness)
            {
                return eval - fitness;
            }
            else
            {
                return fitness - eval;
            }
        }
    }
}
