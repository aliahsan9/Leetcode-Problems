// Definition for singly-linked list node
public class ListNode {
    public int val; // Value of the node
    public ListNode next; // Reference to the next node in the list

    // Constructor to initialize the node with a value and next node reference
    public ListNode(int val = 0, ListNode next = null!) {
        this.val = val; // Assign the value to the node
        this.next = next; // Assign the next node reference
    }
}

// Class containing the solution to add two numbers represented by linked lists
public class Solution {
    // Method to add two numbers represented by linked lists l1 and l2
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode dummyHead = new ListNode(0); // Dummy head node to simplify result list construction
        ListNode current = dummyHead; // Pointer to the current node in the result list
        int carry = 0; // Variable to store carry-over value during addition

        // Loop until both lists are exhausted and there is no carry left
        while (l1 != null || l2 != null || carry != 0) {
            int val1 = l1 != null ? l1.val : 0; // Get value from l1, or 0 if l1 is null
            int val2 = l2 != null ? l2.val : 0; // Get value from l2, or 0 if l2 is null

            int sum = val1 + val2 + carry; // Calculate sum of values and carry
            carry = sum / 10; // Update carry for next iteration
            current.next = new ListNode(sum % 10); // Create new node with digit value and link to result list
            current = current.next; // Move current pointer to the new node

            if (l1 != null) l1 = l1.next; // Move l1 pointer to next node if not null
            if (l2 != null) l2 = l2.next; // Move l2 pointer to next node if not null
        }

        return dummyHead.next; // Return the head of the resulting linked list (skipping dummy head)
    }
}

// Optional: Example usage to demonstrate the AddTwoNumbers method
class Program {
    static void Main(string[] args) {
        // Example input: l1 = 2->4->3, l2 = 5->6->4
        ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3))); // Create first input list
        ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4))); // Create second input list

        Solution solution = new Solution(); // Instantiate the Solution class
        ListNode? result = solution.AddTwoNumbers(l1, l2); // Call AddTwoNumbers to get the result list

        // Print the resulting linked list
        while (result != null) { // Loop through the result list
            Console.Write(result.val); // Print the value of the current node
            if (result.next != null) Console.Write("->"); // Print arrow if not the last node
            result = result.next; // Move to the next node
        }
        Console.WriteLine(); // Print newline at the end
    }
}