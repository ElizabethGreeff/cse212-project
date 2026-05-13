/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        // Create a queue with an invalid size (0).
        // The queue should default to a size of 10.
        // Expected Result: 
        // Queue should display with max_size=10.
        Console.WriteLine("Test 1");

        var cs = new CustomerService(0);
        Console.WriteLine(cs);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: 
        // Add customers until the queue is full.
        // Try to add one more customer.
        // Expected Result: 
        // The last customer should not be added.
        // A message to display that the queue is full should be printed.
        Console.WriteLine("Test 2");

        cs = new CustomerService(1);

        // Add the first customer
        Console.SetIn(new StringReader("Alice\na001\nPassword Reset\n"));
        cs.AddNewCustomer();


        // Try to add a second customer
        Console.SetIn(new StringReader("Bob\nb002\nSoftware Installation\n"));
        cs.AddNewCustomer();

        Console.WriteLine(cs);

        // Defect(s) Found:
        // The second customer was added to the queue.
        // This was because of the incorrect condition definign the sorting process.

        Console.WriteLine("=================");

        // Test 3
        // Scenario:
        // Serve First Customer
        // Expected Result:
        // The first customer should be removed from the queue and their information should be printed.

        Console.WriteLine("Test 3");

        cs = new CustomerService(5);

        Console.SetIn(new StringReader("Alice\na001\nPassword Reset\n"));
        cs.AddNewCustomer();

        Console.SetIn(new StringReader("Bob\nb002\nSoftware Installation\n"));
        cs.AddNewCustomer();

        Console.SetIn(new StringReader("Charlie\nc003\nHardware Failure\n"));
        cs.AddNewCustomer();

        cs.ServeCustomer();
        cs.ServeCustomer();
        cs.ServeCustomer();

        // Defect(s) Found:
        // The first customer was removed before displayiny the name.



        // Test 4
        // Scenario:
        // Attempt to serve a customer from an empty queue.
        // Expected Result:
        // An error message should be diasplayed instead of printing or crasing.

        Console.WriteLine("Test 4");

        cs = new CustomerService(5);

        cs.ServeCustomer();

        // Defect(s) Found:
        // An error message was not displayed, it simply crashed.


    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}