
using Examination_System.ExamClasses;

namespace Examination_System
{
    internal class Program
    {
        public static string StartExam()
        {
            Console.WriteLine("Do You Want To Start Exam(Y|N)");
            return Console.ReadLine(); ; 
        }
        public static void Grade(int sum, int Grade, DateTime finishTime)
        {
            Console.WriteLine($"Your Grade is {sum} from {Grade}");
            Console.WriteLine($"Time = {finishTime - DateTime.Now}");
            Console.WriteLine("Thank You");
        }
        static void Main()
        {
            Subject subject = new Subject()
            {
                SubjectId = 1,
                SubjectName = "Programing",
                ExamOfSubject = new Exam()
            };
            Console.WriteLine("Please Enter The Type Of Exam {1 For Practical | 2 for Final}");
            int.TryParse(Console.ReadLine(), out int typeExam);
            Console.WriteLine("Please Enter The Time For Exam From (30 min to 180 min)");
            int.TryParse(Console.ReadLine(), out int time);
            subject.ExamOfSubject.Time = time;
            DateTime finishTime = DateTime.Now.AddMinutes(time);
            Console.WriteLine("Please Enter The Number Of Question");
            int.TryParse(Console.ReadLine(), out int NumberofQuestion);
            subject.ExamOfSubject.NumberOfQuestion = NumberofQuestion;
            Console.Clear();
            if(typeExam == 1)
            {
                PracticalExam practical = subject.ExamOfSubject.CreatePractical(NumberofQuestion);
                int type = 1;
                for (int i = 0; i < NumberofQuestion; i++)
                {
                    PracticalExam.AddQuestionF(practical.QTypeOne[i] , type);
                }
                int sum = 0;
                if (StartExam().ToUpper() == "Y")
                {
                    Console.Clear();
                    int[] AnswersEnterMCQ = new int[NumberofQuestion];
                    for (int j = 0; j < practical.QTypeOne.Length; j++)
                    {
                        sum = PracticalExam.ShowQustionF(practical.QTypeOne[j], sum ,ref AnswersEnterMCQ[j]);
                    }
                    int totalGrade = 0;
                    practical.ShowAllAnswersMCQ(ref totalGrade, practical.QTypeOne, AnswersEnterMCQ);      
                    Grade(sum, totalGrade , finishTime);
                }
            }
            else if (typeExam == 2)
            {
                Console.WriteLine("Enter The Number of MCQ Question");
                int.TryParse(Console.ReadLine(), out int mcqN);
                int counterOne = 0;         int counterTwo = 0;
                FinalExam final = subject.ExamOfSubject.CreateFinal(NumberofQuestion , mcqN);
                for (int i = 0; i < NumberofQuestion; i++)
                {
                    Console.WriteLine("Please Enter Type of Question (1 for MCQ | 2 For True or False)");
                    int.TryParse(Console.ReadLine(), out int typeQ);
                    if (typeQ == 1)
                    {
                        FinalExam.AddQuestionM(final.QTypeOne[counterOne] , typeQ);
                        counterOne++;
                    }
                    else if (typeQ == 2)
                    {
                        FinalExam.AddQuestionF(final.QTypeTwo[counterTwo] , typeQ);
                        counterTwo++;
                    }
                }
                int sum = 0;
                if (StartExam().ToUpper() == "Y")
                {
                    Console.Clear();
                    int[] AnswersEnterMCQ = new int[NumberofQuestion];
                    int[] AnswersEnterTrue = new int[NumberofQuestion];
                    for (int j = 0; j < final.QTypeOne.Length; j++)
                    {
                        sum = FinalExam.ShowQustionM(final.QTypeOne[j], sum, ref AnswersEnterMCQ[j]);

                    }
                    for (int j = 0; j < final.QTypeTwo.Length; j++)
                    {
                        sum = FinalExam.ShowQustionF(final.QTypeTwo[j], sum, ref AnswersEnterTrue[j]);
                    }
                    int totalGrade = 0;
                    final.ShowAllAnswersMCQ(ref totalGrade, final.QTypeOne, AnswersEnterMCQ);
                    final.ShowAllAnswersTrueFalse(ref totalGrade, final.QTypeTwo, AnswersEnterTrue);
                    Grade(sum, totalGrade,finishTime);
                }
            }
        }
    }
}