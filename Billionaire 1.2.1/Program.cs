using System;
using System.Collections.Generic;


namespace Billionaire_1._2._1
{
    class Program
    {
        public static List<Question> questions = new List<Question>();                                                                   //lista pytan z dostepem dla innych klas
        public static Dictionary<int, List<Question>> RewardValueQuestions = new Dictionary<int, List<Question>>();                          //podzial pytan w zaleznosci od kwoty
        public static string[] ff;

        public static void Main(string[] args)
        {
            #region declarations
            string decide = "y";
            string Ans = "";
            bool wonder = true;
            string leave = "n";
            string choose;
            int questionNum;
            int flipQuestionNum;
            int prize = 0;
            int guaranteed = 0;
            int indexOfLevel = 0;
            int pollCorrect = 90;
            int[] nextLevel = { 500, 1000, 2000, 4000, 16000, 25000, 40000, 80000, 125000, 250000, 500000, 1000000 };
            Random numOfQ = new Random();
            #endregion
            
            DataBase.ReadData();                                                                                                    //zaladowanie listy pytan w klasie DataBase
            QuestionLoader.Loader();


            while (true)
            {
                Console.Clear();
                Console.WriteLine(AddOns.Welcome());
                choose = Console.ReadLine().ToLower();
             

                switch (choose)
                {
                     case "a":                                                                                                                                   //tryb rozgrywki
                        {
                            Console.Clear();
                            decide = "y";
                            leave = "n";                                                                                //wyzerowanie kluczowych wartosci
                            indexOfLevel = 0;                                                                           //na wypadek ponownej gry
                            guaranteed = 0;
                            questionNum = 0;
                            List<Question> currentList = new List<Question>();
                            wonder = true;
                            AddOns.fiftyFifty = true;
                            AddOns.audience = true;
                            AddOns.flip = true;
                            Console.WriteLine(AddOns.Rules());
                            Console.ReadLine();


                            do                                                                                                                           //petla kazdego poziomu
                            {
                                Console.Clear();

                                currentList = RewardValueQuestions[nextLevel[indexOfLevel]];                            //inkrementacja nr-u listy pytan w zaleznosci od poziomu
                             
                                questionNum = numOfQ.Next(0, currentList.Count);                                                                     //losowanie pytania z listy

                                do
                                {
                                    flipQuestionNum = numOfQ.Next(0, currentList.Count);                                //wylosowanie indexu zapasowego pytania
                                } while (flipQuestionNum == questionNum);
                                
                                string[] currentQuestion = { currentList[questionNum].Text, currentList[questionNum].Ansa, currentList[questionNum].Ansb,   
                                    currentList[questionNum].Ansc, currentList[questionNum].CorAns, currentList[questionNum].Value.ToString() };

                                string[] displayQuestion = AnswerProcessing.AnswerRandomize(currentQuestion);            //randomizowanie kolejnosci odpowiedzi wylosowanego pytania
                                



                                                                                    //petla umozliwiajaca wybor kol ratunkowych. Odpowiedz jest sprawdzana, jesli gracz ostatecznie 
                                while (wonder == true)                                                     //bedzie pewien swojej odpowiedzi
                                {
                                    Console.WriteLine($"{displayQuestion[4]} \n A:{displayQuestion[0]}  B:{displayQuestion[1]}   " +
                                        $"C:{displayQuestion[2]}   D:{displayQuestion[3]}");
                                    Console.WriteLine("Type in the correct answer: ");
                                    Console.WriteLine("Remember, if the question seems to be tough, you can use one or few lifelines by pressing X\n" +
                                        "or Leave with your earnings by pressing E ");

                                    while (true)                                                                        //sprawdzenie poprawnosci wprowadzonego klawisza
                                    {                                                                                   //oraz wyswietlenie informacji o bledzie
                                        try
                                        {
                                            Ans = Console.ReadLine().ToLower();
                                            if (Ans != "a" && Ans != "b" && Ans != "c" && Ans != "d" && Ans != "x" && Ans != "e")
                                            {
                                                throw new Exception();
                                            }
                                            break;
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Enter the key of A,B,C,D. Press X for lifeline, E to leave with your earnings.");
                                        }
                                    }


                                    switch (Ans)                                                                                 //wybor odpowiedzi, lub tryb kol ratunkowych
                                    {
                                        case "x":                                                                                        // wybor kola ratunkowego
                                            {
                                                Console.WriteLine(AddOns.Lifeline());
                                                string lifeline = Console.ReadLine().ToLower();



                                                switch (lifeline)
                                                {
                                                    case "a":
                                                        {
                                                            Console.Clear();
                                                            displayQuestion = AddOns.FiftyFifty(displayQuestion);
                                                            break;
                                                        }
                                                    case "b":
                                                        {
                                                            AddOns.AskTheAudience(displayQuestion, pollCorrect);
                                                            break;
                                                        }
                                                    case "c":
                                                        {
                                                            Console.Clear();
                                                           displayQuestion = AddOns.FlipQuestion(displayQuestion, currentList, flipQuestionNum);
                                                            break;
                                                        }
                                                }
                                                break;
                                            }

                                        case "a":
                                        case "b":
                                        case "c":
                                        case "d":
                                            {                                                                          
                                                Random rnd = new Random();
                                                int k = rnd.Next(0, 4);
                                                Console.WriteLine(AddOns.Confirm(k));
                                                string sure = Console.ReadLine().ToLower();                              //  DEFINITYWNIE??
                                                if (sure == "y")                                            
                                                {
                                                    wonder = false;
                                                }
                                                else if (sure == "n")
                                                {
                                                    wonder = true;
                                                }
                                                break;
                                            }
                                        case "e":
                                            {
                                                Console.WriteLine("Are you sure of your decision? y/n");
                                                leave = Console.ReadLine().ToLower();
                                                if (leave == "y")
                                                {

                                                    wonder = false;
                                                }
                                                else if (leave == "n")
                                                {
                                                    wonder = true;
                                                }
                                                break;
                                            }
                                    } 
                                }

                                if (Ans == displayQuestion[5])                              //Jezeli odp jest poprawna, inkrementowana jest lista pytan, sprawdzany i ustalany jest
                                {                                                           //prog gwarantowany, zmniejszany zmniejszany jest % poprawnych odpowiedzi w 
                                    prize = nextLevel[indexOfLevel];                        //Pytaniu do publicznosci
                                    Console.WriteLine($"You won {prize:c}! ");

                                    if (nextLevel[indexOfLevel] == 4000 || nextLevel[indexOfLevel] == 80000)
                                    {
                                        guaranteed = nextLevel[indexOfLevel];
                                    }
                                    if (prize == 1000000)
                                    {
                                        Console.WriteLine("Congratulations! You won the main prize!");
                                        Console.ReadLine();
                                        break;
                                    }
                                    indexOfLevel++;
                                    wonder = true;
                                    if (pollCorrect > 0)
                                    {
                                        pollCorrect = (pollCorrect - 10);
                                    }
                                    Console.WriteLine("Ready for next question? y/n");
                                    decide = Console.ReadLine();
                                    if (decide == "n")
                                    {
                                        Console.WriteLine($"Congratulations! You won {prize:c}! Thank you for your game!");
                                    }

                                }
                                else if (leave == "y")
                                {
                                    Console.WriteLine($"Congratulations! You won {prize:c}! Thank you for your game!");
                                    decide = "n";
                                }
                                else if (guaranteed == 4000 || guaranteed == 80000)
                                {
                                            Console.WriteLine($"Wrong Answer! But You won the guaranteed amount of money, which is : {guaranteed:c}");
                                            decide = "n";
                                }
                                else
                                {
                                    Console.WriteLine("Unfortunately, that's the wrong answer, You won nothing");
                                    decide = "n";
                                }

                            } while (decide == "y") ;
                                           
                        Console.ReadKey();
                        break;
                        }

                    case "b":
                        {
                            DeveloperMode.DevMode();
                            break;
                        }
                }
            }
        } 
    } 
}
                                                                                                     
                           
                                   


                                                            


                                                

                                
                                                            






                                    
                                        
                                    
                                


                            










