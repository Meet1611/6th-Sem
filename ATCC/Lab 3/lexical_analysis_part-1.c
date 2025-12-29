#include<stdio.h>

int main() {
    FILE* file1;
    FILE* file2;
    file1 = fopen("prog.c", "r");
    file2 = fopen("analysis-1.c", "w");
    char ch;

    while(fscanf(file1, "%c", &ch) == 1) {
        if(ch == '/') {
            fscanf(file1, "%c", &ch);
            if(ch == '/') {
                while(ch != '\n') {
                    fscanf(file1, "%c", &ch);
                }
            }
            else if(ch =='*') {
                repeat: 
                    while(ch != '*') {
                        fscanf(file1, "%c", &ch);
                    }
                    fscanf(file1, "%c", &ch);
                    if(ch != '/') {
                        goto repeat;
                    }
                    else
                        fscanf(file1, "%c", &ch);    
            }
        }
        else {
            fprintf(file2, "%c", ch);
        }
    }
    return 0;
}