using System;
// What I added was the option for the user to type "return"
// to show the last 3 words that were deleted or hidden
// to do this I modified some things in the classes: word, scripture and program.
class Program
{
    static void Main(string[] args)
    {
        string book = "Proverbs"; // (example)
        int chapter = 3;
        int verse = 5;
        int endVerse = 6;
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

        Reference reference = new Reference(book, chapter, verse, endVerse);
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("Press enter to continue, type 'return' to display the last deleted word or type 'quit' to terminate the program.");
            string input = Console.ReadLine(); 

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (input.ToLower() == "return")
            {
                scripture.RestoreTheLastWords();
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                continue;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are hidden!");
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }
        }
    }
}