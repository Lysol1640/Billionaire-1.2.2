// nieużywany using
using System;
using System.Collections.Generic;
using System.Linq;


namespace Billionaire_1._2._1
{
    class QuestionLoader
    {
        public static void Loader()
        {
            int[] levels = { 500, 1000, 2000, 4000, 16000, 25000, 40000, 80000, 125000, 250000, 500000, 1000000 };
            foreach (var level in levels)
            {
                List<Question> newQuestionsList = new List<Question>();

               Program.RewardValueQuestions.Add(level, newQuestionsList);
            }
                                                                                                        //podzial zaladowanych z pliku csv pytan w zaleznosci od wartosci, 
                                                                                                        //przydzielenie list z pytaniami do slownika
            // Tu się dzieje jakaś magia którą mozna by załatwić pętlą
            List<Question> list500 = Program.questions.Where(o => o.Value == 500).ToList();
            List < Question > list1000 = Program.questions.Where(o => o.Value == 1000).ToList();
            List < Question > list2000 = Program.questions.Where(o => o.Value == 2000).ToList();
            List < Question > list4000 = Program.questions.Where(o => o.Value == 4000).ToList();
            List < Question > list16000 = Program.questions.Where(o => o.Value == 16000).ToList();
            List < Question > list25000 = Program.questions.Where(o => o.Value == 25000).ToList();
            List < Question > list40000 = Program.questions.Where(o => o.Value == 40000).ToList();
            List < Question > list80000 = Program.questions.Where(o => o.Value == 80000).ToList();
            List < Question > list125000 = Program.questions.Where(o => o.Value == 125000).ToList();
            List < Question > list250000 = Program.questions.Where(o => o.Value == 250000).ToList();
            List < Question > list500000 = Program.questions.Where(o => o.Value == 500000).ToList();
            List<Question> list1000000 = Program.questions.Where(o => o.Value == 1000000).ToList();

            Program.RewardValueQuestions[500].AddRange(list500);
            Program.RewardValueQuestions[1000].AddRange(list1000);
            Program.RewardValueQuestions[2000].AddRange(list2000);
            Program.RewardValueQuestions[4000].AddRange(list4000);
            Program.RewardValueQuestions[16000].AddRange(list16000);
            Program.RewardValueQuestions[25000].AddRange(list25000);
            Program.RewardValueQuestions[40000].AddRange(list40000);
            Program.RewardValueQuestions[80000].AddRange(list80000);
            Program.RewardValueQuestions[125000].AddRange(list125000);
            Program.RewardValueQuestions[250000].AddRange(list250000);
            Program.RewardValueQuestions[500000].AddRange(list500000);
            Program.RewardValueQuestions[1000000].AddRange(list1000000);
        }
    }
}
       
            





       

      

