using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeSort : MonoBehaviour
{
    public Text inputtedArrayText;
    public Text manuallySortedArrayText;
    public InputField arrayInputField;

    public int sizeCounter = 0;
    public Text sizeText;

    // Merges two subarrays of []arr.
    // First subarray is arr[l..m]
    // Second subarray is arr[m+1..r]
    void merge(int[] arr, int l, int m, int r)
    {
        // Find sizes of two
        // subarrays to be merged
        int n1 = m - l + 1;
        int n2 = r - m;

        // Create temp arrays
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];

        // Merge the temp arrays

        // Initial indexes of first
        // and second subarrays
        i = 0;
        j = 0;

        // Initial index of merged
        // subarray array
        int k = l;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        // Copy remaining elements
        // of L[] if any
        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        // Copy remaining elements
        // of R[] if any
        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    // Main function that
    // sorts arr[l..r] using
    // merge()
    void sort(int[] arr, int l, int r)
    {
        if (l < r)
        {
            // Find the middle
            // point
            int m = l + (r - l) / 2;

            // Sort first and
            // second halves
            sort(arr, l, m);
            sort(arr, m + 1, r);

            // Merge the sorted halves
            merge(arr, l, m, r);
        }
    }


    // Driver code
    public void ManuallyMergeSort()
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

        // Perform the merge sort on the integer array
        MergeSort ob = new MergeSort();
        ob.sort(intArray, 0, intArray.Length - 1);

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