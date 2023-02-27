#include "stdlib.h"
#include "lowlevel.h"

long GetCharPtr(char x)
{
    char* ret = malloc(sizeof(x));
    *ret = x; 

    return (long)x;
}

long GetBytePtr(char x)
{
    char* ret = malloc(sizeof(x));
    *ret = x; 

    return (long)x;
}

long GetStrPtr(char* x, int length)
{
    char** ret = malloc(length * sizeof(char *));
    for(int i = 0; i < length; i++)
    {
        char* val = malloc(sizeof(char));
        *val = x[i];

        ret[i] = val;
    }

    return (long)ret;
}

long GetIntPtr(int x)
{
    int* ret = malloc(sizeof(x));
    *ret = x;

    return (long)ret;
}

struct MemoryTuple GetRawPtr(int size)
{
    long addr = (long)malloc(size);

    struct MemoryTuple *pl = (struct MemoryTuple *)malloc(sizeof(struct MemoryTuple));
    pl->item1 = addr;
    pl->item2 = size;

    return *pl;
}

void freemem(long addr)
{
    free((void *)addr);
}

char GetChar(long addr)
{
    return *(char *)addr;
}

char* GetStr(long addr)
{
    return *(char **)addr;
}