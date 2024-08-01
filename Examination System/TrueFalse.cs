using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TrueFalse : Question
    {
        public TrueFalse()
         : base("True | False Question", string.Empty, 0, new Answer[2], -1)
        {
            AnswerList = new Answer[2];
            AnswerList[0] = new Answer(1 , "True");
            AnswerList[1] = new Answer (2 , "False");
        }
        public override string ToString()
        {
            var ansewer = String.Join("\n", AnswerList.Select(answerList => answerList.ToString()));

            return $"{Header}\n" +
                $"Mark{mark} \n" +
                $"{Body} \n" +
                $"{ansewer}\n";
        }
    }
}
