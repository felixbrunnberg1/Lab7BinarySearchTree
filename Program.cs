namespace Lab7BinarySearchTree
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    //Console.WriteLine("Hello, World!");
        //    BinarySearchTree bst = new BinarySearchTree(20);
        //    //bst.AddRecursive(19);
        //    //bst.AddRecursive(21);
        //    //bst.AddRecursive(22);
        //    //Console.WriteLine(bst.root.Left);
        //    //Console.WriteLine(bst.root.Right);
        //    //Console.WriteLine(bst.root.Right.Right);
        //    //Console.WriteLine();

        //    //Console.WriteLine(bst.SearchIterative(22));
        //    //Console.WriteLine(bst.SearchRecursive(22));
        //    //try
        //    //{
        //    //    Console.WriteLine(bst.SearchIterative(23));
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine(ex.Message);
        //    //}
        //    //try
        //    //{
        //    //    Console.WriteLine(bst.SearchRecursive(23));
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine(ex.Message);
        //    //}

        //    bst.AddRecursive(25);
        //    bst.AddRecursive(15);
        //    bst.AddRecursive(18);
        //    bst.AddRecursive(19);
        //    bst.AddRecursive(16);
        //    bst.AddRecursive(10);

        //    bst.root = bst.DeleteIterative(15);
        //    bst.InorderTraversal(bst.root);
        //    TreeNode next = bst.GetNextInorder(21);
        //    Console.WriteLine();
        //    Console.WriteLine(next.Value);
        //}

        public static void Main(string[] args)
        {
            BookingSchedule bookingSchedule = new BookingSchedule();
            // Add some events
            Event haircutEvent = new Event("Haircut", new DateTime(2024, 5, 1, 10, 30, 0));
            bookingSchedule.AddEvent(haircutEvent);
            Event otherEvent1 = new Event("Event 1", new DateTime(2024, 5, 15, 13, 0, 0));
            bookingSchedule.AddEvent(otherEvent1);
            Event otherEvent2 = new Event("Event 2", new DateTime(2024, 5, 20, 11, 0, 0));
            bookingSchedule.AddEvent(otherEvent2);
            Event otherEvent3 = new Event("Event 3", new DateTime(2024, 6, 1, 14, 0, 0));
            bookingSchedule.AddEvent(otherEvent3);
            // Find the next available event after a given time
            DateTime startTime = new DateTime(2024, 5, 15, 13, 0, 0);
            Event nextAvailableEvent = bookingSchedule.FindNextAvailableEvent(startTime);
            if (nextAvailableEvent != null)
            {
                Console.WriteLine($"Next available event after {startTime}: {nextAvailableEvent.EventName} at { nextAvailableEvent.EventDate}");
            }
            else
            {
                Console.WriteLine($"No available event found after {startTime}");
            }
            // Show all events after a given date and time
            Console.WriteLine($"\nEvents after {startTime}:");
            bookingSchedule.ShowEventsAfter(startTime);
        }
    }
}
