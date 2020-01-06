LINQ is the set of functions in .NET that lets you work with collections of data (whether in-memory or delayed-retrieval) more efficiently than ever before.  Most of you have used LINQ in passing (it can no longer be avoided), but I wanted to present to get you started on the road to LINQ mastery. Working with collections becomes easier and easier the more you leverage LINQ to its full potential. Some developers shy away from complexity in LINQ, but in fact chaining together more complex LINQ expressions is a way of making your code easier to understand, not harder. While LINQ won't eliminate all your loops or conditionals, it will remove the need for many of them, and also make your code easier to understand.

Don’t think of LINQ as “like SQL for .NET”. Instead, think of LINQ in terms of collections and functional programming.  The various LINQ functions are all about working with any kind of collection.  '”Functional programming” is the idea that functions can take functions as parameters and return functions as a result.  The SQL-like syntax of LINQ is just a nice feature and doesn’t show the full power of the feature set.

Most of the LINQ functions are on the types IEnumerable<T> and IQueryable<T>.  LINQ also provides robust functions for reinterpreting or transforming any collection into these types so that you can most easily work with them.  Here is a table of the most commonly used collection types:

    IEnumerable<T>: Access by “get next” only; cannot add or remove items; can be remotely accessed or in-memory
    IQueryable<T>: Access by “get next” or query; cannot add or remove items; can be remotely accessed or in-memory
    Array<T> / T[]: In memory; cannot add or remove items
    HashSet<T>: In memory, no duplicates allowed; can add and remove items
    List<T>: In memory, duplicates allowed; can add and remove items

