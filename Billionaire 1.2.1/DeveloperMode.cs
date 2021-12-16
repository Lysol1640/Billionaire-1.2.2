using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billionaire_1._2._1
{
    class DeveloperMode
    {
        public static void DevMode() 
        {
            int value = 0 ;
            string quest;
            string ansa;
            string ansb;
            string ansc;
            string corans;

            string exit = "";
            Console.Clear();

                                                                                               //pobieranie danych z klawiatury i przekazanie ich do funkcji tworzacej nowe pytania
            while (exit != "exit")
            {
                 Console.WriteLine("Enter the value of Question.\n " +
                     "Value must be one of following:\n" +
                     "500, 1000, 2000, 4000, 16000, 25000, 40000, 80000, 125000, 250000, 500000, 1000000");
                while (true)
                {
                    try
                    {
                        value = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    
                    catch (FormatException)
                    {
                        Console.WriteLine("Value of question must be one of following: \n" +
                            "500, 1000, 2000, 4000, 16000, 25000, 40000, 80000, 125000, 250000, 500000, 1000000");
                    }
                }
                    
                Console.WriteLine("Enter the question: ");
                quest = Console.ReadLine();

                Console.WriteLine("Enter the first invalid answer: ");
                ansa = Console.ReadLine();
                
                Console.WriteLine("Enter the second invalid answer: ");
                ansb = Console.ReadLine();
                
                Console.WriteLine("Enter the third invalid answer: ");
                ansc = Console.ReadLine();
                
                Console.WriteLine("Enter the correct answer: ");
                corans = Console.ReadLine();

                AddQuestionToList(quest, ansa, ansb, ansc, corans, value);

                Console.WriteLine("If you want to save changes and exit, type exit. If You want to continue to creating new questions, type c ");
                exit = Console.ReadLine();
                                                                    // zaladowana przy inicjalizacji lista pytan (ktora jest gotowa do uzytku w grze) jest aktualizowana po kazdym
                   if (exit == "exit")                                                                   // dodaniu pytania. Po zakonczeniu trybu dev lista jest zapisywana do csv  
                   {
                      DataBase.WriteData();
                   }
              
                Console.Clear();
            }
        }
            
        static void AddQuestionToList(string Quest, string Ans1, string Ans2, string Ans3, string Ans4, int Value)
        {
            Program.questions.Add(new Question(Quest, Ans1, Ans2, Ans3, Ans4, Value));                                                          //funkcja aktualizujaca liste pytan 
        }
    }
}
