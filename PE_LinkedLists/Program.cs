namespace PE_LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> awesomeList = new LinkedList<string>();

            string userIn;

            Console.Write("please enter 5 things: ");

            for (int x = 0; x < 5; x++)
            {
                userIn = Console.ReadLine()!;

                awesomeList.Add(userIn);

                
            }

            Console.WriteLine("Heres da stuff:");

            for (int x = 0; x < awesomeList.Count; x++)
            {
                Console.WriteLine(awesomeList[x]);
            }

            Console.WriteLine($"Removed index 0: {awesomeList.RemoveAt(0)}");
            Console.WriteLine($"Removed index 4: {awesomeList.RemoveAt(awesomeList.Count - 1)}");
            Console.WriteLine($"Removed index 1: {awesomeList.RemoveAt(1)}");
            

            Console.WriteLine("Heres da stuff:");

            for (int x = 0; x < awesomeList.Count; x++)
            {
                Console.WriteLine(awesomeList[x]);
            }

            //finally
        }
    }
}
