using System;
using CsvHelper.Configuration.Attributes;


namespace Billionaire_1._2._1
{
    public class Question
    {
        [Name("text")] public string Text { get; set; }
        [Name("ansa")] public string Ansa { get; set; }
        [Name("ansb")] public string Ansb { get; set; }
        [Name("ansc")] public string Ansc { get; set; }
        [Name("corans")] public string CorAns { get; set; }
        [Name("value")] public int Value { get; set; }


        public Question(string text = "", string ansa = "", string ansb = "", string ansc = "", string corans = "", int value = 500)
        {
            Text = text;
            Ansa = ansa;
            Ansb = ansb;
            Ansc = ansc;
            CorAns = corans;
            Value = value;
        }
    }
}
