#include<stdio.h>

int main() {
    FILE *file1;
    FILE *file2;
    file1 = fopen("demo.txt", "a");
    file2 = fopen("demo2.txt", "r");

    char ch;

    while(fscanf(file2, "%c", &ch) == 1) {
        fprintf(file1, "%c", ch);
    }

    fclose(file1);
    fclose(file2);
    
    return 0;
}