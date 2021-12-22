using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeapSort : MonoBehaviour
{
    public Text inputtedArrayText;
    public Text manuallySortedArrayText;
    public InputField arrayInputField;

    public int sizeCounter = 0;
    public Text sizeText;

    public void sort(int[] arr)
    {
        int n = arr.Length;

        // Build heap (rearrange array)
        for (int i = n / 2 - 1; i >= 0; i--)
            heapify(arr, n, i);

        // One by one extract an element from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // call max heapify on the reduced heap
            heapify(arr, i, 0);
        }
    }

    // To heapify a subtree rooted with node i which is
    // an index in arr[]. n is size of heap
    void heapify(int[] arr, int n, int i)
    {
        int largest = i; // Initialize largest as root
        int l = 2 * i + 1; // left = 2*i + 1
        int r = 2 * i + 2; // right = 2*i + 2

        // If left child is larger than root
        if (l < n && arr[l] > arr[largest])
            largest = l;

        // If right child is larger than largest so far
        if (r < n && arr[r] > arr[largest])
            largest = r;

        // If largest is not root
        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify the affected sub-tree
            heapify(arr, n, largest);
        }
    }

    public void ManualInputHeapSort()
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

        // Perform the heap sort on the integer array
        HeapSort ob = new HeapSort();
        ob.sort(intArray);

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