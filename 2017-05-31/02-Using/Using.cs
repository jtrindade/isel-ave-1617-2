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

class LineReader : IDisposable
{
	private bool disposed = false;
    private StreamReader reader;
    
    public LineReader(string path)
    {
        reader = new StreamReader(File.OpenRead(path));
    }
    
    public string NextLine()
    {
        return reader.ReadLine();
    }
    
    public void Dispose()
    {
		Console.WriteLine("[{0}] Dispose running", Thread.CurrentThread.ManagedThreadId);
		Dispose(true);
		GC.SuppressFinalize(this);
	}
    
    ~LineReader()
    {
        Console.WriteLine("[{0}] Destructor running", Thread.CurrentThread.ManagedThreadId);
        Dispose(false);
	}
	
	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			// unconditionally dispose unmanaged resources here

			if (disposing)
			{
				// but conditionally dispose managed resources
				reader.Dispose();
			}

			disposed = true;
		}
	}
}

class Dtor
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("use: Using sometextfile.txt");
            Environment.Exit(1);
        }

        using (LineReader lines = new LineReader(args[0])) {
			Console.WriteLine(lines.NextLine());
			Console.WriteLine(lines.NextLine());
			Console.WriteLine(lines.NextLine());
		}
       
        Console.WriteLine();
        Console.WriteLine("[{0}] 'lines' is now collectable", Thread.CurrentThread.ManagedThreadId);
        
        (new Thread(() => {
            
            Thread.Sleep(3000);
            System.GC.Collect();
            
        })).Start();
        
        Console.ReadLine();
	}
}
