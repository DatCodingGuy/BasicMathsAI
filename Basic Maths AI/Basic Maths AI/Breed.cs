using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Maths_AI
{
    class Breed
    {
        static Generation NewGen;
        static Random rand = new Random();

        public Breed(List<Organism> best)
        {
            NewGen = new Generation();

            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[0].DNA, best[1].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[0].DNA, best[2].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[0].DNA, best[3].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[0].DNA, best[4].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[1].DNA, best[0].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[1].DNA, best[2].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[1].DNA, best[3].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[1].DNA, best[4].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[2].DNA, best[0].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[2].DNA, best[1].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[2].DNA, best[3].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[2].DNA, best[4].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[3].DNA, best[0].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[3].DNA, best[1].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[3].DNA, best[2].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[3].DNA, best[4].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[4].DNA, best[0].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[4].DNA, best[1].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[4].DNA, best[2].DNA))));
            NewGen.AddOrganism(new Organism(Mutate(NewDNA(best[4].DNA, best[3].DNA))));
        }

        static string NewDNA(string o1, string o2)
        {
            string ret = "";
            int i = 0;

            if (o1.Length == o2.Length)
            {
                int length = o1.Length;

                ret += Choose(o1[i].ToString(), o2[i].ToString());
                i++;

                while (i < length)
                {
                    ret += Choose(o1[i].ToString() + o1[i + 1].ToString(), o2[i].ToString() + o2[i + 1].ToString());
                    i += 2;
                }
            }
            else if (o1.Length > o2.Length)
            {
                int length1 = o1.Length;
                int length2 = o2.Length;

                ret += Choose(o1[i].ToString(), o2[i].ToString());
                i++;

                while (i < length2)
                {
                    ret += Choose(o1[i].ToString() + o1[i + 1].ToString(), o2[i].ToString() + o2[i + 1].ToString());
                    i += 2;
                }

                while (i < length1)
                {
                    if (Choose())
                    {
                        ret += o1[i].ToString() + o1[i + 1].ToString();
                    }

                    i += 2;
                }
            }
            else if (o1.Length < o2.Length)
            {
                int length1 = o1.Length;
                int length2 = o2.Length;

                ret += Choose(o1[i].ToString(), o2[i].ToString());
                i++;

                while (i < length1)
                {
                    ret += Choose(o1[i].ToString() + o1[i + 1].ToString(), o2[i].ToString() + o2[i + 1].ToString());
                    i += 2;
                }

                while (i < length2)
                {
                    if (Choose())
                    {
                        ret += o2[i].ToString() + o2[i + 1].ToString();
                    }

                    i += 2;
                }
            }

            return ret;
        }

        static string Choose(string s1, string s2)
        {
            int chance = rand.Next(1, 2);

            if (chance == 1)
            {
                return s1;
            }
            else
            {
                return s2;
            }
        }

        static bool Choose()
        {
            int chance = rand.Next(1, 2);

            if (chance == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Mutate(string dna)
        {
            int doesmutate = rand.Next(1, 10);
            if (doesmutate == 1)
            {
                int index = rand.Next(0, dna.Length - 1);
                char c = dna[index];

                if (char.IsDigit(c))
                {
                    int num = rand.Next(1, 9);

                    c = char.Parse(num.ToString());
                }
                else
                {
                    int op = rand.Next(1, 4);

                    if (op == 1)
                    {
                        c = '+';
                    }
                    else if (op == 2)
                    {
                        c = '-';
                    }
                    else if (op == 3)
                    {
                        c = '*';
                    }
                    else if (op == 4)
                    {
                        c = '/';
                    }
                }

                List<string> added = new List<string>();
                int addnode = rand.Next(1, 3);
                if (addnode == 1)
                {
                    string node = "";
                    int nodes = rand.Next(1, 3);
                    int i = 0;

                    while (i < nodes)
                    {
                        int p1 = rand.Next(1, 4);
                        int p2 = rand.Next(1, 9);

                        if (p1 == 1)
                        {
                            node += "+";
                        }
                        else if (p1 == 2)
                        {
                            node += "-";
                        }
                        else if (p1 == 3)
                        {
                            node += "*";
                        }
                        else if (p1 == 4)
                        {
                            node += "/";
                        }

                        node += p2.ToString();
                        added.Add(node);
                        node = "";
                        i++;
                    }
                }

                StringBuilder sb = new StringBuilder(dna);
                sb[index] = c;
                dna = sb.ToString();

                foreach (string node in added)
                {
                    dna += node;
                }

                return dna;
            }
            else
            {
                return dna;
            }
        }

        public Generation GetGeneration()
        {
            return NewGen;
        }
    }
}
