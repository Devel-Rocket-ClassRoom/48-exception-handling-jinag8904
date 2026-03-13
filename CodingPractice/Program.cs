using System;
using System.Collections.Generic;

// 1.
{
    int[] ints = new int[2];
    try
    {
        ints[10] = 0;
    }
    catch (Exception ex)
    {
        Console.WriteLine("에러 발생함.");
    }
}