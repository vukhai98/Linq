using System;
using System.Collections.Generic;
using System.Text;

namespace SetOperators
{
    class  StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentId == y.StudentId 
                && x.StudentName.ToLower() == y.StudentName.ToLower())
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.StudentId.GetHashCode();
        }
    }
}
