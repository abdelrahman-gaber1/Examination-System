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
        public void ShowAllAnswersMCQ(ref int totalGrade , MCQ[] exam, int[] UserAnswers)
        {
            int j = 0;
            foreach (MCQ mCQ in exam)
            {
                totalGrade += mCQ.ShowAnswer(mCQ, j, UserAnswers);
                j++;
            }
        }
        public static void AddQuestionF(MCQ exam , int type )
        {
            exam.AddQuestion(exam ,type);
        }
        public static int ShowQustionF(MCQ exam, int sum ,ref  int AnswersEnterMCQ ) 
        {
            return exam.ShowQuestion(exam, sum ,ref AnswersEnterMCQ , 1);
        }
    }
}
