using System.Collections.Generic;
using System.Text.Json;

namespace MiddleOfTheLinkedList;

public class Helper
{
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