The ability to query an IQueryable is what gives LINQ much of its robustness, but many of the extension methods are available on IEnumerables as well.  Here’s a list of extension methods that LINQ provides; you can see the full documentation for LINQ methods on MSDN as well.  (http://tinyurl.com/linqfunctions)

    Testing for conditions or count
        Any
        All
        Contains
        Count
    Getting a single item
        Single / SingleOrDefault
        First / FirstOrDefault
        Last / LastOrDefault
        ElementAt 
    Getting some of the collection
        Where 
        Skip
        Take
        Distinct
    Transforming the collection
        Select
        SelectAll
        GroupBy
        OrderBy / OrderByDescending
        ThenBy / ThenByDescending
    Working with multiple collections
        Concat
        Zip
        Join
    Aggregates
        Aggregate
        Max
        Min
        Average
        Count
    Conversions
        Cast
        AsEnumerable
        ToList
        ToArray
        ToDictionary
        ToLookup
    Set operations
        Intersect
        Union
        Except

You can’t take full advantage of LINQ without a good understanding of statements, expressions, and lambdas in C#.

A statement is simply “a line of code” that can be executed at runtime.  It is complete in and of itself, and it usually accomplishes something.

    var y = x + 2;

An expression is anything that can be evaluated to a value.  Usually, we think of expressions as part of a statement.  By itself, it usually accomplishes nothing.

    x + 2

A block is a grouping of statements, usually in braces.

    { var y = x + 2; }

A function is a block with access modifiers, a function name, parameters, and a return value.  A pure function is one where nothing but its parameters and internal code determine its return value; an impure function is one where the function uses information from another context or causes side-effects such as writing to the console.  In C#, all functions defined this way are part of a class and are therefore called methods.

    private static int AddTwo(int addend) { return addend + 2; }

A function reference can be created from an already-defined function.  In fact, the name of the function is already a function reference.

    public static void Main(){
        Func<int, int> f2 = AddTwo;
        Console.WriteLine(f2(3));  // writes 5

A lambda expression (or simply “a lambda”) is a function definition that happens to be an expression.  C# provides the “arrow” operator for this.  I can assign a function reference from a lambda expression as the following; the braces are dropped, and the return value is taken from the value of the only expression in the definition.

        Func<int, int> f2a = (int x) => x + 2;
        Console.WriteLine(f2a(3));  // writes 5
    }

A function can also be defined with access modifiers, a function name, parameters, and an expression body.

    private int AddTwoB(int addend) => addend + 2;

With function references, we can then pass functions as parameters and return them as values.

    public static Func<int, int> MakeDoubleApplier (Func<int, int> f1) => ( int x => f1(f1(x)); );

    public static void Main(){
        Func<int, int> f3 = MakeDoubleApplier(AddTwo);
        Console.WriteLine(f3(3)); // writes 7
        Console.WriteLine(MakeDoubleApplier(AddTwo)(3)); // writes 7
    }

An expression tree enables any code, especially the LINQ collection methods, to “see under the hood” of a lambda expression.  Most often, such an expression has boolean logic, but can go beyond that.  Think of it as an “uncompiled function with annotations”.  It holds the tree of logic that can then be modified or used by other code.  Defined functions are a black box; other code (or LINQ methods) have no way to know how they work other than their parameters and return value.  Expression trees provide a defined structure to expose their innards in a way that enables further logic; they are a totally clear box.  Expression trees are enabled by the Expression<T> class in .NET, and are usually defined by a lambda expression.

    Expression<Func<int, bool>> IsTwoTree = (int value) => value == 2;

The compiler will give you an error if you attempt to construct an expression tree with something that is already a “black box”.

    Func<int, bool> f4 = (int value) => value == 2;
    Expression<Func<int, bool>> IsTwoTreeF = f4;   // ERROR: compiler cannot “see into” f4

Expression trees can be “compiled” to result in black-box functions that can be immediately invoked or used like any function reference.

    Console.WriteLine(IsTwoTree.Compile()(3)); // writes 5

Expression trees make it possible to simplify your code.  Imagine you have many repeated statements, but they differ in the references or actions they take based on parameters.  You can use the power of expression trees to make functions anyway, passing in expression trees to a function that it can apply in the same way.  For example, have you ever seen LINQ querying and ordering code like this?

    if (options.PageCount.HasValue)
        query = query.Where(x => x.PageCount == options.PageCount);
    if (options.FirstName != null)
        query = query.Where(x => x.FirstName == options.FirstName);
    if (options.PersonId != null)
        query = query.Where(x => x.Id == options.PersonId);
    if …

    if (options.SortBy == “PageCount”) {
        if (options.SortByDirection) query = query.OrderByDescending(x => x.PageCount);
        else query = query.OrderBy(x => x.PageCount);
    }
    if (options.SortBy == “FirstName”) {
        if (options.SortByDescending) query = query.OrderByDescending(x => x.FirstName);
        else query = query.OrderBy(x => x.FirstName);
    }
    if (options.SortBy == “PersonId”) {
        if (options.SortByDirection) query = query.OrderByDescending(x => x.PersonId);
        else query = query.OrderBy(x => x.PersonId);
    }

Since each Where clause uses a different property to query, and since OrderBy and OrderByDescending are different methods, there is no way to parameterize these to reduce repetition unless you use expression trees. Then, the following becomes possible.  (I’ll put the full code of these functions--that you can use them in your code—below.)

    query = query
        .WhereEqualIfSpecified(x => x.PageCount, options.PageCount)
        .WhereEqualIfSpecified(x => x.FirstName, options.FirstName)
        .WhereEqualIfSpecified(x => x.Id, options.PersonId)
        .WhereEqualIfSpecified … ;
    if (options.SortBy == “PageCount”) query = query.OrderByDirection(x => x.PageCount, options.SortByDirection);   
    if (options.SortBy == “FirstName”) query = query.OrderByDirection(x => x.FirstName, options.SortByDirection);
    if (options.SortBy == “PersonId”) query = query.OrderByDirection(x => x.Id, options.SortByDirection);

I like that code a lot better!  What can you think to do with the power of expression trees? 

Here’s that LINQ utility code (for the In, OrderByDirection, and WhereEqualIfSpecified functions) that you can use if you wish.
https://gist.github.com/szalapski/96131c43ceefbf66149e5f6f855a4449

Once you have some understanding of Using LINQ with Collections (part 1) and Lambdas and Expression Trees (part 2), you can really start cleaning up your code to be more expressive and easier to read for others.

First, a few guidelines:

    Write your code first for people to read, and only incidentally for a machine to execute. Readability almost always trumps efficiency, length, and even your established coding standards.   https://www.goodreads.com/quotes/9168-programs-must-be-written-for-people-to-read-and-only
    
    That being said, shorter code and standards-compliant code is often easier to read.
    Ease of readability should be judged by someone who understands the syntax you are using, not for those who don’t.  Today’s so-called “advanced” syntax might be tomorrow’s routine.
    Refactoring tools such as Resharper (for which we have licenses, for every developer at General Mills) encourage you to make your code more consistent and readable, and enable you to do so with minimal risk of making errors.

Increasingly, I see loops as a code smell.  Loops as a widely-used concept came out of procedural and structural programming—in other words, out of the paradigm that the purpose of a computer program is to tell the computer what to do, step by step.  C# and other languages are far more capable than that, and we have rich abstractions on top of the machine code, assembly code, and IL code that is under the covers.  In recent decades, function-based and set-based thinking have grown in usefulness and notoriety.  In a nutshell, it is generally better to tell the computer the end result and leverage the tools in our language that allow the compiler to take our desired outcome and build the right IL code to accomplish it using operations and data.  Loops aren’t necessarily bad, but often we can be more declarative, more functional in expressing what we want.

Take a code fragment like this:

int letterAPageCount = 0;
foreach (Foo item in stuff)
{
    if (item.ViewName.StartsWith(“A”) & item.PagesCount != null)
    {
        letterAPageCount += item.PagesCount.Value
    }
    Console.WriteLine(letterAPageCount);
}

You might explain the above loop in English as “Add up all the PageCounts for items that start with the letter A”.  But notice what that English explanation avoids—it does not talk about looping or iterations!  It would be very confusing instead to say, “For each item that starts with the letter A, add the PageCount to a temporary value counter till you are done with all such items.”  People just don’t explain things this way because it is more intuitive and understandable to talk about what we are doing with the collection as a whole rather than dealing with each item successively.  LINQ enables us to effectively express what we want with the entire collection:

int letterAPageCount = stuff
    .Where(f => f.ViewName.StartsWith(”A”))
    .Sum(f => f.PagesCount ?? 0);
Console.WriteLine(letterAPageCount);

If you are not familiar with LINQ syntax, the first example may seem easier—but I would argue that the LINQ version is easier for anyone familiar with LINQ syntax.  It also enables the reader to think linearly: “filter it then sum it”, rather than figuring out what happens in iterations of a loop.

Here’s another example.  What do you think of a loop like this that would give us the count of each page?

Dictionary<char, int> firstLetterDictionary = new Dictionary<char, int>();
foreach (Foo item in stuff){
    if (item.PagesCount == null) continue;
    if (firstLetterDictionary.ContainsKey(item.ViewName[0])
    {
        firstLetterDictionary[item.ViewName[0]] =+ item.PagesCount.Value;
    }
    else
    {
        firstLetterDictionary.Add(item.ViewName[0], item.PagesCount.Value);
    }
}
// then print out the full contents of firstLetterDictionary

I think that this is rather tough to understand—there is complexity in the loop, the nested conditions, and the details of each assignment and Add operation.  To know that this simply gives us the page count of each item by its first letter, we have to parse a certain amount of complexity.

LINQ provides the .GroupBy function to handle cases like this—you want to collapse several rows into one per group, and you want to define those groups in any way.  The .GroupBy function seems like an advanced difficult function, but I want to demystify it for you.  In essence, GroupBy takes two parameters: the first defines the groups (or keys), and the second determines what you do with each group and collection of items in that group. If you keep these two things distinct in your mind, using .GroupBy is much easier.

var result = stuff
    .GroupBy(
        f => new {FirstLetter = f.ViewName[0], HasPageCount = f.PagesCount != null},
        (key, g) => new KeyValuePair<char, int>(key.FirstLetter, g.Sum(x => x.PagesCount ?? 0))
    );
// then print out the full contents of result

I think this code is clearer to someone who knows .GroupBy–we are emphasizing defining a group, then taking the sum of a property for each group, rather than emphasizing loops and conditionals that don’t fit the more natural concept of adding up values for certain groupings.  This code is more declarative and expressive of the intent.

Many of the other functions in LINQ are useful to eliminate your loops.  Share any further techniques you may have in the comments. 
