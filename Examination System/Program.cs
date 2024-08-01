namespace Examination_System
{
    internal class Program
    {
        static void Main()
        {
            Subject subject = new Subject()
            {
                SubjectId = 1,
                SubjectName = "Math",
                ExamOfSubject = new Exam()
            };
            Console.WriteLine("Please Enter The Type Of Exam {1 For Practical | 2 for Final}");
            int.TryParse(Console.ReadLine(), out int typeExam);
            Console.WriteLine("Please Enter The Time For Exam From (30 min to 180 min)");
            int.TryParse(Console.ReadLine(), out int time);
            subject.ExamOfSubject.Time = time;
            DateTime finishTime = DateTime.Now.AddMinutes(time);
            Console.WriteLine($"Finish Exam at => {finishTime}");
            Console.WriteLine("Please Enter The Number Of Question");
            int.TryParse(Console.ReadLine(), out int NumberofQuestion);
            subject.ExamOfSubject.NumberOfQuestion = NumberofQuestion;
            Console.Clear();
            if(typeExam == 1)
            {
                PracticalExam practical = subject.ExamOfSubject.CreatePractical(NumberofQuestion);
                for (int i = 0; i < NumberofQuestion; i++)
                {
                    Console.WriteLine("Please Enter Question Body");
                    practical.QTypeOne[i].Body = Console.ReadLine();
                    Console.WriteLine("Please Enter Question Mark");
                    int.TryParse(Console.ReadLine(), out int m);
                    practical.QTypeOne[i].mark = m;
                    Console.WriteLine("Choice of Question");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"Please Enter Choice Number {j + 1}");
                        practical.QTypeOne[i].AnswerList[j].AnswerId = j + 1;
                        practical.QTypeOne[i].AnswerList[j].AnswerText = Console.ReadLine();
                    }
                    Console.WriteLine($"Please Enter Right Answer Id");
                    int.TryParse(Console.ReadLine(), out int r);
                    practical.QTypeOne[i].RightAnswer = r;
                    Console.Clear();
                }
                Console.WriteLine("Do You Want To Start Exam(Y|N)");
                string Start = Console.ReadLine();
                Console.Clear();
                int sum = 0;
                if (Start.ToUpper() == "Y")
                {
                    int[] AnswersEnterMCQ = new int[NumberofQuestion];
                    for (int j = 0; j < practical.QTypeOne.Length; j++)
                    {
                        Console.WriteLine(practical.QTypeOne[j].ToString());
                        Console.WriteLine("Please Enter The Answer Id");
                        int.TryParse(Console.ReadLine(), out int answerP);
                        AnswersEnterMCQ[j] = answerP - 1;
                        if (answerP == practical.QTypeOne[j].RightAnswer)
                            sum += practical.QTypeOne[j].mark;
                        Console.Clear();
                    }
                    int totalGrade = 0;
                    for (int j = 0; j < practical.QTypeOne.Length; j++)
                    {
                        Console.WriteLine($"Question {j + 1} : {practical.QTypeOne[j].Body}");
                        Console.WriteLine($"Your Answer => {practical.QTypeOne[j].AnswerList[AnswersEnterMCQ[j]].AnswerText}");
                        Console.WriteLine($"Right Answer => {practical.QTypeOne[j].AnswerList[practical.QTypeOne[j].RightAnswer - 1].AnswerText}");
                        totalGrade += practical.QTypeOne[j].mark;
                    }
                    Console.WriteLine($"Your Grade is {sum} from {totalGrade}");
                    Console.WriteLine($"Time = {finishTime - DateTime.Now}");
                    Console.WriteLine("Thank You");
                }
            }
            else if (typeExam == 2)
            {
                Console.WriteLine("Enter The Number of MCQ Question");
                int.TryParse(Console.ReadLine(), out int mcqN);
                FinalExam final = subject.ExamOfSubject.CreateFinal(NumberofQuestion , mcqN);
                for (int i = 0; i < NumberofQuestion; i++)
                {
                    Console.WriteLine("Please Enter Type of Question (1 for MCQ | 2 For True or False)");
                    int.TryParse(Console.ReadLine(), out int typeQ);
                    if (typeQ == 1)
                    {
                        int counterOne = 0;
                        Console.WriteLine("Please Enter Question Body");
                        final.QTypeOne[counterOne].Body = Console.ReadLine();
                        Console.WriteLine("Please Enter Question Mark");
                        int.TryParse(Console.ReadLine(), out int m);
                        final.QTypeOne[counterOne].mark = m;
                        Console.WriteLine("Choice of Question");
                        for (int j = 0; j < 3; j++)
                        {
                            Console.WriteLine($"Please Enter Choice Number {j + 1}");
                            final.QTypeOne[counterOne].AnswerList[j].AnswerId = j + 1;
                            final.QTypeOne[counterOne].AnswerList[j].AnswerText = Console.ReadLine();
                        }
                        Console.WriteLine($"Please Enter Right Answer Id");
                        int.TryParse(Console.ReadLine(), out int r);
                        final.QTypeOne[counterOne].RightAnswer = r;
                        counterOne++;
                        Console.Clear();
                    }
                    else if (typeQ == 2)
                    {
                        int counterTwo = 0;
                        Console.WriteLine("Please Enter Question Body");
                        final.QTypeTwo[counterTwo].Body = Console.ReadLine();
                        Console.WriteLine("Please Enter Question Mark");
                        int.TryParse(Console.ReadLine(), out int m);
                        final.QTypeTwo[counterTwo].mark = m;
                        Console.WriteLine($"Please Enter Right Answer Id (1 For true | 2 for False)");
                        int.TryParse(Console.ReadLine(), out int r);
                        final.QTypeTwo[counterTwo].RightAnswer = r;
                        counterTwo++;
                        Console.Clear();
                    }
                }
                Console.WriteLine("Do You Want To Start Exam(Y|N)");
                string Start = Console.ReadLine();
                Console.Clear();
                int sum = 0;
                if (Start.ToUpper() == "Y")
                {
                    int[] AnswersEnterMCQ = new int[NumberofQuestion];
                    int[] AnswersEnterTrue = new int[NumberofQuestion];
                    for (int j = 0; j < final.QTypeOne.Length; j++)
                    {
                        Console.WriteLine(final.QTypeOne[j].ToString());
                        Console.WriteLine("Please Enter The Answer Id");
                        int.TryParse(Console.ReadLine(), out int answer);
                        AnswersEnterMCQ[j] = answer - 1;
                        if (answer == final.QTypeOne[j].RightAnswer)
                            sum += final.QTypeOne[j].mark;
                        Console.Clear();
                    }
                    for (int j = 0; j < final.QTypeTwo.Length; j++)
                    {
                        Console.WriteLine(final.QTypeTwo[j].ToString());
                        Console.WriteLine("Please Enter The Answer Id (1 For True | 2 For False");
                        int.TryParse(Console.ReadLine(), out int answer);
                        AnswersEnterTrue[j] = answer - 1;
                        if (answer == final.QTypeTwo[j].RightAnswer)
                            sum += final.QTypeOne[j].mark;
                        Console.Clear();
                    }
                    int totalGrade = 0;
                    for (int j = 0; j < final.QTypeOne.Length; j++)
                    {
                        Console.WriteLine($"Question {j + 1} : {final.QTypeOne[j].Body}");
                        Console.WriteLine($"Your Answer => {final.QTypeOne[j].AnswerList[AnswersEnterMCQ[j]].AnswerText}");
                        Console.WriteLine($"Right Answer => {final.QTypeOne[j].AnswerList[final.QTypeOne[j].RightAnswer - 1].AnswerText}");
                        totalGrade += final.QTypeOne[j].mark;
                    }
                    for (int j = 0; j < final.QTypeTwo.Length; j++)
                    {
                        Console.WriteLine($"Question {j + 1} : {final.QTypeTwo[j].Body}");
                        Console.WriteLine($"Your Answer => {final.QTypeTwo[j].AnswerList[AnswersEnterTrue[j]].AnswerText}");
                        Console.WriteLine($"Right Answer => {final.QTypeTwo[j].AnswerList[final.QTypeTwo[j].RightAnswer - 1].AnswerText}");
                        totalGrade += final.QTypeTwo[j].mark;
                    }
                    Console.WriteLine($"Your Grade is {sum} from {totalGrade}");
                    Console.WriteLine($"Time = {finishTime - DateTime.Now}");
                    Console.WriteLine("Thank You");
                }
            }
        }
    }
}