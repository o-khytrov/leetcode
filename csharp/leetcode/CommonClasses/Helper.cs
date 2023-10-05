using System;
using System.Collections.Generic;
using System.Text.Json;

namespace leetcode.CommonClasses;

public class Helper
{
    public static TreeNode InsertLevelOrder(int?[] arr, int i)
    {
        TreeNode root = null;
        // Base case for recursion
        if (i < arr.Length && arr[i] is not null)
        {
            root = new TreeNode(arr[i].Value);

            // insert left child
            root.left = InsertLevelOrder(arr, 2 * i + 1);

            // insert right child
            root.right = InsertLevelOrder(arr, 2 * i + 2);
        }

        return root;
    }

    // Function to print tree
    // nodes in InOrder fashion
    public void InOrder(TreeNode? root)
    {
        if (root != null)
        {
            InOrder(root.left);
            InOrder(root.right);
        }
    }

    public static TreeNode Json2BinaryTree(string json)
    {
        var array = JsonSerializer.Deserialize<int?[]>(json)
                    ?? throw new ArgumentException("Invalid Json");
        return InsertLevelOrder(array, 0);
    }

    public static ListNode Json2LinkedList(string json)
    {
        var list = JsonSerializer.Deserialize<int[]>(json);
        var root = new ListNode();
        var head = root;
        for (int i = 0; i < list.Length; i++)
        {
            head.val = list[i];
            if (i < list.Length - 1)
            {
                head.next = new ListNode();
            }

            head = head.next;
        }

        return root;
    }

    public static string LinkedList2Json(ListNode root)
    {
        var head = root;
        var list = new List<int>();
        while (head is not null)
        {
            list.Add(head.val);
            head = head.next;
        }

        return JsonSerializer.Serialize(list);
    }
}