using System;
using System.Reflection;

class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string AdditionalProperty { get; set; }
}

class Program
{
    static void Main()
    {
        // Step 3: Test the Dynamic Property Mapping

        // Create instances of Source and Destination classes
        Source source = new Source
        {
            Id = 1,
            Name = "Product",
            Price = 19.99
        };

        Destination destination = new Destination
        {
            Id = 0, // Initialized to a different value
            AdditionalProperty = "Additional Info"
        };

        // Display values before mapping
        Console.WriteLine("Before Mapping - Destination properties:");
        DisplayProperties(destination);

        // Step 2: Implement Dynamic Property Mapping
        MapProperties(source, destination);

        // Display values after mapping
        Console.WriteLine("\nAfter Mapping - Destination properties:");
        DisplayProperties(destination);
        Console.ReadKey();
    }

    // Step 2: Implement Dynamic Property Mapping
    static void MapProperties(object source, object destination)
    {
        // Get the types of the source and destination objects
        Type sourceType = source.GetType();
        Type destinationType = destination.GetType();

        // Use reflection to dynamically map properties
        foreach (PropertyInfo sourceProperty in sourceType.GetProperties())
        {
            PropertyInfo destinationProperty = destinationType.GetProperty(sourceProperty.Name);

            // Check if the property exists in both source and destination
            if (destinationProperty != null && destinationProperty.CanWrite)
            {
                // Set the value in the destination property
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }

    // Helper method to display properties of an object
    static void DisplayProperties(object obj)
    {
        Type type = obj.GetType();

        foreach (PropertyInfo property in type.GetProperties())
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(obj)}");
        }
    }
}
