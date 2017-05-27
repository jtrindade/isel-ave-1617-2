using System;
using System.Collections;
using System.Collections.Generic;

// Delegates in Action: exemplos de utilização de delegates.
//
// Programação Funcional.
//
public static class Functional
{
    public delegate void Action1<T>(T obj);
    public delegate U Func1<T,U>(T obj);
    
    //
    // Aplique-se a função 'action' a cada elemento de 'source'.
    //
	public static void Apply<T>(this IEnumerable<T> source, Action1<T> action)
	{
		foreach (T obj in source)
		{
			action(obj);
		}
	}

    //
    // Produza-se um IEnumerable em que cada elemento resulta de
    // aplicar 'func' a um elemento de 'source'.
    //
    // Implementação 'eager', que usa uma colecção para guardar o resultado
    // do processamento de toda a sequência de entrada.
    //
	public static IEnumerable<U> EagerMap<T,U>(this IEnumerable<T> source, Func1<T,U> mapper)
	{
		IList<U> res = new List<U>();
		foreach (T obj in source)
		{
			res.Add(mapper(obj));
		}
		return res;
	}

	public class MapEnumerator<T,U> : IEnumerator<U>
	{
		public MapEnumerator(IEnumerator<T> seq, Func1<T,U> mapper) {}
		
		public U Current { get { return default(U); } }
		public bool MoveNext() { return false; }
		
		public void Reset() { throw new NotImplementedException(); }
		public void Dispose() {}
	
		Object IEnumerator.Current { get { return Current; } }
	}

	public class MapEnumerable<T,U> : IEnumerable<U>
	{
		private readonly IEnumerable<T> objs;
		private readonly Func1<T,U> mapper;
		
	    public MapEnumerable(IEnumerable<T> objs, Func1<T,U> mapper)
	    {
			this.objs = objs;
			this.mapper = mapper;
		}
		
		public IEnumerator<U> GetEnumerator()
		{
			return new MapEnumerator<T,U>(objs.GetEnumerator(), mapper);
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	 
	public static IEnumerable<U> LazyMap<T,U>(this IEnumerable<T> objs, Func1<T,U> mapper)
	{
		return new MapEnumerable<T,U>(objs, mapper);
	}

	public static IEnumerable<U> Map<T,U>(this IEnumerable<T> objs, Func1<T,U> mapper)
	{
		foreach (T obj in objs) {
			Console.WriteLine(":: Generating one more item ::");
			yield return mapper(obj);
		}
	}

    // 
    // Produza-se uma sub-sequência com os 'n' primeiros elementos da
    // sequência de entrada 'source'.
    //
    // Versão 'eager'.
    //
    public static IEnumerable<T> EagerTake<T>(this IEnumerable<T> source, int n)
    {
        IList<T> res = new List<T>();
        foreach (T obj in source)
        {
            if (n <= 0) break;
            n -= 1;

            res.Add(obj);
        }
        return res;
    }

    // 
    // Produza-se uma sub-sequência com os 'n' primeiros elementos da
    // sequência de entrada 'source'.
    //
    // Versão 'lazy'.
    //
    public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int n)
    {
        foreach (T obj in source)
        {
            if (n <= 0) yield break;
            n -= 1;

            yield return obj;
        }
    }

    public static void Main(String[] args)
    {
        if (args.Length == 0)
        {
            args = new String[] { "alpha", "beta", "gamma", "delta", "epsilon" };
        }

        // Estilo imperativo
        foreach (String arg in args)
        {
            Console.WriteLine(arg);
        }
        
        // Estilo funcional
        Apply(args, Console.WriteLine);

        // Utilização de Apply como 'método de extensão'.
        // Permitido devido ao uso da palavra-chave 'this' no primeiro argumento do método Apply.
        args.Apply(Console.WriteLine);
        
        Console.WriteLine();
        
        // Transformação misturada com acção final.
        args.Apply(o => { Console.WriteLine(o.ToString().Length); });
        
        Console.WriteLine();
        
        // Separação entre transformação (Map) e acção final (Apply).
        args
			.Map(o => o.ToString().Length)
			.Apply(Console.WriteLine);
        
        Console.WriteLine();
        
        // Restrição da sequência de saída a 3 elementos.
        // Questão: quantas vezes é invocado o delegate configurado em Map?
        args
			.Map(o => o.ToString().Length)
			.Take(3)
			.Apply(Console.WriteLine);
        
        Console.WriteLine();
        
        args.Map(i => i + 3).Apply(Console.WriteLine);
	}
}
