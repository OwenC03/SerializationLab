using System;
using System.IO;
using System.Text.Json;


// The main program that runs all the events.
class Program
{
    static void Main(string[] args)
    {
        // Creates an Event Object and assigns it values 
        Event myEvent = new Event { EventNumber = 1, Location = "Calgary" };

        // Using serialization to turn the event object into a JSON file called event.json
        SerializeToJsonFile("event.json", myEvent);

        // Using deserialize convert the info back to a readable language and display it
        Event deserializedEvent = DeserializeFromJsonFile("event.json");
        Console.WriteLine($"Event Number: {deserializedEvent.EventNumber}");
        Console.WriteLine($"Location: {deserializedEvent.Location}");

        // Insert the word "Hackathon" into the file and read the first, middle and last letter.
        ReadFromFile("event.json");

        // Serializing methods used to create the ToJsonFile methods
        static void SerializeToJsonFile(string filePath, object obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(filePath, jsonString);
        }

        // Deserializing methods used to convert the serialized files back to readable material
        static Event DeserializeFromJsonFile(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Event>(jsonString);
        }


        // the Method that is used to add "Hackathon" to the json file and read it
        static void ReadFromFile(string filePath)
        {
            string inWord = "Hackathon";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(inWord);
            }
            Console.WriteLine("In Word: " + inWord);

            using (FileStream fileSeek = new FileStream(filePath, FileMode.Open))
            {
                // Reads the first letter 
                fileSeek.Seek(0, SeekOrigin.Begin);
                int firstLetter = fileSeek.ReadByte();
                Console.WriteLine($"The first letter is: \"{(char)firstLetter}\"");

                // Reads the letter in the middle
                fileSeek.Seek(fileSeek.Length / 2, SeekOrigin.Begin);
                int secondLetter = fileSeek.ReadByte();
                Console.WriteLine($"The second letter is: \"{(char)secondLetter}\"");

                // Reads the last Letter 
                fileSeek.Seek(-1, SeekOrigin.End);
                int lastLetter = fileSeek.ReadByte();
                Console.WriteLine($"The last letter is: \"{(char)lastLetter}\"");
            }
        }
    }
}

//creates the Event class that holds the EventNumber and Location info
public class Event
{
    public int EventNumber { get; set; }
    public string Location { get; set; }
}






