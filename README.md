# CSharp-NullCheck
Resoure: [Nick Chapsas: How null checks have changed in C#](https://www.youtube.com/watch?v=lRUfRlp5BXc)

```c#
public class Person
{
    public string Name { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        RunTestForCS6(new Person() { Name = "Robert"});
        RunTestForCS6(null);

        RunTestForCS7(new Person() { Name = "Robert"});
        RunTestForCS7(null);

        RunTestForCS8(new Person() { Name = "Robert"});
        RunTestForCS8(null);

        RunTestForCS9(new Person() { Name = "Robert"});
        RunTestForCS9(null);
    }
}
```

---------------------------------------

## C# 6
```c#
private static void RunTestForCS6(Person person)
{
    if (person == null) // Be careful with overloaded operators
    {
        Console.WriteLine("[person == null] Person: Null");
    }

    if (person != null)
    {
        Console.WriteLine($"[person != null] Person: {person}");
    }

    Console.WriteLine($"Person Name: {person?.Name}");

    // ?? and ??= operators: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
    Person person2 = person ?? new Person() { Name = "Martin" };

    Console.WriteLine($"Person_2: {person2}");
    Console.WriteLine($"Person_2 Name: {person2?.Name}");
}
```

## Console Output with Person
```console
[person != null] Person: DemoNullCheck.Person
Person Name: Robert
Person_2: DemoNullCheck.Person
Person_2 Name: Robert

```
## Console Output with NULL Person
```console
[person == null] Person: Null
Person Name:
Person_2: DemoNullCheck.Person
Person_2 Name: Martin

```

---------------------------------------

## C# 7
```c#
private static void RunTestForCS7(Person person)
{
    if (person == null)
    {
        Console.WriteLine("[person == null] Person: Null");
    }

    if (person != null)
    {
        Console.WriteLine($"[person != null] Person: {person}");
    }

    // Pattern matching with is: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/is
    if (person is null)
    {
        Console.WriteLine($"[person is null] Person: {person}");
    }

    if (!(person is null))
    {
        Console.WriteLine($"[!(person is null)] Person: {person}");
    }

    if (person is object) // Not readable
    {
        Console.WriteLine($"[person is object] Person: {person}");
    }

    // Discards (_ = object): https://docs.microsoft.com/en-us/dotnet/csharp/discards
    // These are the same
    // _ = person ?? throw new ArgumentNullException(nameof(person));
    // if (person is null)
    // {
    //     throw new ArgumentNullException(nameof(person));
    // }
}
```

## Console Output with Person
```console
[person != null] Person: DemoNullCheck.Person
[!(person is null)] Person: DemoNullCheck.Person
[person is object] Person: DemoNullCheck.Person
```

## Console Output with NULL Person
```console
[person == null] Person: Null
[person is null] Person:
```

---------------------------------------

## C# 8
```c#
private static void RunTestForCS8(Person person)
{
    if (person is {}) // same as: (person is object) | // Not readable
    {
        Console.WriteLine("[person is {}] Person: " + person);
    }

    // ?? and ??= operators: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
    person ??= new Person() {Name = "Martin"};
    Console.WriteLine($"$[person ??=] Person Name: {person?.Name}");
}
```

## Console Output with Person
```console
[person is {}] Person: DemoNullCheck.Person
$[person ??=] Person Name: Robert
```

## Console Output with NULL Person
```console
$[person ??=] Person Name: Martin
```

---------------------------------------

## C# 9
```c#
private static void RunTestForCS9(Person person)
{
    if (person is null)
    {
        Console.WriteLine($"[person is null] Person: {person}");
    }

    if (person is not null)
    {
        Console.WriteLine($"[person is not null] Person: {person}");
    }
}
```

## Console Output with Person
```console
[person is not null] Person: DemoNullCheck.Person
```

## Console Output with NULL Person
```console
[person is null] Person:
```
