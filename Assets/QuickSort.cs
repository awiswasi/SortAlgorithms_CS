using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuickSort : MonoBehaviour
{
    public Text inputtedArrayText;
    public Text manuallySortedArrayText;
    public InputField arrayInputField;

    public int sizeCounter = 0;
    public Text sizeText;

    static public int Partition(int[] arr, int left, int right)
    {
        int pivot;
        pivot = arr[left];
        while (true)
        {
            while (arr[left] < pivot)
            {
                left++;
            }
            while (arr[right] > pivot)
            {
                right--;
            }
            if (left < right)
            {
                int temp = arr[right];
                arr[right] = arr[left];
                arr[left] = temp;
            }
            else
            {
                return right;
            }
        }
    }

    static public void quickSort(int[] arr, int left, int right)
    {
        int pivot;
        if (left < right)
        {
            pivot = Partition(arr, left, right);
            if (pivot > 1)
            {
                quickSort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                quickSort(arr, pivot + 1, right);
            }
        }
    }

    public void ManuallyQuickSort()
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

        quickSort(intArray, sizeCounter-1, sizeCounter+1);

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

    public void ExitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
