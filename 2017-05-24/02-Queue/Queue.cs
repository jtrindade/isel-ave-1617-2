using System;
using System.Collections.Generic;

interface ISink<in T>
{
    void Put(T item);
}

interface ISource<out T>
{
    T Take();
}

class Queue<T> : ISource<T>, ISink<T>
{
    private LinkedList<T> list = new LinkedList<T>();
    
    public void Put(T item)
    {
        list.AddLast(item);
    }
    
    public T Take()
    {
        if (list.Count == 0)
            throw new InvalidOperationException();
        
        T res = list.First.Value;
        list.RemoveFirst();
        return res;
    }	
}


class Consumer<T>
{
    private readonly ISource<T> source;
    
    public Consumer(ISource<T> source)
    {
        this.source = source;
    }
    
    public void Consume()
    {
        T obj = source.Take();
        Console.WriteLine(obj.GetType().Name);
    }
}

class Producer<T> where T : new()
{
    private readonly ISink<T> sink;
    
    public Producer(ISink<T> sink)
    {
        this.sink = sink;
    }
    
    public void Produce()
    {
        sink.Put(new T());
    }
}

class A {}
class B : A {}
class C : B {}

class UseQueue
{
    static void Main()
    {
        Queue<B> queue = new Queue<B>();
        
        Producer<C> prod = new Producer<C>(queue);
        Consumer<A> cons = new Consumer<A>(queue);
        
        prod.Produce();
        prod.Produce();
        prod.Produce();

        cons.Consume();
        cons.Consume();
        cons.Consume();
	}
}
