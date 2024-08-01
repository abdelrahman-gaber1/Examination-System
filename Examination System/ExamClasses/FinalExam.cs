using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination_System.Question;

namespace Examination_System.ExamClasses
{ 
    internal class FinalExam : Exam
    {
        public MCQ[] QTypeOne { get; set; }
        public TrueFalse[] QTypeTwo { get; set; }
        public FinalExam(int _numberofQuestuin, int mcqN)
        {
            QTypeOne = new MCQ[mcqN];
            QTypeTwo = new TrueFalse[_numberofQuestuin - mcqN];
            for (int i = 0; i < mcqN; i++)
            {
                QTypeOne[i] = new MCQ();
            }
            for (int i = 0; i < _numberofQuestuin - mcqN; i++)
            {
                QTypeTwo[i] = new TrueFalse();
            }
        }
    }
}
