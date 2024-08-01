using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Question
    {
        public string  Header { get; set; }
        public string Body { get; set; }
        public int mark {  get; set; }
        public Answer[] AnswerList { get; set; }
        public int RightAnswer { get; set; } 
        public Question(string _header , string _body , int _mark , Answer[] _answers ,int _rightAnswer) 
        {
            Header = _header;
            Body = _body;
            mark = _mark;
            AnswerList = _answers;
            RightAnswer = _rightAnswer;
        }
        public override string ToString()
        {
            var ansewer = String.Join("\n",AnswerList.Select(answerList => answerList.ToString()));

            return $"{Header}\n " +
                $"{Body} \n " +
                $"{mark} \n " +
                $" {ansewer}\n ";
        }
    }
}
