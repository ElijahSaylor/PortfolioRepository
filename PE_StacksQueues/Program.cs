namespace PE_StacksQueues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameStack<string> johnStack = new GameStack<string>();
            GameQueue<string> johnQueue = new GameQueue<string>();

            johnStack.Push(["rocket", "fireball","arrows","log"]);

            while(johnStack.Count != 0)
            {
                Console.WriteLine(johnStack.Pop());
            }
            Console.WriteLine(johnStack.Count);

            johnQueue.Enqueue(["Joe","Mitch","Obert","Jarvis"]);

            while(johnQueue.Count != 0)
            {
                Console.WriteLine(johnQueue.Dequeue());
            }
            Console.WriteLine(johnQueue.Count);

            try { johnStack.Pop(); } 
            catch {
                Console.WriteLine(" If you are reading this, there was a " +
                "terrible error in johnStack.pop() which I, oh great and might catch{} block, am saving" +
                " you from!"); 
            }

            try { johnQueue.Dequeue(); }
            catch
            {
                Console.WriteLine(" If you are reading this, there was a " +
                "terrible error in johnQueue.Dequeue() which I, oh great and might catch{} block, am saving" +
                " you from!");
            }
        }
    }
}
