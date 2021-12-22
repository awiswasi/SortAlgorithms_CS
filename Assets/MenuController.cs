using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject quickSortButton;
    public GameObject heapSortButton;
    public GameObject mergeSortButton;
    public GameObject bubbleSortButton;
    public GameObject radixSortButton;
    public GameObject bucketSortButton;
    public GameObject quitAppButton;

    public GameObject quickSort;
    public GameObject quickSortTest;
    public GameObject heapSort;
    public GameObject mergeSort;
    public GameObject bubbleSort;
    public GameObject radixSort;
    public GameObject bucketSort;
    public GameObject bucketSortTest;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        quickSortButton.SetActive(true);
        heapSortButton.SetActive(true);
        mergeSortButton.SetActive(true);
        bubbleSortButton.SetActive(true);
        radixSortButton.SetActive(true);
        bucketSortButton.SetActive(true);
        quitAppButton.SetActive(true);

        quickSort.SetActive(false);
        heapSort.SetActive(false);
        mergeSort.SetActive(false);
        bubbleSort.SetActive(false);
        radixSort.SetActive(false);
        bucketSort.SetActive(false);
    }

    // Quick Sort
    public void OnQSButtonClicked()
    {
        mainMenu.SetActive(false);
        quickSortButton.SetActive(false);
        heapSortButton.SetActive(false);
        mergeSortButton.SetActive(false);
        bubbleSortButton.SetActive(false);
        radixSortButton.SetActive(false);
        bucketSortButton.SetActive(false);
        quitAppButton.SetActive(false);

        quickSortTest.SetActive(true);
    }

    // Heap Sort
    public void OnHSButtonClicked()
    {
        mainMenu.SetActive(false);
        quickSortButton.SetActive(false);
        heapSortButton.SetActive(false);
        mergeSortButton.SetActive(false);
        bubbleSortButton.SetActive(false);
        radixSortButton.SetActive(false);
        bucketSortButton.SetActive(false);
        quitAppButton.SetActive(false);

        heapSort.SetActive(true);
    }

    // Merge Sort
    public void OnMSButtonClicked()
    {
        mainMenu.SetActive(false);
        quickSortButton.SetActive(false);
        heapSortButton.SetActive(false);
        mergeSortButton.SetActive(false);
        bubbleSortButton.SetActive(false);
        radixSortButton.SetActive(false);
        bucketSortButton.SetActive(false);
        quitAppButton.SetActive(false);

        mergeSort.SetActive(true);
    }

    // Bubble Sort
    public void OnBSButtonClicked()
    {
        mainMenu.SetActive(false);
        quickSortButton.SetActive(false);
        heapSortButton.SetActive(false);
        mergeSortButton.SetActive(false);
        bubbleSortButton.SetActive(false);
        radixSortButton.SetActive(false);
        bucketSortButton.SetActive(false);
        quitAppButton.SetActive(false);

        bubbleSort.SetActive(true);
    }

    // Radix Sort
    public void OnRSButtonClicked()
    {
        mainMenu.SetActive(false);
        quickSortButton.SetActive(false);
        heapSortButton.SetActive(false);
        mergeSortButton.SetActive(false);
        bubbleSortButton.SetActive(false);
        radixSortButton.SetActive(false);
        bucketSortButton.SetActive(false);
        quitAppButton.SetActive(false);

        radixSort.SetActive(true);
    }

    public void OnBuckSButtonClicked()
    {
        mainMenu.SetActive(false);
        quickSortButton.SetActive(false);
        heapSortButton.SetActive(false);
        mergeSortButton.SetActive(false);
        bubbleSortButton.SetActive(false);
        radixSortButton.SetActive(false);
        bucketSortButton.SetActive(false);
        quitAppButton.SetActive(false);

        bucketSortTest.SetActive(true);
    }

    public void OnQuitProgramClicked()
    {
        Application.Quit();
    }
}
