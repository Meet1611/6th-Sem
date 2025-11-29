#include<stdio.h>

int main() {
    FILE *file;
    file = fopen("demo.txt", "r");
    char ch;
    int cc = 0, sc = 0, tc = 0, lc = 0, wc = 0;

    while(fscanf(file, "%c", &ch) != -1) {
        if(ch == '\t') {
            tc++;
        } else if (ch == ' ') {
            sc++;
        } 
        else if (ch == '\n') {
            lc++;
        }
        cc++;
    }

    fclose(file);

    printf("%d %d %d %d %d", cc, sc, tc, wc, lc + 1);

    return 0;
}