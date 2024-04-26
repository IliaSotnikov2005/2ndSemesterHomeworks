PriorityQueue<string> queue = new ();
queue.Enqueue("a", 1);
queue.Enqueue("b", 4);
queue.Enqueue("b", 2);
queue.Enqueue("a", 2);
queue.Enqueue("o", 3);

for (int i = 0; i < 5; i++)
{
    var item = queue.Dequeue();
    Console.WriteLine(item);
}
