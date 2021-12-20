using System;
using System.Linq.Expressions;

namespace ExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<Student, bool>> teenAgerExpression = s => s.Age > 12 && s.Age < 20;
            Console.WriteLine("Expression: {0}", teenAgerExpression);
            Console.WriteLine("Expression Type: {0}", teenAgerExpression.NodeType);
            var parameter = teenAgerExpression.Parameters;
            foreach (var para in parameter)
            {
                Console.WriteLine("Parameter Name {0}", para.Name);
                Console.WriteLine("Parameter Type {0}", para.Type.Name);
            };

            var bodyExpr = teenAgerExpression.Body as BinaryExpression;
            Console.WriteLine("Left side of body Expression: {0}", bodyExpr.Left);  
            Console.WriteLine("Binary Expression Type: {0}", bodyExpr.NodeType);
            Console.WriteLine("Right side of body Expression: {0}", bodyExpr.Right);
            Console.WriteLine("Return Type: {0}", teenAgerExpression.ReturnType);

            Console.ReadKey();
            
        }
    }
}
