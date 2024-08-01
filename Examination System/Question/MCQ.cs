using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
    internal class MCQ : Question
    {
        public MCQ()
         : base("MCQ Question", string.Empty, 0, new Answer[3], -1)
        {
            for (int i = 0; i < 3; i++)
            {
                AnswerList[i] = new Answer();
            }
        }
        public override string ToString()
        {
            var ansewer = string.Join("\n", AnswerList.Select(answerList => answerList.ToString()));
            return $"{Header}    Mark{mark}\n" +
                $"{Body} \n" +
                $"{ansewer}\n";
        }
    }
}
