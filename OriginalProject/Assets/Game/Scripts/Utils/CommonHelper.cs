using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHelper
{
    public static int[] RandomNums(int value, int count)
    {
        return RandomNums(0, value, count);
    }
    public static int[] RandomNums(int startv, int endv, int count)
    {
        int total = endv - startv;
        int[] sequence = new int[total];
        int[] output = new int[count];

        for (int i = 0; i < total; i++)
        {
            sequence[i] = i;
        }

        int end = total - 1;

        for (int i = 0; i < count; i++)
        {
            int num = UnityEngine.Random.Range(0, end + 1);
            output[i] = sequence[num] + startv;
            sequence[num] = sequence[end];
            end--;
        }
        return output;

    }
}
