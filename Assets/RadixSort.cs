using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadixSort : MonoBehaviour
{
    public Text inputtedArrayText;
    public Text manuallySortedArrayText;
    public InputField arrayInputField;

    public int sizeCounter = 0;
    public Text sizeText;

    public static int getMax(int[] arr, int n)
    {
        int mx = arr[0];
        for (int i = 1; i < n; i++)
            if (arr[i] > mx)
                mx = arr[i];
        return mx;
    }

    // A function to do counting sort of arr[] according to
    // the digit represented by exp.
    public static void countSort(int[] arr, int n, int exp)
    {
        int[] output = new int[n]; // output array
        int i;
        int[] count = new int[10];

        // initializing all elements of count to 0
        for (i = 0; i < 10; i++)
            count[i] = 0;

        // Store count of occurrences in count[]
        for (i = 0; i < n; i++)
            count[(arr[i] / exp) % 10]++;

        // Change count[i] so that count[i] now contains
        // actual
        //  position of this digit in output[]
        for (i = 1; i < 10; i++)
            count[i] += count[i - 1];

        // Build the output array
        for (i = n - 1; i >= 0; i--)
        {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }

        // Copy the output array to arr[], so that arr[] now
        // contains sorted numbers according to current
        // digit
        for (i = 0; i < n; i++)
            arr[i] = output[i];
    }

    // The main function to that sorts arr[] of size n using
    // Radix Sort
    public static void radixsort(int[] arr, int n)
    {
        // Find the maximum number to know number of digits
        int m = getMax(arr, n);

        // Do counting sort for every digit. Note that
        // instead of passing digit number, exp is passed.
        // exp is 10^i where i is current digit number
        for (int exp = 1; m / exp > 0; exp *= 10)
            countSort(arr, n, exp);
    }

    // Driver Code
    public void ManuallyRadixSort()
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

        // Function Call
        radixsort(intArray, sizeCounter);

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
