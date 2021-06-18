using System;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            int indexStudent = 0;
            string userOption = reciveUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        Console.WriteLine("Type students names");
                        Student student = new Student();
                        student.Name = Console.ReadLine();
                        Console.WriteLine("Type students score");
                        if (decimal.TryParse(Console.ReadLine(), out decimal score))
                        {
                            student.Score =  score;
                        }
                        else
                        {
                            throw new ArgumentException("Score should be a numeric value");
                        }
                        
                        students[indexStudent] = student;
                        indexStudent++;

                        break;
                    case "2":
                        foreach (var s in students)
                        {   
                            if(!string.IsNullOrEmpty(s.Name))
                            {
                                Console.WriteLine($"Student: {s.Name} - Score: {s.Score}");
                            }
                        }
                        break;
                    case "3":
                        decimal totalScore = 0;
                        var nrStudents = 0;
                        for (int i = 0; i < students.Length; i++)
                        {
                           if(!string.IsNullOrEmpty(students[i].Name))
                            {
                                totalScore = totalScore + students[i].Score;
                                nrStudents++;
                            } 
                        }

                        var totalAverage = totalScore/nrStudents;

                        Grade geralGrade;

                        if(totalAverage < 2)
                        {
                            geralGrade = Grade.E;
                        }
                        else if(totalAverage < 4)
                        {
                            geralGrade = Grade.D;
                        }
                        else if(totalAverage < 6)
                        {
                            geralGrade = Grade.C;
                        }
                        else if(totalAverage < 8)
                        {
                            geralGrade = Grade.B;
                        }
                        else
                        {
                            geralGrade = Grade.A;
                        }


                        Console.WriteLine($"Average: {totalAverage} - Grade: {geralGrade}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = reciveUserOption();

            }
        }

        private static string reciveUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Insert new student");
            Console.WriteLine("2- List students");
            Console.WriteLine("3- Calculate overall average");
            Console.WriteLine("X-  Finish");
            Console.WriteLine();
            String userOption = Console.ReadLine();
            Console.WriteLine();
            return userOption;
        }
    }
}
