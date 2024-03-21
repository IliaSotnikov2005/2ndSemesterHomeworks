using UniqueListSpace;

SingleLinkedList<int> list = new();
list.Add(2);
list.Add(1);
list.Add(3);
Console.WriteLine(list);
UniqueList<int> a = new();
a.Add(1);
a.Add(2);
a.Add(3);
a.Add(2);
Console.WriteLine(a);
