namespace DataStructuresAndAlgorithm;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    // Space complexity : O(n)
    // Time complexity : O(n log n)
    public void mergesort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            //sort left half
            mergesort(array, left, mid);
            //sort right half 
            mergesort(array, mid + 1, right);
            //merge sorted halves
            merge(array, left, mid, right);
        }
    }

    public void merge(int[] origin, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        for (int i = 0; i < n1; i++) leftArray[i] = origin[left + i];

        for (int j = 0; j < n2; j++) rightArray[j] = origin[mid + j + 1];

        int il = 0, ir = 0, OriginIndex = left;

        while (il < n1 && ir < n2)
        {
            if (leftArray[il] <= rightArray[ir])
            {
                origin[OriginIndex++] = leftArray[il++];
            }
            else
            {
                origin[OriginIndex++] = rightArray[ir++];
            }
        }
        while (il < n1)
        {
            origin[OriginIndex++] = leftArray[il++];
        }
        while (ir < n2)
        {
            origin[OriginIndex++] = rightArray[ir++];
        }
    }
}


public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int s = 0;
        for (int i = m; i < n + m; i++)
        {
            nums1[i] = nums2[s++];
        }
        mergeSort(0, n + m - 1);
        void mergeSort(int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                mergeSort(left, mid);
                mergeSort(mid + 1, right);
                merge(left, mid, right);
            }
        }
        void merge(int left, int mid, int right)
        {
            int sz1 = mid - left + 1;
            int sz2 = right - mid;
            int[] leftArray = new int[sz1];
            int[] rightArray = new int[sz2];
            for (int i = 0; i < sz1; i++)
            {
                leftArray[i] = nums1[left + i];
            }
            for (int i = 0; i < sz2; i++)
            {
                rightArray[i] = nums1[i + mid + 1];
            }
            int il = 0, ir = 0, k = left;
            while (il < sz1 && ir < sz2)
            {
                if (leftArray[il] <= rightArray[ir])
                {
                    nums1[k++] = leftArray[il++];
                }
                else
                {
                    nums1[k++] = rightArray[ir++];
                }
            }
            while (il < sz1)
            {
                nums1[k++] = leftArray[il++];
            }
            while (ir < sz2)
            {
                nums1[k++] = rightArray[ir++];
            }
        }
    }
}



// Optimal Approach
public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (n == 0) return;
        int len1 = nums1.Length;
        int end_idx = len1 - 1;
        while (n > 0 && m > 0)
        {
            if (nums2[n - 1] >= nums1[m - 1])
            {
                nums1[end_idx] = nums2[n - 1];
                n--;
            }
            else
            {
                nums1[end_idx] = nums1[m - 1];
                m--;
            }
            end_idx--;
        }
        while (n > 0)
        {
            nums1[end_idx] = nums2[n - 1];
            n--;
            end_idx--;
        }
    }
}