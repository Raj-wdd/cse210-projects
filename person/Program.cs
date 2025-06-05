class Program
{
    public static void main(String[] args)
    {
        Person myPerson = new Person("Bubba", "Bob", 53);
        Console.WriteLine(myPerson.GetPersonInformation());
        PoliceMan myPoliceMan = new PoliceMan("Cooper", "Silver", 53);
        Console.WriteLine(myPoliceMan.GetPersonInformation());
     }
    
}
