// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


//#1 Use LINQ to find the first eruption that is in Chile and print the result.
Eruption chileEruption = eruptions.First(e => e.Location == "Chile");
Console.WriteLine(chileEruption);


//#2 Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Eruption hawaiianEruption = eruptions.First(e => e.Location == "Hawaiian Is");
if (hawaiianEruption != null)
{
    Console.WriteLine(hawaiianEruption);
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}


//3 Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
Eruption greenlandEruption = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (greenlandEruption != null)  // checking if null before printing the info
{
    Console.WriteLine(greenlandEruption);
}
else
{
    Console.WriteLine("No Greenland Eruption found.");  //bc greenland is not found it should print thi code
}

//4 Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.

// Query 4: Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption NewZealandAfter1900 = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
if (NewZealandAfter1900 != null)
{

    Console.WriteLine(NewZealandAfter1900);
}
else
{
    Console.WriteLine("No eruptions found in New Zealand after 1900.");
}


//5 Find all eruptions where the volcano's elevation is over 2000m and print them.
Console.WriteLine("Eruptions with elevation over 2000 meters:");
foreach (Eruption eruption in eruptions)
{
    if (eruption.ElevationInMeters > 2000)
    {
        Console.WriteLine(eruption);
    }
}

//6  Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.

int numberOfEruptionsStartingWithL = 0;

foreach (Eruption eruption in eruptions)
{
    if (eruption.Volcano.StartsWith("L"))
    {
        Console.WriteLine(eruption.ToString());
        Console.WriteLine($"Location: {eruption.Location}\n"); //Tried to get the location name but only came up with one name?
        numberOfEruptionsStartingWithL++;
    }
}

Console.WriteLine($"Number of eruptions starting with 'L': {numberOfEruptionsStartingWithL}");

//7 Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int highestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"Highest elevation: {highestElevation} meters");


//8 Use the highest elevation variable to find and print the name of the Volcano with that elevation.

int highElevation = 0;
string volcanoWithHighElevation = "";

foreach (Eruption eruption in eruptions)
{
    if (eruption.ElevationInMeters > highElevation)
    {
        highElevation = eruption.ElevationInMeters;
        volcanoWithHighElevation = eruption.Volcano;
    }
}
if (!string.IsNullOrEmpty(volcanoWithHighElevation))
{
    Console.WriteLine($"Volcano with the high elevation ({highElevation} meters): {volcanoWithHighElevation}");
}


//9  Print all Volcano names alphabetically.

List<string> volcanoNames = eruptions.Select(e => e.Volcano).ToList();  //i create a list called volcanoNames to store the names of all the volcanoes.
volcanoNames.Sort();  //I use the Sort method to alphabetically sort the volcanoNames list.

foreach (string volcanoName in volcanoNames)  //looping through the list
{
    Console.WriteLine(volcanoName); //This code will print all volcano names in alphabetical order.
}



//10 Print the sum of all the elevations of the volcanoes combined.

int totalElevation = 0;  //keeping track of all the sum elevation

foreach (Eruption eruption in eruptions) //looping through eruptions to find 
{
    totalElevation += eruption.ElevationInMeters;  //adding the property of each eruption to the variable
}

Console.WriteLine($"Combined all the elevation:  {totalElevation} meters");


//11  Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)

bool eruptedInYear2000 = eruptions.Any(e => e.Year == 2000);

if (eruptedInYear2000)
{
    Console.WriteLine(" one volcano erupted in the year 2000.");
}
else
{
    Console.WriteLine("No volcanoes erupted in the year 2000.");
}


//12  Find all stratovolcanoes and print just the first three (Hint: look up Take)

var stratovolcanoes = eruptions.Where(e => e.Type == "Stratovolcano").Take(3).ToList();  //used where to find the eruptions.. Take(3) select the forst 3... moved it to the ToList()

Console.WriteLine("First three stratovolcanoes:");

foreach (Eruption eruption in stratovolcanoes)
{
    Console.WriteLine(eruption);
}

//13  Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.

Console.WriteLine("Eruptions before the year 1000 CE");

var eruptionsBefore1000 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).ToList();

foreach (Eruption eruption in eruptionsBefore1000)
{
    Console.WriteLine(eruption);
}


//14 Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.

Console.WriteLine("Volcano names of eruptions before the year 1000 CE new new:");

var volcanoNamesBefore1000 = eruptions
    .Where(e => e.Year < 1000)  //where to find the location of year
    .OrderBy(e => e.Volcano)  //order by alphbetical
    .Select(e => e.Volcano)  // used select to only find the volcano
    .ToList();  // put the result here

foreach (string volcanoName in volcanoNamesBefore1000)
{
    Console.WriteLine(volcanoName);
}


















