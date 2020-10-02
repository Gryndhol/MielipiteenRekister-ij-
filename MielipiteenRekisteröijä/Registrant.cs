using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MielipiteenRekisteröijä
{
    public class Registrant
    {
        List<Opinion> opinions = new List<Opinion>();
        public void Start()
        {
            int? selection = 2;
            while (selection != 3)
            {
                Console.Clear();
                Console.WriteLine("Niilo22:sen mielipiteen rekisteröijä v0.0.22 (preAlpha)");
                Console.WriteLine("\nMitä juuri sinä haluat tehdä?");
                Console.WriteLine("\n[1] Rekisteröi mielipide");
                Console.WriteLine("[2] Hallinnoi mielipiteitä");
                Console.WriteLine("[3] Poistu");
                selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        RegisterOpinion();
                        Console.ReadKey();
                        break;
                    case 2:
                        ManageOpinions();
                        Console.ReadKey();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        public Opinion RegisterOpinion() //[1]
        {
            Console.Clear();
            string op;
            Opinion opinion = new Opinion();
            Console.Write("Syötä mielipide: ");
            op = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Mielipiteesi '{op}' on rekisteröity");
            Console.WriteLine("\nPaina näppäintä jatkaaksesi...");
            opinion.description = op;
            opinions.Add(opinion);
            return opinion;
        }

        public void ManageOpinions() // [2]
        {
            Console.Clear();
            int selection = 2;
            if (opinions.Count == 0)
            {
                Console.WriteLine("(Mielipiteitä ei löytynyt)");
                Console.WriteLine("\nPaina näppäintä jatkaaksesi...");
            }
            else
            {
                Console.WriteLine("Hallinnoi mielipiteitä");
                Console.WriteLine();
                foreach (var opinion in opinions)
                {
                    Console.WriteLine($"'{opinion.description}'");
                }
                Console.WriteLine("\n[1] Poista mielipide");
                Console.WriteLine("[2] Palaa takaisin");
                selection = int.Parse(Console.ReadLine());
                while (selection != 2)
                {
                    switch (selection)
                    {
                        case 1:
                            DeleteOpinion();
                            break;
                        case 2:
                            Start();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void DeleteOpinion() // [2 [1]]
        {
            Console.Clear();
            Console.WriteLine("Valitse poistettava mielipide numerolla");
            Console.WriteLine();
            int selection;
            int iD;
            iD = -1;
            foreach (var opinion in opinions)
            {
                iD++;
                Console.WriteLine($"[{iD}] '{opinion.description}'");
            }
            Console.WriteLine();
            selection = int.Parse(Console.ReadLine());
            opinions.RemoveAt(selection);
            Console.Clear();
            Console.WriteLine($"Mielipide poistettiin rekisteristä");
            Console.WriteLine("\nPaina näppäintä jatkaaksesi...");
            Console.ReadKey();
            Start();
        }

        public List<Opinion> CreateTestData()
        {
            Opinion opinion1 = new Opinion();
            Opinion opinion2 = new Opinion();
            Opinion opinion3 = new Opinion();

            opinion1.description = "Lempäälän painovoimaa pitäs rajottaa";
            opinion2.description = "Kukkosoosi on 5/ soos";
            opinion3.description = "On kyllä säällä paiskattu";

            opinions.Add(opinion1);
            opinions.Add(opinion2);
            opinions.Add(opinion3);

            return opinions;
        }
    }
}
