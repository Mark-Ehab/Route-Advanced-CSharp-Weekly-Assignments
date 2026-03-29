using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Reflection.Metadata;
using System.Timers;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment03;

internal class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                 Advanced C# - ASSIGNMENT WITH ANSWERS              ║");
        Console.WriteLine("║                            6 Exercises                             ║");
        Console.WriteLine("║                           Assiginment (3)                          ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");
        Console.ResetColor();

        #region Exercise01: Student Grade Manager
        //===========================================================================================
        // Ex1: Create a program that manages student grades using One Of Collections:
        //
        //      1.Create a Collection with these grades: 85, 92, 78, 95, 88, 70, 100, 65
        //      2.Print the collection, Count, first and last grade
        //      3.Sort the grades ascending, then print
        //      4.Get the first grade above 90
        //      5.Get all grades below 75 (failing grades)
        //      6.Remove all failing grades (below 75)
        //      7.Check if any grade equals 100
        //      8.Create a List<string> where each grade becomes "Grade: X"
        //===========================================================================================

        /* Compose Exercise Title */
        PrintSectionTitle("Exercise01: Student Grade Manager");

        /* 1.Create a Collection with these grades: 85, 92, 78, 95, 88, 70, 100, 65 */
        List<int> grades = [85, 92, 78, 95, 88, 70, 100, 65];

        /* 2.Print the collection, Count, first and last grade */
        Console.Write("Collection: ");
        grades.ForEach(grade => Console.Write($"{grade} "));
        Console.WriteLine();
        Console.WriteLine(new string('-',50));
        Console.WriteLine($"Count = {grades.Count}");
        Console.WriteLine(new string('-',50));
        Console.WriteLine($"First Grade = {grades.First()}");
        Console.WriteLine(new string('-',50));
        Console.WriteLine($"Last Grade = {grades.Last()}");
        Console.WriteLine(new string('-',50));

        /* 3.Sort the grades ascending, then print */
        grades.Sort();
        Console.Write("Collection Sorted Ascending: ");
        grades.ForEach(grade => Console.Write($"{grade} "));
        Console.WriteLine();
        Console.WriteLine(new string('-', 50));


        /* 4.Get the first grade above 90 */
        Console.Write("The first grade above 90 = ");
        Console.WriteLine(grades.Find(grade => grade > 90));
        Console.WriteLine(new string('-', 50));

        /* 5.Get all grades below 75 (failing grades) */
        Console.Write("Grades below 75 (failing grades): ");
        grades.FindAll(grade => grade < 75).ForEach(grade => Console.Write($"{grade} "));
        Console.WriteLine();
        Console.WriteLine(new string('-', 50));

        /* 6.Remove all failing grades (below 75) */
        Console.Write("Grades after removing all failing grades (below 75): ");
        grades.RemoveAll(grade => grade < 75);
        grades.ForEach(grade => Console.Write($"{grade} "));
        Console.WriteLine();
        Console.WriteLine(new string('-', 50));

        /* 7.Check if any grade equals 100 */
        Console.WriteLine($"Check if any grade equals 100 : {(grades.Exists(grade => grade == 100) ? "Yes" : "No")}");
        Console.WriteLine(new string('-', 50));

        /* 8.Create a List<string> where each grade becomes "Grade: X" */
        List<string> gradesFormatted = grades.ConvertAll(grade => $"Grade: {grade}");
        Console.WriteLine("Grades after conversion will be :");
        gradesFormatted.ForEach(gradesFormatted => Console.WriteLine(gradesFormatted));

        /* Draw section separator line */
        DrawSectionSeparatorLine();

        #endregion

        #region Exercise02: Leaderboard
        //===========================================================================================
        // Ex2: Create a leaderboard that automatically sorts players by score.
        //
        //      1.Add: 500 = "Ahmed", 200 = "Sara", 800 = "Ali", 350 = "Mona"
        //      2.Print all entries (they should be sorted by score automatically)
        //      3.Access the first key and first value
        //      4.Check if score 500 exists
        //      5.Safely get the player with score 999
        //      6.Remove the player with score 200 and print the updated list
        //===========================================================================================

        /* Compose Exercise Title */
        PrintSectionTitle("Exercise02: Leaderboard");

        /* 1.Add: 500 = "Ahmed", 200 = "Sara", 800 = "Ali", 350 = "Mona" */
        SortedList<int, string> leaderboard = new ()
        {
            [500] = "Ahmed",
            [200] = "Sara",
            [800] = "Ali",
            [350] = "Mona"
        };

        /*  2.Print all entries (they should be sorted by score automatically) */
        Console.WriteLine("Leaderboard: ");
        foreach(var scoreNameKvp in leaderboard)
        {
            Console.WriteLine($"Name: {scoreNameKvp.Value}, Score: {scoreNameKvp.Key}");
        }
        Console.WriteLine(new string('-', 50));

        /* 3.Access the first key and first value */
        Console.WriteLine($"First key = {leaderboard.First().Key}");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"First value = {leaderboard.First().Value}");
        Console.WriteLine(new string(c: '-', 50));

        /* 4.Check if score 500 exists */
        Console.WriteLine($"Check if score 500 exists : {(leaderboard.ContainsKey(500) ? "Existing" : "Not Existing")}");
        Console.WriteLine(new string('-', 50));

        /* 5.Safely get the player with score 999 */
        leaderboard.TryGetValue(999, out var player);
        Console.WriteLine($"Player with score 999 : {(player ?? "Not Existing")}");
        Console.WriteLine(new string('-', 50));

        /* 6.Remove the player with score 200 and print the updated list */
        leaderboard.Remove(200);
        Console.WriteLine("Leaderboard (Updated after player whose score is 200 has been removed): ");
        foreach (var scoreNameKvp in leaderboard)
        {
            Console.WriteLine($"Name: {scoreNameKvp.Value}, Score: {scoreNameKvp.Key}");
        }

        /* Draw section separator line */
        DrawSectionSeparatorLine();

        #endregion

        #region Exercise03: Phone Book
        //===========================================================================================
        // Ex3: Build a phone book application.
        //
        //      1.Create a Collection with 4 contacts(name → phone number)
        //      2.Add a new contact using [] syntax (add or update)
        //      3.Try adding a duplicate using .Add() — catch the exception and print the error
        //      4.Try adding a duplicate using .TryAdd() — print whether it succeeded
        //      5.Search for a contact that doesn’t exist
        //      6.Get a contact with a fallback of "Not Found"
        //      7.Print all Keys on one line, then all Values on another line
        //===========================================================================================

        /* Compose Exercise Title */
        PrintSectionTitle("Exercise03: Phone Book");

        /* 1.Create a Collection with 4 contacts(name → phone number) */
        Dictionary<string, string> contacts = new()
        {
            ["Mark"] = "01042926205",
            ["Pola"] = "01042930905",
            ["Sara"] = "01040226205",
            ["Ali"] = "01042902205"
        };

        /* 2.Add a new contact using [] syntax (add or update) */
        contacts["Pola"] = "01240303205";
        contacts["Omar"] = "01040303205";
        Console.WriteLine("Contacts after upsert operations:");
        foreach (var namePhoneKvp in contacts)
        {
            Console.WriteLine($"Name: {namePhoneKvp.Key}, Phone: {namePhoneKvp.Value}");
        }
        Console.WriteLine(new string(c: '-', 50));

        /* 3.Try adding a duplicate using .Add() — catch the exception and print the error */
        try
        {
            contacts.Add("Pola","01550203205");
        }
        catch(Exception e) 
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write($"Error: {e.Message}");
            Console.ResetColor();
            Console.WriteLine("\n" + new string(c: '-', 50));
        }

        /* 4.Try adding a duplicate using .TryAdd() — print whether it succeeded */
        bool isAddSucceeded = contacts.TryAdd("Pola", "01550203205");
        Console.WriteLine($"Adding a duplicate to contacts using .TryAdd() method : ({(isAddSucceeded ? "Succeeded" : "Failed")})");
        Console.WriteLine(new string(c: '-', 50));

        /* 5.Search for a contact that doesn’t exist */
        try
        {
            string contact0 = contacts["Samer"];
        }
        catch (Exception e)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write($"Error: {e.Message}");
            Console.ResetColor();
            Console.WriteLine("\n" + new string(c: '-', 50));
        }

        /* 6.Get a contact with a fallback of "Not Found" */
        contacts.TryGetValue("Samer", out var contact1);
        Console.WriteLine($"Contact Number = {contact1 ?? "Not Found !"}");
        Console.WriteLine(new string(c: '-', 50));

        /* 7.Print all Keys on one line, then all Values on another line */
        Console.WriteLine($"Keys: {string.Join(" | ", contacts.Keys)}");
        Console.WriteLine(new string(c: '-', count: 50));
        Console.WriteLine($"Values: {string.Join(" | ", contacts.Values)}");


        /* Draw section separator line */
        DrawSectionSeparatorLine();

        #endregion

        #region Exercise04: Unique Email Validator
        //===========================================================================================
        // Ex4: Use Collection to manage unique email addresses.
        //
        //      1.Create a HashSet<string> with a case-insensitive comparer: new
        //        HashSet<string>(StringComparer.OrdinalIgnoreCase)
        //      2.Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com",
        //        "Sara@Test.Com"
        //      3.Print Count — how many are actually stored? Explain why.
        //      4.Create two sets: Set A = { 1, 2, 3, 4, 5 } and Set B = { 4, 5, 6, 7, 8 }
        //      5.Print the result of: UnionWith, IntersectWith, ExceptWith
        //      6.Use IsSubsetOf to check if {1,2} is a subset of Set A
        //===========================================================================================

        /* Compose Exercise Title */
        PrintSectionTitle("Exercise04: Unique Email Validator");

        /* 
         * 1.Create a HashSet<string> with a case-insensitive comparer: 
         *   new HashSet<string>(StringComparer.OrdinalIgnoreCase)
         */
        HashSet<string> emails = new(StringComparer.OrdinalIgnoreCase);

        /* 2.Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com", "Sara@Test.Com" */
        emails.Add("ahmed@test.com");
        emails.Add("AHMED@test.com");
        emails.Add("sara@test.com");
        emails.Add("Sara@Test.Com");

        /* 3.Print Count — how many are actually stored? Explain why. */
        Console.WriteLine($"Emails count = {emails.Count}");
        Console.WriteLine("""
                                Explaination:
                                Count of emails HashSet will be 2 not 4 although 4 emails were added cause 
                                HashSet is created with case-insensitive comparere so ahmed@test.com and 
                                AHMED@test.com values are considered the same value so one of them will neglected
                                cause HashSet stores only unique values. The same also for Sara@Test.Com and 
                                sara@test.com values, only one of them will be added and the other will be negelected 
                                making the count of actually stored values is 2
                                """);
        Console.WriteLine(new string(c: '-', count: 50));

        /* 4.Create two sets: Set A = { 1, 2, 3, 4, 5 } and Set B = {4,5,6,7,8} */
        var A = new HashSet<int>() { 1, 2, 3, 4, 5 };
        var B = new HashSet<int>() { 4, 5, 6, 7, 8 };

        /* 5.Print the result of: UnionWith, IntersectWith, ExceptWith */
        A.UnionWith(B);
        Console.WriteLine($"UnionWith : {string.Join(" , ",A)}");
        A = new HashSet<int>() { 1, 2, 3, 4, 5 };
        B = new HashSet<int>() { 4, 5, 6, 7, 8 };
        A.IntersectWith(B);
        Console.WriteLine($"IntersectWith : {string.Join(" , ",A)}");
        A = new HashSet<int>() { 1, 2, 3, 4, 5 };
        B = new HashSet<int>() { 4, 5, 6, 7, 8 };
        A.ExceptWith(B);
        Console.WriteLine($"ExceptWith : {string.Join(" , ",A)}");
        Console.WriteLine(new string(c: '-', count: 50));

        /* 6.Use IsSubsetOf to check if {1,2} is a subset of Set A */
        Console.WriteLine($"Check if {{1,2}} is a subset of Set A : {(new HashSet<int> { 1, 2 }.IsSubsetOf(A) ? "Yes" : "No")}");

        /* Draw section separator line */
        DrawSectionSeparatorLine();

        #endregion

        #region Exercise05: Print Queue Simulator
        //===========================================================================================
        // Ex5: Simulate a printer queue
        //      Create a Queue<string> and enqueue 5 documents: "Report.pdf", "Invoice.pdf",
        //      "Letter.docx", "Resume.pdf", "Photo.jpg"
        //
        //      1.Print the queue contents and Count
        //      2.Use Peek to see which document will print next (without removing)
        //      3.Process the queue: Dequeue each document and print "Printing: [name]"
        //      4.Try TryDequeue on the now-empty queue — what happens?
        //===========================================================================================

        /* Compose Exercise Title */
        PrintSectionTitle("Exercise05: Print Queue Simulator");

        /* 
         * Create a Queue<string> and enqueue 5 documents: "Report.pdf", 
         * "Invoice.pdf", "Letter.docx", "Resume.pdf", "Photo.jpg" 
         */
        Queue<string>? documents = new();
        documents.Enqueue("Report.pdf");
        documents.Enqueue("Invoice.pdf");
        documents.Enqueue("Letter.docx");
        documents.Enqueue("Resume.pdf");
        documents.Enqueue("Photo.jpg");

        /* 1.Print the queue contents and Count */
        Console.WriteLine("Documents: ");
        foreach(var document in documents)
        {
            Console.WriteLine($"  {document}");
        }
        Console.WriteLine(new string(c: '-', count: 50));
        Console.WriteLine($"Queue Count = {documents.Count}");
        Console.WriteLine(new string(c: '-', 50));

        /* 2.Use Peek to see which document will print next (without removing) */
        Console.WriteLine($"Document that will printed next (without removing): {documents.Peek()}");
        Console.WriteLine(new string(c: '-', count: 50));

        /* 3.Process the queue: Dequeue each document and print "Printing: [name]" */
        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Printing: {documents.Dequeue()}");
        }
        Console.WriteLine(new string(c: '-', count: 50));

        /* 4.Try TryDequeue on the now-empty queue — what happens? */
        try
        {
            documents.Dequeue();
        }
        catch (Exception e)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write($"Error: {e.Message}");
            Console.ResetColor();
            Console.WriteLine();
        }

        /* Draw section separator line */
        DrawSectionSeparatorLine();

        #endregion

        #region Exercise06: Browser History (Undo)
        //===========================================================================================
        // Ex6: Simulate browser back/forward
        //      Create a Stack<string> for browser history
        //
        //      1.Push 5 URLs: "google.com", "github.com", "stackoverflow.com", "youtube.com",
        //        "claude.ai"
        //      2.Use Peek to see the current page (top of stack)
        //      3.Press "back" 3 times using Pop — print each page you leave
        //      4.Print the current page after going back
        //      5.Try TryPop on an empty stack — what happens?
        //===========================================================================================

        /* Compose Exercise Title */
        PrintSectionTitle("Exercise06: Browser History (Undo)");

        /* Create a Stack<string> for browser history */
        Stack<string> browserHistory = new();


        /* 1.Push 5 URLs: "google.com", "github.com", "stackoverflow.com", "youtube.com","claude.ai" */
        browserHistory.Push("google.com");
        browserHistory.Push("github.com");
        browserHistory.Push("stackoverflow.com");
        browserHistory.Push("youtube.com");
        browserHistory.Push("claude.ai");

        /* 2.Use Peek to see the current page (top of stack) */
        Console.WriteLine($"Current Page: {browserHistory.Peek()}");
        Console.WriteLine(new string(c: '-', 50));

        /* 3.Press "back" 3 times using Pop — print each page you leave */
        Console.WriteLine($"Leave Page (Back): {browserHistory.Pop()}");
        Console.WriteLine($"Leave Page (Back): {browserHistory.Pop()}");
        Console.WriteLine($"Leave Page (Back): {browserHistory.Pop()}");
        Console.WriteLine(new string(c: '-', 50));

        /* 4.Print the current page after going back */
        Console.WriteLine($"Current Page (after going back): {browserHistory.Peek()}");
        Console.WriteLine(new string(c: '-', 50));

        /* 5.Try TryPop on an empty stack — what happens? */
        browserHistory.Clear();
        browserHistory.TryPop(out var result);
        Console.WriteLine($"Value after using TryPop : {(result ?? "TryPop returns false cause the Stack is Empty !")}");

        #endregion
    }

    public static void PrintSectionTitle(string title)
    {
        string formattedTitle = $"# {title} #";
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"{new string('=', formattedTitle.Length)}\n" +
                 $"{formattedTitle}\n" +
                 $"{new string('=', formattedTitle.Length)}");
        Console.ResetColor();
    }
    public static void DrawSectionSeparatorLine()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('#', count: 70));
        Console.ResetColor();
    }

}
