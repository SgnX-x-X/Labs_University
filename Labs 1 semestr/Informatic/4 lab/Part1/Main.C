#include <stdio.h>
#include <stdlib.h>
#include <math.h>
int F(int N)
{
    if(N<2)return 1;
    if (N%3==0)return F(N/3)-1;
    else return F(N-1)+7;  
}
int Sum(int X)
{
    int sum=0;
    X=abs(X);
    while(X)
    {
        int digit = X%10;
        if(digit%2==0)sum+=digit;
        X/=10;
    }
    return sum;
}
int main()
{
    int count=0;
    for(int i=1;i<=100000;i++)if(F(i)==35)count++;
    int num;
    printf("Введите число:");
    scanf("%d", &num);
    printf("1. количество значений для которых функция равна 35: %d \n 2. сумма чётных чисел результата вычисления: %d \n", count, Sum(F(num)));
    scanf("%d", &num);
    return 0;
}
