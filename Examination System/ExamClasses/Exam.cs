using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.ExamClasses
{
    internal class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestion { get; set; }
        public PracticalExam CreatePractical(int _numberofQuestuin)
        {
            return new PracticalExam(_numberofQuestuin);
        }
        public FinalExam CreateFinal(int _numberofQuestuin, int mcqN)
        {
            return new FinalExam(_numberofQuestuin, mcqN);
        }
    }
}
