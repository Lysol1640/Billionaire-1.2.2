using System;
using System.Linq;


namespace Billionaire_1._2._1
{
    class AnswerProcessing
    {
        public static string[] AnswerRandomize(string[] question)
        {
            string Text = question[0];
            string Ansa = question[1];
            string Ansb = question[2];
            string Ansc = question[3];
            string CorAns = question[4];
            string Index = "";
                            //shufflowanie odpowiedzi, wydobycie indexu poprawnej odpowiedzi, zwrocenie do Main randomowych odpowiedzi i indexu poprawnej odpowiedzi

            string[] temp = new string[] { Ansa, Ansb, Ansc, CorAns };
                
            
            Random random = new Random();
            temp = temp.OrderBy(x => random.Next()).ToArray();
            int correct = Array.IndexOf(temp, CorAns);
               switch(correct)
               {
                case 0:
                    {
                        Index = "a";
                        break;
                    }
                case 1:
                    {
                        Index = "b";
                        break;
                    }
                case 2:
                    {
                        Index = "c";
                        break;
                    }
                case 3:
                    {
                        Index = "d";
                        break;
                    }
               }
            Array.Resize(ref temp, 6);
            temp[4] = Text;
            temp[5] = Index;
            return temp;
        }
        
    }
}



            


      

