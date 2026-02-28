namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n"+ new string('-',70) + "\n");
            Console.WriteLine("Assignment 02 OOP");
            Console.WriteLine("\n" + new string('-', 70) + "\n");

            #region Demo

            #region Encapsulation
            /*
             * is the principle of bundling data and behavior together and restricting direct access to an object's internal state.
             * 
             * The object owns its data and controls how others interact with it.
             * 
             * Encapsulation is about control, not hiding for no reason.
             * 
             * Without encapsulation, anyone can change data directly -> invalid data, bugs, and lost control.
             * 
             * The object decides:
             *   What can be seen from outside
             *   How data can be modified
             *   What rules are enforced
             *   
             * Why fields should be private:
             *   Prevents invalid state
             *   Forces rule-based changes
             *   Allows future modification
             *   
             *   private field + public method = Encapsulation in action
             *   private data + controlled access.
             *   
             *  EXP: in BankAccount class:
             *   balance is private — no one outside can touch it
             *   Deposit() validates before changing data ==> public method controls how balance changes
             *   GetBalance() allows reading without modifying
             * 
             * how do we provide that controlled access in C#?
             * 
             *   1. Properties => Most Common
             *   2. Getter & Setter Methods => Traditional Way => Separate GetX() and SetX() methods 
             * 
             * Both achieve the same goal — but Properties are the C# way.
             * 
             * 
             * 
             */

            // example of getter and setter methods for encapsulation
            /*
             *  
             *  
             *  class Employee
             *  {
             *         private int age;              // hidden field
             *       
             *         public int GetAge()           // getter method
             *         {
             *             return age;
             *         }
             *       
             *         public void SetAge(int value)  // setter method
             *         {
             *             if (value >= 18)            // validation rule
             *                 age = value;
             *         }
             *  }  
             *  
             */

            //Encapsulation Using Properties
            /*
             * 
             *  class Employee
             *  {
             *      private int age;              // backing field (hidden)
             *  
             *      public int Age                // property (controlled gate)
             *      {
             *          get { return age; }          // read access
             *          set
             *          {
             *              if (value >= 18)          // validation rule
             *                  age = value;
             *          }
             *      }
             *  }
             *  
             */

            //Property = same encapsulation as getter/setter methods, but cleaner C# syntax.


            #endregion

            #region Properties in C#
            /*
             * a class member that provides controlled access to data. 
             * It looks like a field from outside, but behaves like methods inside.
             * 
             * 
             * use Properties because :
             *     Hide internal fields
             *     Validate input
             *     Control read/write
             *     Object integrity
             *     
             *  Property Structure:
             *  
             *   private int age;             // backing field
             *   
             *   public int Age              // property name
             *   {
             *       get { return age; }        // read accessor
             *       set { age = value; }       // write accessor
             *   }   
             *     
             *    Always use Properties, never expose public fields. 
             *     
             */

            #region Field vs Property
            /*
             * ----------------------------------------------------------
             * | Field	               |        Property                |
             * ----------------------------------------------------------
             * | Direct data storage   |   Controlled access            |
             * | No validation	       | Can validate                   |
             * | Breaks encapsulation  |  Enforces encapsulation        |
             * | Public Field          |  Property with Validation      |
             * |--------------------------------------------------------|
             * 
             * 
             * 
             */
            #endregion

            // property types in C#:

            #region Read / Write Property
            /*
             * 
             *  Most common property type — both reading and writing allowed.
             * ============================================
             *   private int age;
             *   public int Age
             *   {
             *       get { return age; }          // can read 
             *       set { age = value; }          // can write 
             *   }
             *   ----------------------
             *   emp.Age = 25;       //  set works
             *   int x = emp.Age;    //  get works
             *   
             */
            #endregion

            #region Read-Only Property
            /*
             * 
             *  Ideal for identifiers — set once internally, read from outside.
             * ============================================
             *   private int age;
             *   public int Age
             *   {
             *       get { return age; }          // can read 
             *       // no set → can't write
             *   }
             *   ----------------------
             *   emp.Age = 25;       //  set => compile error
             *   int x = emp.Age;    //  get works
             *   
             */
            #endregion

            #region Write-Only Property
            /*
             * 
             * Rarely used — good for sensitive data like passwords that should never be read back.
             * ============================================
             *   private int age;
             *   public int Age
             *   {
             *       // no get → can't read 
             *       set { age = value; }          // can write 
             *   }
             *   -----------------------
             *   emp.Age = 25;       //  set works
             *   int x = emp.Age;    //  get => error
             *   
             */
            #endregion

            #region Auto-Implemented Property
            /*
             * 
             *  Quick and clean — but use only when no validation is needed.
             * ============================================
             * // No backing field needed — compiler creates it!
             *   public int Age { get; set; }
             * ----------------------
             *   emp.Age = 25;       //  set works
             *   int x = emp.Age;    //  get works
             *   
             *   // Same as writing:
             *   private int age;
             *   public int Age
             *   {
             *       get { return age; }          // can read 
             *       set { age = value; }          // can write 
             *   }
             *   
             *   
             */
            #endregion

            #region Property with Private Setter
            /*
             * Very common in domain models — read from outside, modify only through methods.
             * 
             *  Allows reading from outside, but only internal methods can change the value.
             * ============================================
             *   private int age;
             *   public int Age
             *   {
             *       get { return age; }          // can read 
             *       // set only inside class
             *       private set { age = value; }  // only internal write 
             *   }
             *   
             *   public void CelebrateBirthday()
             *   {
             *       Age++;  //  works inside class
             *   }
             *   ---------------------
             *   emp.Age = 25;       //  set => error (private)
             *   int x = emp.Age;    //  get works
             *   
             */

            #endregion

            #region Computed Property
            /*
             * No stored value — recalculated every time you read it.
             * ============================================
             *   private int quantity;
             *   private decimal unitPrice;
             *   
             *   public decimal TotalPrice            // no backing field!
             *   {
             *       get { return quantity * unitPrice; }  // calculated on the fly
             *   }
             *   -----------------------
             *   var total = order.TotalPrice;  //  always up-to-date
             * 
             */

            #endregion

            #region Expression-Bodied Property
            /*
             * Shorthand for read-only computed properties — cleaner syntax with =>.
             * 
             *  syntax for very simple properties — concise and clean.
             * ============================================
             *   private int quantity;
             *   private decimal unitPrice;
             *   
             *   public decimal TotalPrice => quantity * unitPrice;  // expression-bodied
             *   
             *   // Instead of writing:
             *   
             *    public decimal TotalPrice            // no backing field!
             *   {
             *       get { return quantity * unitPrice; }  // calculated on the fly
             *   }
             *   -----------------------
             *   var total = order.TotalPrice;  //  always up-to-date
             * 
             */
            #endregion

            #region Init-Only Property
            /*
             * Encourages immutability — once set, it can never change.
             * 
             * Settable only during object initialization — perfect for immutable data.
             * ============================================
             *   public string Name { get; init; }  // can set only during initialization
             *   -----------------------
             *   var person = new Person { Name = "Alice" };  // works
             *   person.Name = "Bob";  //  After creation error — can't change after init
             * 
             */
            #endregion

            //Which Property to Use
            /*
             * ----------------------------------------------------------------
             * | I need to...          	       |    Use this	               |
             * |---------------------------------------------------------------|
             * | Store simple data	           |  Auto-Property	               |
             * | Validate before setting	   |  Full Property	               |
             * | Read outside, set inside only |  Private Setter	           |
             * | Calculate from other fields   |  Computed / Expression	       |
             * | Set once, never change	       |  Init-Only	                   |
             * | Allow read, block write	   |  Read-Only	                   |
             * |---------------------------------------------------------------|
             * When in doubt: start with Auto-Property, upgrade to Full Property when you need validation.
             */

            #region Properties vs Methods in C#
            /*
            * Both properties and methods are used to interact with an object, but they serve different design purposes.
            * 
            * Properties are for data access — they should be quick and side-effect free. 
            * Methods are for actions — they can be slower and have side effects.
            * 
            * Use Properties when:
            *     Accessing data or state
            *     No significant processing
            *     No side effects
            *     Should feel like a field
            * 
            * Use Methods when:
            *     Performing an action
            *     Significant processing needed
            *     Side effects expected
            *     Not just data access
            * 
            * 
            * Simple data access should be a property, not a method!
            * 
            * Rule:
            *   Use a property for data (state)
            *   Use a method for actions (behavior)
            *   If it needs parameters → it must be a method
            *   
            *   
            *   -------------------------------------------------------------------------------       
            *   | Aspect        |      Property                |    Method                     |
            *   |------------------------------------------------------------------------------|
            *   | Purpose       | Expose object state (data)   | Perform an action / behavior  |
            *   | Syntax Style  | Looks like a field           | Looks like a function         |
            *   | Parameters    | No parameters                | Can take parameters           |
            *   | Examples      | Name, Age, Balance           | Deposit(), Withdraw()         |
            *   -------------------------------------------------------------------------------
            */
            #endregion

            #endregion

            #region Indexers in C#
            /*
             * lets an object be accessed using array-like syntax ([]), just like lists or arrays.
             * 
             * A special type of property that allows objects to be indexed like arrays.
             * 
             * Provides array-like access to internal collections — makes the object feel like a container.
             * 
             * Indexer = property with a parameter. Uses this[...] instead of a name.
             * 
             * Indexers aren't just for int — you can use string, or any type as the key!
             * 
             * Syntax:
             *   public returnType this[parameterList]
             *   {
             *       get { ... }
             *       set { ... }
             *   }
             * 
             * Example:
             *   public class StudentRegister
             *   {
             *       private string[] names = new string[5];
             *       
             *       public string this[int index]
             *       {
             *           get { return names[index]; }
             *           set { names[index] = value; }
             *       }
             *   }
             *   
             * Usage:
             *    
             *    var register = new StudentRegister();
             *    
             *    register[0] = "Alice";  // set using indexer
             *    register[1] = "Bob";
             *    console.WriteLine(register[0]);  // get using indexer => "Alice"
             * 
             */

            #region Benefits of Indexers
            /* 
             * need indexers becouse:
             * Cleaner syntax than GetItem()
             * Validate keys & handle missing values
             * Collections, caches, dictionaries
             * 
             * 1. Intuitive Access: Allows users to access elements using familiar array syntax, 
             * making code more readable and natural.
             *
             * 2. Encapsulation: Hides the internal data structure while still providing flexible access to its elements.
             *
             * 3. Custom Behavior: You can add validation, logging, or other logic in the get/set accessors, 
             * giving you control over how data is accessed and modified.
             *
             * 4. Multiple Indexers: A class can have multiple indexers with different parameter types, 
             * allowing for versatile access patterns (e.g., by name or by ID).
             *
             */
            #endregion

            #region Indexer vs Property vs Method
            /*
             * Property = what it has | Method = what it does | Indexer = what it contains
             * -------------------------------------------------------------------------------------------------------------------
             * | Aspect        |      Property                |    Method                     |   Indexer                       |
             * |---------------|------------------------------|-------------------------------|---------------------------------|
             * | Purpose       | Expose object state (data)   | Perform an action / behavior  | Provide indexed access to data  |
             * | Syntax Style  | Looks like a field           | Looks like a function         | Looks like array access         |
             * | Parameters    | No parameters                | Can take parameters           | Takes parameters (index)        |
             * | Examples      | Name, Age, Balance           | Deposit(), Withdraw()         | register[0], cache["key"]       |
             * | Access Style  |   obj.Name		              |   obj.Do()                    |    obj[key]                     |
             * | parameters    |   NO                         |   (any)                       |     (key/index)                 |
             * | Best for	   |   Single value (state)		  |  Actions / behavior           |    Collection-like access       |
             * --------------------------------------------------------------------------------------------------------------------
             * 
             */
            #endregion

            #region Advanced: Multi-Parameter Indexer
            /*
            * A class can have multiple indexers with different parameter types, 
            * allowing for versatile access patterns (e.g., by name or by ID).
            * 
            * Example:
            * 
            * public class Matrix
            * {
            *     private int[,] _data = new int[3,3];
            * 
            *     public int this[int row, int col]       // 2 parameters!
            *     {
            *         get { return _data[row, col]; }
            *         set { _data[row, col] = value; }
            *     }
            * }
            * 
            * Usage:
            * 
            * var m = new Matrix();
            * m[1, 2] = 99;                          // set row 1, col 2
            * Console.WriteLine(m[1, 2]);              // 99
            * 
            */
            #endregion

            #endregion

            #region static Keyword
            /*
             * means that a member belongs to the type itself, not to a specific object instance.
             * 
             *    No object creation needed
             *    Shared across all usages
             *    Single copy in memory
             * static answers: "Does this belong to the class as a whole, or to each object?" 
             * 
             * belongs to the class itself, not to any specific instance. 
             * Shared across all instances — only one copy exists in memory.
             * 
             * Static members are accessed through the class name, not through an object.
             * 
             * Use static for:
             *     Utility functions (e.g., Math.Sqrt())
             *     Shared data (e.g., a counter of total instances)
             *     Constants (e.g., Pi)
             *     Factory methods (e.g., DateTime.Now)
             *     
             * Static → call on class directly
             * Instance → needs an object
             */

            #region Instance vs static
            /*
             * ----------------------------------------------------------------------------------------
             * | Aspect        |      Instance Member            |    Static Member                   |
             * |-------------------------------------------------|-------------------------------------
             * | Belongs To    | Each object instance            | The class itself (shared)          |
             * | Memory        | Each instance has its own copy  | Only one copy for the entire class |
             * | Accessed Via  | Object reference (obj.Member)   | Class name (Class.Member)          |
             * | Existion      |   Lives as long as the object   | Lives as long as the program runs  |
             * | Use For       | Object-specific data/behavior   | Shared data, utility functions     |
             * ----------------------------------------------------------------------------------------
             * 
             * 
             */
            #endregion

            #region Static Fields
            /*
             * Shared state can cause bugs if misused — common for counters, caches, constants.
             * 
            * Shared data across all instances — only one copy exists. 
            * 
            * Example: a counter of total instances created.
            * 
            * class MyClass {
            *  
            *  static int instanceCount;  // shared across all objects
            * 
            * //Each time a new object is created, increment the counter in the constructor:
            * 
            *  public MyClass()
            *  {
            *      instanceCount++;
            *  }
            * }
            * 
            * // Access it through the class name:
            * Console.WriteLine(MyClass.instanceCount);  // total instances created
            */
            #endregion

            #region Static Methods
            /*
             * If a method doesn't need instance data → make it static.
             * 
             * Belongs to the class, not an instance — can be called without creating an object.
             * 
             * Cannot access instance members directly — only other static members. 
             * 
             * Example: a utility method to calculate the area of a circle.
             * 
             * class MathHelper
             * {
             *     public static double CalculateCircleArea(double radius)
             *     {
             *         return Math.PI * radius * radius;
             *     }
             * }
             * 
             * // Call it without creating an object:
             * double area = MathHelper.CalculateCircleArea(5);
             */
            #endregion

            #region Static Constructor
            /*
             * Used to initialize static fields or perform actions that need to happen once for the class.
             * 
             *  ==>  Runs once only
             *  ==>  No parameters
             *  ==>  Called automatically
             * 
             * A special constructor that runs once when the class is first accessed. 
             * Used to initialize static fields or perform one-time setup.
             * 
             * Syntax:
             * static ClassName()
             * {
             *     // initialization code here
             * }
             * 
             * Example: initializing a static counter.
             * 
             * class MyClass
             * {
             *     public static int instanceCount;
             *     
             *     static MyClass()  // runs once when the class is first used
             *     {
             *         instanceCount = 0;  // initialize static field
             *     }
             * }
             */
            #endregion

            #region Static Classes
            /*
             * A class that can only contain static members — useful for utility/helper classes.
             * 
             *  ==>  Cannot be instantiated
             *  ==>  Cannot be inherited
             *  ==>  Utility / helper pattern
             * 
             * Cannot be instantiated — all members must be static. 
             * Ideal for grouping related utility functions together.
             * 
             * Syntax:
             * static class ClassName
             * {
             *     // only static members allowed
             * }
             * 
             * Example: a utility class for string operations.
             * 
             * static class StringUtils
             * {
             *     public static bool IsNullOrEmpty(string str)
             *     {
             *         return string.IsNullOrEmpty(str);
             *     }
             * }
             */
            #endregion

            #region When to Use Static vs Instance
            /*
             * Use static when:
             *     No instance data needed
             *     Utility functions
             *     Shared state (with caution)
             *     Constants
             * 
             * Use instance when:
             *     Object-specific data/behavior
             *     Needs to maintain state
             *     Polymorphism / inheritance
             * 
             * Static is for class-level functionality, instance is for object-level functionality.
             * 
             * -----------------------------------------------------------------------------------------|
             * | I need to...	                |         Use                  |        Example         |
             * |--------------------------------|------------------------------|------------------------|
             * | Data unique to each object	    |  Instance field	           |   emp.Name             |
             * | Data shared by all objects	    |  Static field	               |   Employee.Count       |
             * | Action that uses object data	|  Instance method	           |   emp.GetSalary()      |
             * | Utility / helper with no object|  Static method	           |   Math.Max(a, b)       |
             * | One-time setup for the class	|  Static constructor	       |   static Config()      |
             * | Class with no instances needed	|  Static class	               |   static class Logger  |
             * -----------------------------------------------------------------------------------------
             * 
             */
            #endregion

            #endregion

            #endregion


            #region Assignment

            #region Part 01 : Theoretical Questions

            #region Question 1

            /*
             * Q1 : Consider the following class:
             * 
             * public class BankAccount 
             * {
             *     public string Owenr;
             *     public double Balance;
             *     
             *     public void  Withdraw(double amount)
             *     {
             *         balance -= amount;
             *     }
             * }
             * 
             * a) Identify at least two problems with this design from an encapsulation perspective.
             * 
             * b) Describe how you would fix this class to follow proper encapsulation principles. 
             * You do not need to write the full code.
             * 
             * c) Explain why exposing fields directly (as public) is considered a bad practice in OOP.

             */

            //Console.WriteLine("Part 01\nQuestion 01");
            //Console.WriteLine("\n" + new string('-', 50) + "\n");

            // Answers:
            // a) Problems:
            //    1. Public fields allow anyone to change the balance directly,
            //    which can lead to invalid states (e.g., negative balance).
            //    2. No validation in Withdraw method (e.g., no check for sufficient funds).

            // b) Fix:
            //    1. Make fields private and use properties to control access.
            //    2. Add validation in Withdraw method to prevent overdrawing.
            // Code:
            //      private string _owner;
            //      private double _balance;
            //      public string Owner { get { return _owner; } }
            //      public double Balance          
            //      {
            //          get { return _balance; }
            //          private set { _balance = value; }           
            //      }    
            //      public void Withdraw(double amount)
            //      {
            //          if (amount <= 0)
            //              throw new ArgumentException("Invalid amount");
            //          if (amount > _balance)
            //              throw new InvalidOperationException("Insufficient funds");
            //          _balance -= amount;
            //      }

            // c) Exposing fields directly breaks encapsulation, allows invalid states, and makes future changes difficult.


            #endregion

            #region Question 2
            /*
             * Q02 : What is the difference between a field and a property in C#? 
             * Can a property contain logic? 
             * Give an example of a read-only property that returns a calculated value.
             * 
             */

            //Console.WriteLine("Part 01\nQuestion 02");
            //Console.WriteLine("\n" + new string('-', 50) + "\n");

            // Answers:
            // A field is a variable that holds data directly,
            // while a property is a member that provides controlled access to that data through get and set accessors.
            // Yes, a property can contain logic in its get and set accessors for validation, calculation, etc.
            // Example of a read-only property that returns a calculated value:

            //    private double Width { get; set; }
            //    private double Height { get; set; }

            //    public double Area            
            //    {
            //        get { return Width * Height; } 
            //    }

            #endregion

            #region Question 3
            /*
             *  Q3 : Look at the following code and answer the questions below:
             *  
             *  public class StudentRegister 
             *  {
             *      private string[] names = new string[5];
             *      public string this[int index]
             *      {
             *          get{ return names[index]; }
             *          set{ names[index] = value; }
             *      }
             *  }
             *  
             *  a) What is `this[int index]` called? Explain its purpose.
             *  
             *  b) What happens if someone writes `register[10] = "Ali";` ? 
             *  How would you make the indexer safer?
             *  
             *  c) Can a class have more than one indexer? 
             *  If yes, give an example of when that would be useful.
             *  
             */

            //Console.WriteLine("Part 01\nQuestion 03");
            //Console.WriteLine("\n" + new string('-', 50) + "\n");

            // Answers:
            // a) `this[int index]` is called an indexer.
            // It allows instances of the class to be indexed like arrays,
            // providing a way to access elements in the internal collection using array-like syntax.

            // b) If someone writes `register[10] = "Ali";`,
            // it will throw an IndexOutOfRangeException because the index 10 is out of bounds for the array of size 5.
            // To make the indexer safer, you could add a check to ensure the index is within valid bounds
            // before accessing the array.
            
            // c) Yes, a class can have more than one indexer with different parameter types.
            // For example, you could have one indexer that takes an int for accessing by index
            // and another that takes a string for accessing by name:
            
            //    public string this[string name]
            //    {
            //        get { return names.FirstOrDefault(n => n == name); }
            //        set
            //        {
            //            int index = Array.IndexOf(names, name);
            //            if (index >= 0)
            //                names[index] = value;
            //        }
            //    }



            #endregion

            #region Question 4
            /*
             * Q4 : Consider the following code and answer the questions below:
             * 
             * public class Order
             * {
             *     public static int TotalOrders = 0;
             *     public string Item;
             *     
             *     public Order(string item)
             *     {
             *        Item = item;
             *        TotalOrders++;
             *     }
             * }
             * 
             * a) What does the `static` keyword mean on `TotalOrders`? 
             * How is it different from the `Item` field?
             * 
             * b) Can a static method inside `Order` access the `Item` field directly? Why or why not?

             * 
             */

            //Console.WriteLine("Part 01\nQuestion 04");
            //Console.WriteLine("\n" + new string('-', 50) + "\n");

            #endregion

            #endregion

            #region Part 02 : Practical (Extending the Movie Ticket Booking System)
            /*
             * 
             * In Assignment 01, you built a basic Movie Ticket Booking System with a Ticket class, 
             * a SeatLocation struct, and a TicketType enum. Now you will improve and extend that system 
             * using encapsulation, properties, indexers, and static members.
             * 
             * What you need to build : 
             */


            #region 1. Refactor the Ticket class
            /*
             * 
             * 1. Refactor the Ticket class to use proper encapsulation: 
             * 
             *    a. Create public properties for each field with the following validation rules: 
             *    
             *       • MovieName : cannot be null or empty. If an invalid value is set, keep the previous value.
             *       
             *       • Type : use the TicketType enum from Assignment 01 (no special validation needed).
             *       
             *       • Seat : use the SeatLocation struct from Assignment 01 (no special validation needed). 
             *       
             *       • Price : must be greater than 0. If an invalid value is set, keep the previous value.
             *       
             *    b. Add property PriceAfterTax that returns the price with 14% tax included (calculated, not stored).
             */

            #endregion

            #region 2. Add a static field and a static method to the Ticket class
            /*
             *2. Add a static field and a static method to the Ticket class: 
             *  a. Add a ’ticketCounter’ field that starts at 0. 
             *  
             *  b. Add a ‘TicketId’ property. Each ticket gets a unique ID automatically when created 
             *  (increment ticketCounter in the constructor and assign it to the ID). 
             *  
             *  c. Add a ‘GetTotalTicketsSold()’ method that returns the current value of ticketCounter.
             *
             */

            #endregion

            #region 3. Create a Cinema class

            /*
             * 3. Create a Cinema class that holds up to 20 tickets using a private array. 
             * Add the following: 
             *    a. Allow User To get and set tickets by index if the index is out of range, 
             *    the getter returns null and the setter does nothing. 
             *    
             *    b. Allow User To Get Movie By movieName that returns the first ticket found matching the given movie name, 
             *    or null if not found. 
             *    
             *    c. A method AddTicket(Ticket t) that adds a ticket to the first available (null) slot. 
             *    Returns true if added, false if the cinema is full.
             * 
             */

            #endregion

            #region 4. Create a static utility class
            /*
             * 
             * 4. Create a static utility class called BookingHelper with the following static methods: 
             *     a. double CalcGroupDiscount(int numberOfTickets, double pricePerTicket) 
             *     That returns total price with a 10% discount if the group has 5 or more tickets, 
             *     otherwise returns the full total. 
             *     
             *     b. string GenerateBookingReference() That returns a unique string each time it is called 
             *     (e.g., "BK-1", "BK-2", "BK-3", ...). Use a private static counter internally.
             * 
             */

            #endregion

            #region 5. In your Main method
            /*
             * 5. In your Main method, build a Console Application that does the following: 
             * 
             *     a. Ask the user to enter data for 3 tickets (movie name, ticket type, seat row, seat number, price). 
             *     Create each Ticket and add it to the Cinema . 
             *     
             *     b. Print all 3 tickets (access by index 0, 1, 2) showing: 
             *     TicketId, MovieName, Type, Seat, Price, and PriceAfterTax. 
             *     
             *     c. Ask the user for a movie name and search for it. 
             *     Print the result or a "not found" message. 
             *     
             *     d. Print the total tickets sold using the method. 
             *     
             *     e. Generate and print 2 booking references . 
             *     
             *     f. Calculate and print the group discount for a group of 5 tickets at 80 EGP each of them.
             * 
             */

            //Console.WriteLine("Part 02");
            //Console.WriteLine("\n" + new string('-', 50) + "\n");

            #endregion

            #endregion

            #endregion


            Console.WriteLine("\n" + new string('-', 70) + "\n");

        }
    }
}
