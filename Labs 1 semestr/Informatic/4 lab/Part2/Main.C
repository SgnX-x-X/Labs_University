#include <stdio.h>
#include <stdlib.h>
#include <math.h>
double DoubleFactorial(int n)
{   
    double result = 1;
    if(n==0) return 1;
    if (n % 2 == 0) for (int i = 2; i <= n; i+=2) result *= i;
    else for (int i = 1; i <= n; i+=2) result *= i;
    return result;
}
double Calculate(double x,int N)
{
    double last_element = -1.0;
    double result = -1.0;
    for(int n = 0; n < N;n++) 
    {
        double numenator = (2.0*n+1.0)*x*x;
        double denominator = (2.0*n-1.0)*(2.0*n+2.0);
        last_element*= (numenator/denominator);
        result+=last_element;
    }
    return result;
}
double Calculate2(double x,int N)
{
    double result = 0;
    for(int n = 0;n<=N;n++) result+=(((2.0*n-1.0)*pow(x,2.0*n))/DoubleFactorial(2*n));
    return result;
}
int main()
{   
    int N;
    double x;
    printf("Введите число:");
    scanf("%lg", &x);  
    printf("Введите число членов ряда:");
    scanf("%d", &N);  
    printf("Итоговая сумма рекурентном методом: %lg \n",Calculate(x,N));
    printf("Итоговая сумма на прямую: %lg \n",Calculate2(x,N));
    system("pause");
    return 0;
}