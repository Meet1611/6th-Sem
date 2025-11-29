#include<stdio.h>

int main() {
    FILE *file;
    file = fopen("demo.txt", "r");
    char ch;
    int isFirst = 1;

    while(fscanf(file, "%c", &ch) == 1) {
        if(ch >= 'a' && ch <= 'z') {
            if(isFirst == 1) {
                printf("%c", ch - 32);
                isFirst = 0;
            }
            else {
                printf("%c", ch);
            }
        }
        else {
            isFirst = 1;
            printf("%c", ch);
        }
    }

    fclose(file);
    return 0;
}