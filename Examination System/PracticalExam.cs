using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
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
