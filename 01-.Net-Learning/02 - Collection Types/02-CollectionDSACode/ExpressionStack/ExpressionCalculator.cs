using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CollectionDSACode.ExpressionStack
{
    public class ExpressionCalculator
    {
        //the number which an operation is to be done.
        Stack<int> _operandStack = new Stack<int>();
        //the symbol or keyword that represents a specific mathematical or logical action
        Stack<string> _operatorStack = new Stack<string>();

        //calculator only + - or * /, integer < 10
        public Stack<int> Calculate_v1(string expression)
        {
            int index = 0;
            string currentOperator = string.Empty;
            while (index < expression.Length)
            {
                var currentChar = expression.Substring(index, 1);
                if (IsNumber(currentChar))
                {
                    _operandStack.Push(int.Parse(currentChar));
                }
                else
                {
                    while (_operatorStack.Count != 0)
                    {
                        var opnd2 = _operandStack.Pop();
                        var opnd1 = _operandStack.Pop();

                        currentOperator = _operatorStack.Pop();

                        var calculatedTemp = Operate(currentOperator, opnd1, opnd2);
                        _operandStack.Push(calculatedTemp);
                    }

                    _operatorStack.Push(currentChar);
                }

                index++;
            }

            //in the end, the operand stack should contains 2 number
            //operator should only contain 1 symbol

            var left = _operandStack.Pop();
            var right = _operandStack.Pop();

            var lastOperator = _operatorStack.Pop();

            var result = Operate(lastOperator, right, left);
            _operandStack.Push(result);
            return _operandStack;
        }

        //calculation support *, /, integer < 10
        public Stack<int> Calculate_v2(string expression)
        {
            int index = 0;
            string currentOperator = string.Empty;
            while (index < expression.Length)
            {
                var currentChar = expression.Substring(index, 1);
                if (IsNumber(currentChar))
                {
                    _operandStack.Push(int.Parse(currentChar));
                }
                else
                {
                    while (_operatorStack.Count != 0 && Precedence(_operatorStack.Peek(), currentChar))
                    {
                        var opnd2 = _operandStack.Pop();
                        var opnd1 = _operandStack.Pop();

                        currentOperator = _operatorStack.Pop();

                        var calculatedTemp = Operate(currentOperator, opnd1, opnd2);
                        _operandStack.Push(calculatedTemp);
                    }

                    _operatorStack.Push(currentChar);
                }

                index++;
            }

            //in the end, the operand stack should contains 2 number
            //operator should only contain 1 symbol

            var left = _operandStack.Pop();
            var right = _operandStack.Pop();

            var lastOperator = _operatorStack.Pop();

            var result = Operate(lastOperator, right, left);
            _operandStack.Push(result);
            return _operandStack;
        }

        //calculation support *, / and ( ), integer more than 10
        public Stack<int> Calculate_v3(string expression)
        {
            int index = 0;
            string currentOperator = string.Empty;
            while (index < expression.Length)
            {
                var greedyNumberLength = IsNumber(expression.Substring(index, 1)) ? GreedingNumber(index, expression) : 1;
                var currentChar = expression.Substring(index, greedyNumberLength);
                if (IsNumber(currentChar))
                {
                    _operandStack.Push(int.Parse(currentChar));
                }
                else
                {
                    while (_operatorStack.Count != 0 && Precedence(_operatorStack.Peek(), currentChar))
                    {
                        var opnd2 = _operandStack.Pop();
                        var opnd1 = _operandStack.Pop();

                        currentOperator = _operatorStack.Pop();

                        var calculatedTemp = Operate(currentOperator, opnd1, opnd2);
                        _operandStack.Push(calculatedTemp);

                        if (currentChar == ")")
                        {
                            _operatorStack.Pop();//pop out the paired "("
                            break;
                        }
                    }

                    if (currentChar != ")") _operatorStack.Push(currentChar);
                }

                index = index + greedyNumberLength;
            }

            //in the end, the operand stack should contains 2 number
            //operator should only contain 1 symbol

            var left = _operandStack.Pop();
            var right = _operandStack.Pop();

            var lastOperator = _operatorStack.Pop();

            var result = Operate(lastOperator, right, left);
            _operandStack.Push(result);
            return _operandStack;
        }

        private int GreedingNumber(int index, string expression)
        {
            int currentLength = 1;
            while (index + currentLength <= expression.Length)
            {
                if (IsNumber(expression.Substring(index, currentLength)))
                {
                    currentLength++;
                }
                else
                {
                    currentLength--;
                    break;
                }
            }

            return index + currentLength <= expression.Length ? currentLength : currentLength - 1;
        }

        private bool IsNumber(string symbol)
        {
            int digit = 0;
            try
            {
                digit = Int32.Parse(symbol);
                if (digit >= 0 || digit <= 9)
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        //决定操作符优先权
        private bool Precedence(string oper1, string oper2)
        {
            // normal operators 
            //if (oper1 == "$" && oper2 == "*") return true;
            //if (oper1 == "$" && oper2 == "/") return true;
            //if (oper1 == "$" && oper2 == "+") return true;
            //if (oper1 == "$" && oper2 == "-") return true;
            if (oper1 == "*" && oper2 == "/") return true;
            if (oper1 == "*" && oper2 == "+") return true;
            if (oper1 == "*" && oper2 == "-") return true;
            if (oper1 == "/" && oper2 == "+") return true;
            if (oper1 == "/" && oper2 == "-") return true;
            if (oper1 == "+" && oper2 == "-") return true;

            // braces operator 
            if (oper1 == "(") return false;
            if (oper2 == "(" && oper1 != ")") return false;
            if (oper2 == ")" && oper1 != "(") return true;
            return false;
        }

        private int Operate(string symbol, int opnd1, int opnd2)
        {
            try
            {
                switch (symbol)
                {
                    case "+": return (opnd1 + opnd2);
                    case "-": return (opnd1 - opnd2);
                    case "*": return (opnd1 * opnd2);
                    case "/": return (opnd1 / opnd2);
                    //case "$": return (Power(opnd1, opnd2));
                    default:
                        Console.WriteLine("Illegal Operation");
                        return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Illegal Operation");
                return 0;
            }
        }

    }
}
