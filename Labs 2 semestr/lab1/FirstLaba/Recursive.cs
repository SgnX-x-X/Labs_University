using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLaba
{
    internal class Recursive
    {
        public static double Calculate(double x, int n, int i = 0, double currentTerm = 1.0)
        {
            {
                double result = 0;
                if (i >= n)
                {
                    result = 0;
                }
                else
                {
                    double nextTerm = currentTerm * x / (i + 1);
                    result = currentTerm + Calculate(x, n, i + 1, nextTerm); 
                }
                return result;
            }
        }
    }
}