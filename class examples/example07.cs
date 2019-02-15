using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class BalancedParenthesisChecker
    {
        static void MainParens(string[] args)
        {
            bool b1 = ParensAreBalanced("()");
            bool b2 = ParensAreBalanced("[]");
            bool b3 = ParensAreBalanced("{}");
            bool b4 = ParensAreBalanced("[][[]]");
            bool b5 = ParensAreBalanced("[]([{}])");

            bool b6 = ParensAreBalanced("()[");
            bool b9 = ParensAreBalanced("([)]");
            bool b7 = ParensAreBalanced("}{");
            bool b8 = ParensAreBalanced("[]}");
        }

        private static Dictionary<char, char> openCloseParensPairs = 
            new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

        public static bool ParensAreBalanced(string str)
        {
            Stack<char> openParens = new Stack<char>();
            int strIndex = 0;
            while (strIndex < str.Length)
            {
                if (IsOpenParen(str[strIndex]))
                {
                    openParens.Push(str[strIndex]);
                }
                else if (IsCloseParen(str[strIndex]))
                {
                    // Question: what check is missing here?
                    if (openParens.Count() > 0)
                    {
                        char lastOpenParenSeen = openParens.Pop();
                        if (openCloseParensPairs[str[strIndex]] != lastOpenParenSeen)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                ++strIndex;
            }

            return openParens.Count == 0;
        }

        private static bool IsOpenParen(char ch)
        {
            bool isOpenParen = false;

            switch (ch)
            {
                case '(':
                case '[':
                case '{':
                    isOpenParen = true;
                    break;
            }

            return isOpenParen;
        }

        private static bool IsCloseParen(char ch)
        {
            bool isCloseParen = false;

            switch (ch)
            {
                case ')':
                case ']':
                case '}':
                    isCloseParen = true;
                    break;
            }

            return isCloseParen;
        }

    }
}
