using System;
using System.Collections.Generic;
using System.Linq;


namespace Billionaire_1._2._1
{
    class AddOns                                                                                                //klasa zawiera definicje kol ratunkowych oraz dluzsze komunikaty
    {
        public static bool fiftyFifty = true;
        public static bool audience = true;
        public static bool flip = true;
        



        public static string Welcome()
        {
            return ($"Welcome to Who wants to be a Millionaire!\n\n" +                                                            //wiadomosc powitalna, wybor trybu
            $"If You want to win a {1000000:c}, press A \n" +
            "If You are a developer, press B\n");
        }

        public static string Rules()                                                                                                                    //zasady gry
        {
            return              ($"There are 12 questions to win the main prize which is {1000000:c}. \nThere are 2 levels of guaranteed amount of money. \n" +
                                $"It means, that if You correctly answer the questions worth {4000:c} or {80000:c} \nthe guaranteed amount of money will be set up.\n" +
                                $"If You pass the wrong answer, You will lose but you are gonna take the guaranteed amount, or nothing, if you lose before reaching guaranteed level \n" +
                                $"But if you don't want to risk passing the wrong answer, you may quit at any time and keep your earnings. Press e during a game to" +
                                $"leave with your earnings.\n\n" +
                                $"At any point, you may use up one (or more) of their three {"lifelines"}. These are: \n\n" +
                                $"*50:50 - two of the three incorrect answers are removed.\n" +
                                $"*Flip Question - If you don't know the answer, you can change your question once in a game.\n" +
                                $"*Ask the audience - the audience votes with their keypads on their choice of answer.\n\n" +
                                $"You can use them during a game by pressing x.\n\n" +
                                $"Press enter if you are ready to play!");                                                                               
        }

        public static string Lifeline()
        {
            return ("You're feeling insecure? No worries, you can use one of 3 lifelines:\n" +
                 "-Press a to use 50:50 \n-Press b to Ask the Audience\n" +
                 "-Press c to Flip the Question\n");
        }

        public static string Confirm(int x)
        {
            string[] confirm = { "Are you sure? y/n", "Definitely? y/n", "Is that your final answer? y/n", "if your life depended on that answer, would it be the same? y/n", 
            "You seem to be confident of your answer> Am I right? y/n"};
            return confirm[x];
        }
            
            
                    

        public static string[] FiftyFifty(string[] answers)                                                                        //mechanizm działania kol ratunkowych
        {
                string ansa = answers[0];
                string ansb = answers[1];
                string ansc = answers[2];
                string ansd = answers[3];
                string text = answers[4];
                string index = answers[5];
                int del1;
                int del2;
                int indexOf = 0;
                string[] ff = new string[6] { ansa, ansb, ansc, ansd, text, index } ;
                Random rnd = new Random();
            if (fiftyFifty == true)
            {
                switch (index)
                {
                    case "a":
                        {
                            indexOf = 0;
                            break;
                        }
                    case "b":
                        {
                            indexOf = 1;
                            break;
                        }
                    case "c":
                        {
                            indexOf = 2;
                            break;
                        }
                    case "d":
                        {
                            indexOf = 3;
                            break;
                        }
                }
                do
                {
                    del1 = rnd.Next(0, 3);
                } while (del1 == indexOf);
                do
                {
                    del2 = rnd.Next(0, 3);
                } while (del2 == indexOf || del2 == del1);

                ff[del1] = "";
                ff[del2] = "";

                fiftyFifty = false;
            }
            else
            {
                Console.WriteLine("You've already used this lifeline");
            }
            return ff;
        }
                                                                                                      //z wiadomych przyczyn (brak zywej publicznosci) funkcja zwraca           
                                                                                                      // poprawna odpowiedz z iloscia glosow zalezna od poziomu trudnosci
                                                                                                     // np. na poziomie 0, % osob ktore zaglosuja na poprawna odp
                                                                                                     // bedzie wynosic 90%, reszta 
                                                                                                     //odpowiedzi bedzie przydzielana losowo
        public static void AskTheAudience(string[] answers, int pollDiff)                          //im wyzszy poziom, tym mniejszy % osob zaglosuje poprawnie
        {
            string ansa = answers[0];
            string ansb = answers[1];
            string ansc = answers[2];
            string ansd = answers[3];
            string text = answers[4];
            string index = answers[5];
            int indexOf = 0;
            int roll;
            List<int> emptyAnswers = new List<int>();
            List<int> poll = new List<int>();

            Random rnd = new Random();
            if (audience == true)
            {
                switch (index)                                                                               //przeksztalcenie indexu poprawnej odpowiedzi na liczbe
                {
                    case "a":
                        {
                            indexOf = 0;
                            break;

                        }
                    case "b":
                        {
                            indexOf = 1;
                            break;
                        }
                    case "c":
                        {
                            indexOf = 2;
                            break;
                        }
                    case "d":
                        {
                            indexOf = 3;
                            break;
                        }
                }
                string[] temp = { ansa, ansb, ansc, ansd };

                // nie używaj zmiennych jednoliterowych, bo one już kopletnie nic nie mówią, opisz w zmiennej czy jest t wartość dla przyszłych deweloperów
                int k = 0;
                foreach (string t in temp)                                                        //sprawdzenie ktore odpowiedzi sa puste(czy zostalo zastosowane 50/50)
                {                                                                                 //oraz wydobycie indeksu tych odpowiedzi
                    bool a = string.IsNullOrEmpty(t);
                    if (a==true)
                    {
                        emptyAnswers.Add(k);
                    }
                    k++;
                }

                int numOfEmpty = emptyAnswers.Count;
                                                                                               
                    for(int i = 0; i < pollDiff; i++)
                    {
                    poll.Add(indexOf);                                           // Zaleznie od poziomu gry - do listy dodawany jest % osob ktory zaglosuje na poprawna odpowiedz
                    }

                if (numOfEmpty == 2)
                {
                    for (int j = pollDiff; j < 100; j++)
                    {                                                                                    //pozostala ilosc osob podaje odpowiedzi losowo
                        do
                        {
                            roll = rnd.Next(0, 4);
                        } while (roll == emptyAnswers[0] || roll == emptyAnswers[1]);
                        poll.Add(roll);
                    }
                }
                else if (numOfEmpty == 0)
                {
                    for (int j = pollDiff; j < 100; j++)
                    {
                        roll = rnd.Next(0, 4);
                        poll.Add(roll);
                    }

                }
                Console.Clear();
                Console.WriteLine("Here are the results of poll: \n A:{0}%   B:{1}%   C:{2}%   D:{3}%",
                poll.Where(a => a == 0).ToList().Count(), poll.Where(a => a == 1).ToList().Count(),
                poll.Where(a => a == 2).ToList().Count(), poll.Where(a => a == 3).ToList().Count());
                audience = false;
            }
            else
            {
                Console.WriteLine("You've already used this lifeline");
            }
        }

        public static string[] FlipQuestion(string[] original,List<Question> current, int questionNumber)
        {
            string[] fq = original;
            if (flip == true)
            {
                string[] flipQuestion = { current[questionNumber].Text, current[questionNumber].Ansa, current[questionNumber].Ansb,
                                    current[questionNumber].Ansc, current[questionNumber].CorAns, current[questionNumber].Value.ToString() };

                fq = AnswerProcessing.AnswerRandomize(flipQuestion);

                flip = false;
            }
            else
            {
                Console.WriteLine("You've already used this lifeline");
            }
            return fq;
        }
    }
}
            
            

                   

                

            
                            
        






        





