using System;
using System.Collections.Generic;
using System.Text;

namespace Text_quest_Lab
{
    class GameDesk
    {
        public void printQuestions(Dictionary<string, int> text)
        {
            foreach (var item in text)
            {
                Console.WriteLine($"key: {item.Key}  value: {item.Value}");
            }
        }
    }
}