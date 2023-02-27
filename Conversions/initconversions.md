# Init Conversions

The first thing the CPU looks for while in idle
is an Init byte. These bytes influence the kernel 
space therefore will not be seen often.


|   Byte    |    Mapping    |   Description  |
|-----------|---------------|----------------|
|   0xA1    | CreateMethod()|Creates methdod |
|   0XA2    |  CreateVar()  |Creates variable|