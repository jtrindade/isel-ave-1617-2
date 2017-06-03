using System;
using System.IO;
using System.Threading;

class Student
{
    private readonly string name;
    
    public Student(string nm)
    {
        name = nm;
    }
    
    public string Name
    {
        get { return name; }
    }
}

class LineReader
{
    private StreamReader reader;
    
    public LineReader(string path)
    {
        reader = new StreamReader(File.OpenRead(path));
    }
    
    public string NextLine()
    {
        return reader.ReadLine();
    }
    
    ~LineReader()
    {
        Console.WriteLine("[{0}] Destructor running", Thread.CurrentThread.ManagedThreadId);
        reader.Dispose();
	}
}

class Dtor
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("use: Dtor sometextfile.txt");
            Environment.Exit(1);
        }

        LineReader lines = new LineReader(args[0]);
        
        Console.WriteLine(lines.NextLine());
        Console.WriteLine(lines.NextLine());
        Console.WriteLine(lines.NextLine());
        
        lines = null;
        
        Console.WriteLine();
        Console.WriteLine("[{0}] 'lines' is now collectable", Thread.CurrentThread.ManagedThreadId);
        
        (new Thread(() => {
            
            Thread.Sleep(3000);
            System.GC.Collect();
            
        })).Start();
        
        Console.ReadLine();
	}
}
