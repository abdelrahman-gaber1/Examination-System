using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public void ShowAllAnswersMCQ(ref int totalGrade,MCQ[] exam, int[] UserAnswers)
        {
            int j = 0;
            foreach (MCQ mCQ in exam) 
            {
                totalGrade += mCQ.ShowAnswer(mCQ ,j, UserAnswers);  
                j++;
            }
        }
        public void ShowAllAnswersTrueFalse(ref int totalGrade , TrueFalse[] exam, int[] UserAnswers)
        {
            int j = 0;
            foreach (TrueFalse TrueFalse in exam)
            {
                totalGrade += TrueFalse.ShowAnswer(TrueFalse, j, UserAnswers);
                j++;
            }
        }
        public static void AddQuestionM(MCQ exam , int type)
        {
            exam.AddQuestion(exam, type );
        }
        public static void AddQuestionF(TrueFalse exam, int type)
        {
            exam.AddQuestion(exam, type);
        }
        public static int ShowQustionM(MCQ exam, int sum, ref int AnswersEnterMCQ)
        {
            return exam.ShowQuestion(exam, sum, ref AnswersEnterMCQ , 1);
        }
        public static int ShowQustionF(TrueFalse exam, int sum, ref int AnswersEnterMCQ)
        {
            return exam.ShowQuestion(exam, sum, ref AnswersEnterMCQ , 2);
        }
    }
}
