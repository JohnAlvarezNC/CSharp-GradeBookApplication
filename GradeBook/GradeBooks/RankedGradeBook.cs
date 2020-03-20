using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            base.Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            List<double> grades = new List<double>();
            grades.Add(averageGrade);
            if(base.Students.Count>=5)
            {
                
                foreach (Student students in base.Students.OrderByDescending(x => x.AverageGrade))
                {
                    
                    if (grades.Count <= (base.Students.Count * 0.20))
                    {
                        return 'A';
                    }
                    else if (grades.Count <= (base.Students.Count * 0.40))
                    {
                        return 'B';
                    }
                    else if (grades.Count <= (base.Students.Count * 0.60))
                    {
                        return 'C';
                    }
                    else if (grades.Count <= (base.Students.Count * 0.80))
                    {
                        return 'D';
                    }
                    else
                    {
                        return 'F';
                    }

                }

            }
            else
            {
                throw new InvalidOperationException("Ranked-grading requires minimum of 5 students to work");
               
            }
            return 'F';

        }
    }
}
