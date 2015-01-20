// ConstantSum.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

int array[10000];

int countthem(int boundary)
{
    int count = 0;
    for (int i = 0; i < 10000; i++) {
        if (array[i] < boundary) count++;
    }
    return count;
}

int _tmain(int argc, _TCHAR* argv [])
{
    for (int i = 0; i < 10000; i++) array[i] = rand() % 10;

    for (int boundary = 0; boundary <= 10; boundary++) {
        LARGE_INTEGER liStart, liEnd;
        QueryPerformanceCounter(&liStart);

        int count = 0;
        for (int iterations = 0; iterations < 100; iterations++) {
            count += countthem(boundary);
        }

        QueryPerformanceCounter(&liEnd);
        printf("count=%7d, time = %I64d\n",
            count, liEnd.QuadPart - liStart.QuadPart);
    }
    return 0;
}
