#include<stdio.h>

int main() {
    FILE* file1;
    file1 = fopen("analysis-1.c", "r");
    char ch, str;

    while(fscanf(file1, "%c", &ch) == 1) {
        
    }
    
    return 0;
}