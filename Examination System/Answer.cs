using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Answer
    {
        public  int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Answer() {}
        public Answer(int _answerID , string _answerText) 
        {
            AnswerId = _answerID;
            AnswerText = _answerText;
        }
        public override string ToString()
        {
            return $"{AnswerId}-{AnswerText}\n";
        }
    }
}
