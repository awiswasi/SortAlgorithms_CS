using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketSort : MonoBehaviour
{
    public Text inputtedArrayText;
    public Text manuallySortedArrayText;
    public InputField arrayInputField;

    public int sizeCounter = 0;
    public Text sizeText;

    static void bucketSort(int[] arr, int n)
    {
        if (n <= 0)
            return;

        // 1) Create n empty buckets
        List<int>[] buckets = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            buckets[i] = new List<int>();
        }

        // 2) Put array elements in different buckets
        for (int i = 0; i < n; i++)
        {
            int idx = arr[i] * n;
            buckets[idx].Add(arr[i]);
        }

        // 3) Sort individual buckets
        for (int i = 0; i < n; i++)
        {
            buckets[i].Sort();
        }

        // 4) Concatenate all buckets into arr[]
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < buckets[i].Count; j++)
            {
                arr[index++] = buckets[i][j];
            }
        }
    }

    public void ManuallyBucketSort()
    {
        inputtedArrayText.text = arrayInputField.text;
        // StringBuilder to append the array values to a string for printing
        System.Text.StringBuilder sortedArray = new System.Text.StringBuilder();
        int[] arr = new int[sizeCounter + 1];
        int n = arr.Length;

        string input = arrayInputField.text;
        // String delimiter splitting to get rid of the input format commas
        string[] stringArray = input.Split(new string[] { ", " },
            StringSplitOptions.RemoveEmptyEntries);
        int length = stringArray.Length;
        // Instantiate a new int array to save the string values of the inputted array
        int[] intArray = new int[length];
        // For loop to convert the string array to an int array for heap sort
        for (int i = 0; i < length; i++)
        {
            intArray[i] = Convert.ToInt32(stringArray[i]);
            sizeCounter++;
        }

        // Perform the bucket sort on the integer array
        bucketSort(intArray, sizeCounter);

        // For loop to append the values of the sorted integer array to a new string to output
        for (int i = 0; i < sizeCounter; i++)
        {
            if (i < sizeCounter - 1)
            {
                sortedArray.Append(intArray[i]);
                sortedArray.Append(", ");
            }
            else
            {
                sortedArray.Append(intArray[i]);
            }

        }

        sizeText.text = "Size of array is \n" + sizeCounter.ToString();
        manuallySortedArrayText.text = sortedArray.ToString();

        sizeCounter = 0;
    }
}