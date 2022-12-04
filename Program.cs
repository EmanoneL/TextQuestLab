using System;

namespace Text_quest_Lab
{
    class Progra
    {
        static void Main(string[] args)
        {
            TextAnalyzer an = new TextAnalyzer();
            GameDesk desk = new GameDesk();
            desk.printQuestions(an.analyze());
        }
    }
}
