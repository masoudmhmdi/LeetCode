// See https://aka.ms/new-console-template for more information

public class Program()
{

    public static void Main()
    {
        var data = new DTO()
        {
            data = "noModified"
        };


        Program.Modifier(data);
        
        Console.WriteLine("Hello World!");
        
    }

    public static void Modifier(DTO dto)
    {
        dto = null;
    }
}


public class DTO
{
    public string data { get; set; }
}