using Examination_System.ExamClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
    internal class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public int RightAnswer { get; set; }
        public Question(string _header, string _body, int _mark, Answer[] _answers, int _rightAnswer)
        {
            Header = _header;
            Body = _body;
            mark = _mark;
            AnswerList = _answers;
            RightAnswer = _rightAnswer;
        }
        public override string ToString()
        {
            var ansewer = string.Join("\n", AnswerList.Select(answerList => answerList.ToString()));

            return $"{Header}\n " +
                $"{Body} \n " +
                $"{mark} \n " +
                $" {ansewer}\n ";
        }
        public int ShowAnswer(Question question, int j, int[] UserAnswers)
        {
            Console.WriteLine($"Question {j + 1} : {question.Body}");
            Console.WriteLine($"Your Answer => {question.AnswerList[UserAnswers[j]].AnswerText}");
            Console.WriteLine($"Right Answer => {question.AnswerList[question.RightAnswer - 1].AnswerText}");
            return question.mark;
        }
        public void AddQuestion(Question question , int type)
        {
            Console.WriteLine("Please Enter Question Body");
            question.Body = Console.ReadLine();
            Console.WriteLine("Please Enter Question Mark");
            int.TryParse(Console.ReadLine(), out int m);
            question.mark = m;
            if(type == 1)
            {
                Console.WriteLine("Choice of Question");
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Please Enter Choice Number {j + 1}");
                    question.AnswerList[j].AnswerId = j + 1;
                    question.AnswerList[j].AnswerText = Console.ReadLine();
                }
                Console.WriteLine($"Please Enter Right Answer Id");
            }
            else
            {
                Console.WriteLine($"Please Enter Right Answer Id (1 For true | 2 for False)");
            }
            int.TryParse(Console.ReadLine(), out int r);
            question.RightAnswer = r;
            Console.Clear();
        }
        public  int ShowQuestion (Question question , int sum  ,ref  int AnswersEnterMCQ ,int type) 
        {
            Console.WriteLine(question.ToString());
            if(type == 1) 
                 Console.WriteLine("Please Enter The Answer Id");
            else if(type == 2)
                Console.WriteLine("Please Enter The Answer Id (1 For True | 2 For False)");
            int.TryParse(Console.ReadLine(), out int answerP);
            AnswersEnterMCQ = answerP - 1;
            if (answerP == question.RightAnswer)
                sum += question.mark;
            Console.Clear();
            return sum;
        }
    }
}
