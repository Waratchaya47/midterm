using System;
class Program {
    static void Main(string[] args) {
        Console.Write("Enter the number of cities: ");
        int numOfCities = int.Parse(Console.ReadLine());

        City[] cities = new City[numOfCities];

        for (int i = 0; i < numOfCities; i++){
            Console.WriteLine($"City {i}:");

            // Input city name
            Console.Write("Enter city name: ");
            string cityName = Console.ReadLine();

            // Input number of connected cities
            Console.Write("Enter the number of cities connected to this city: ");
            int connectedTo = int.Parse(Console.ReadLine());

            // Input connected cities
            int[] connectedCities = new int[connectedTo];
            for (int j = 0; j < connectedTo; j++)
            {
                Console.Write("Enter the ID of the connected city: ");
                int cityId = int.Parse(Console.ReadLine());

     
                connectedCities[j] = cityId;
            }

            cities[i] = new City(cityName, connectedTo, connectedCities);
        }

        // Print city details
        Console.WriteLine("\nCity Details:");
        for (int i = 0; i < numOfCities; i++)
        {
            Console.WriteLine($"City {i}: {cities[i].Name}");
            Console.Write("Connected cities: ");
            foreach (int connectedCity in cities[i].ConnectedCities)
            {
                Console.Write(connectedCity + " ");
            }
            Console.WriteLine("\n");
        }

        Console.WriteLine("Input Event: ");
        string userEvent = Console.ReadLine();
         if (userEvent == "Outbreak" || userEvent == "Vaccinate" || userEvent == "Lockdown") {
                Console.Write("Enter the city ID: ");
                int cityId = int.Parse(Console.ReadLine());
               ProcessEvent(userEvent, cityId,  cityName, cityLevels);
                 
         }
    }
}

              
class City
{
    public string Name { get; }
    public int ConnectedTo { get; }
    public int[] ConnectedCities { get; }
    public int CovidLevels {get;}

    public City(string name, int connectedTo, int[] covidLevels)
    {
        Name = name;
        ConnectedTo = connectedTo;
        CovidLevels = 0;
    }
    static void ProcessEvent(string userEvent, int cityId, string[] cityNames, int[] cityLevels){
        if (userEvent == "Outbreak") {
            cityLevels[cityId] += 2;

            if (cityId > 0) {
                cityLevels[cityId - 1]++;
            }
            if (cityId < cityLevels.Length - 1){
                cityLevels[cityId + 1]++;
            }
        }
        else if (userEvent == "Vaccinate"){
            cityLevels[cityId] = 0;
        }
        else if (userEvent == "Lockdown"){
            cityLevels[cityId]--;

            if (cityId > 0){
                cityLevels[cityId - 1]--;
            }
            if (cityId < cityLevels.Length - 1){
                cityLevels[cityId + 1]--;
            }
        }
    }

    static void SpreadEvent(int[] cityLevels){
        for (int i = 0; i < cityLevels.Length; i++){
            if (i > 0 && cityLevels[i - 1] > cityLevels[i]){
                cityLevels[i]++;
            }
            if (i < cityLevels.Length - 1 && cityLevels[i + 1] > cityLevels[i]) {
                cityLevels[i]++;
            }
        }
    }
}

    
   

