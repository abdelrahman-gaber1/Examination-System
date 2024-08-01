using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination_System.Question;

namespace Examination_System.ExamClasses
{
    internal class PracticalExam : Exam
    {
        public MCQ[] QTypeOne { get; set; }
        public PracticalExam(int _numberofquestion)
        {
            QTypeOne = new MCQ[_numberofquestion];
            for (int i = 0; i < _numberofquestion; i++)
            {
                QTypeOne[i] = new MCQ();
            }
        }
    }
}
