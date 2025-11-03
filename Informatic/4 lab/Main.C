#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
void process_line(char *line,FILE *out)
{
    int arrNum[10] = {0};
    for (int i = 0; line[i] != '\0'; i++) 
    {
        if (isdigit(line[i])) 
        {
            int num = line[i] - '0';
            arrNum[num] = 1;
        }
    }
    char allMissingNum[11];
    int missingNum = 0;
    for (int i = 0; i <= 9; i++) 
    {
        if (arrNum[i] == 0) 
            {
                allMissingNum[missingNum++] = i + '0'; 
            }
    }
    if (missingNum == 0) 
    {
        fprintf(out, "-1\n");
    } 
    else if (missingNum == 1 && allMissingNum[0] == '0')
            {
                fprintf(out, "0\n"); 
            } 
        else 
        {
            char number[10];
            int numCount = 0;
            for (int i = 0; i < missingNum; i++) 
                {
                    if (allMissingNum[i] != '0') 
                    {
                        number[numCount++] = allMissingNum[i];
                    }
                }
            if (numCount > 0)
            {
                number[numCount] = '\0'; 
                fprintf(out, "%s\n", number);
            }
        }
}
int main()
{
    printf("Hello world\n");
    FILE* in;
    FILE* out;
    in = fopen("input.txt","r");
    out = fopen("output.txt","w");
    char line[1024];
    while (fgets(line, 1024,in) != NULL) 
    {
        size_t len = strlen(line);
        if (len > 0 && line[len - 1] == '\n')
        {
            line[len - 1] = '\0';
        }
        process_line(line, out);
    }
    fclose(in);
    fclose(out);
    return 0;
}

