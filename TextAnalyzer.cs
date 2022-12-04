using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Text_quest_Lab
{
    class TextAnalyzer
    {
        // 'C:\Users\Ekaterina\source\repos\Text quest Lab\Text quest Lab\bin\Debug\netcoreapp3.1\Quest.txt'."
        private string questionsFile = "Quest.txt";
        private List<int> answers = new List<int>();
        private int answersCount = 0; 

        // Превращает текст в удобный формат вопрос-ответ
        public Dictionary<string, int> analyze()
        {
            Dictionary<string, int> QuestText = new Dictionary<string, int>();
            StreamReader reader = new StreamReader(questionsFile);
            string line = reader.ReadLine();
            string item = "";
            int i = 0;
            getAnswers();

            while((line!= null) | (line!= "Ответы:"))
            {
                if (line == "Ответы:")
                {
                    break;
                }

                item += line + '\n';
                line = reader.ReadLine();

                if (line == "")
                {
                    QuestText.Add(item, answers[i]);
                    i++;
                    item = "";
                }
                
            }
            reader.Close();
            answersCount = i;
            return QuestText;
        }
        public void getAnswers()
        {            
            StreamReader reader = new StreamReader(questionsFile);
            string line = reader.ReadLine();

            while (line != "Ответы:")
            {
                line = reader.ReadLine();
            }

            while (line != null)
            {
                line = reader.ReadLine();
                answers.Add(Convert.ToInt32(line));
            }
            reader.Close();
        }

    }
}
