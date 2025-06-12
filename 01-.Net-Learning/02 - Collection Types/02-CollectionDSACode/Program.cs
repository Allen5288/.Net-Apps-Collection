using _02_CollectionDSACode.ExpressionStack;

namespace _02_CollectionDSACode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Expression Stack Call
            Console.WriteLine("Expression stack....");

            ExpressionCalculator expression = new ExpressionCalculator();

            #region calculator only + - or * /, integer < 10
            var t = expression.Calculate_v1("3+6-8");
            Assert(1, t.Pop());

            t = expression.Calculate_v1("3+4+7-2+6-8");
            Assert(10, t.Pop());
            #endregion

            #region calculator only + - or * /, integer < 10
            t = expression.Calculate_v2("1+2*3-6");
            Assert(1, t.Pop());

            t = expression.Calculate_v2("2*3+4*5-9");
            Assert(17, t.Pop());
            #endregion

            #region calculation support *, / and ( ), integer more than 10
            var result = expression.Calculate_v3("4*3-1");
            Assert(11, result.Pop());
            result = expression.Calculate_v3("4*3+1");
            Assert(13, result.Pop());
            result = expression.Calculate_v3("5*(8-2)+8");
            Assert(38, result.Pop());

            result = expression.Calculate_v3("5*(8-2)+18");
            Assert(48, result.Pop());

            result = expression.Calculate_v3("5*(3+6)+18");
            Assert(63, result.Pop());

            result = expression.Calculate_v3("5*(2+8)+18");
            Assert(68, result.Pop());

            result = expression.Calculate_v3("3*(2*5)+10");
            Assert(40, result.Pop());

            result = expression.Calculate_v3("3*(2*8)+10");
            Assert(58, result.Pop());
            #endregion
            #endregion
        }

        private static void Assert(int expectedValue, int result)
        {
            if (result == expectedValue)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine($"Wrong: {expectedValue} != {result}");
            }
        }
    }
}
