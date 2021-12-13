using System;
using System.Collections.Generic;
using System.Text;

namespace QuantifierOperators
{
    class StudentComparer :IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.studentId == y.studentId && x.studentName.ToLower() == y.studentName.ToLower())
            {
                return true;
            }
            return false;
        }

       public int GetHashCode(Student obj)
        {
            return GetHashCode();
        }
    }
}
