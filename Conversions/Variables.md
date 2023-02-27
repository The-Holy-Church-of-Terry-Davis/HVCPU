# Variables

Variables are kept in memory only
when a method is being executed.
These variables are then either
transferred to the heap or are
dropped by the garbage collector.

Var declaration as bytes:
0xA1, 0x1, 


Variable types as bytes:

0xD1, Type
0xD2, Char
0xD3, Int
0xD4, Long
0xD5, String
0xD6, Byte
0xD7, Pointer