using System;
using System.Collections;
using System.Collections.Generic;

// Delegates in Action: exemplos de utilização de delegates.
//
// Programação Funcional.
//
public static class Functional
{
    public delegate void Action1(Object obj);
    public delegate Object Func1(Object obj);
    
    //
    // Aplique-se a função 'action' a cada elemento de 'source'.
    //
	public static void Apply(this IEnumerable source, Action1 action)
	{
		foreach (Object obj in source)
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
	public static IEnumerable EagerMap(this IEnumerable source, Func1 mapper)
	{
		IList res = new List<Object>();
		foreach (Object obj in source)
		{
			res.Add(mapper(obj));
		}
		return res;
	}

	/*
	public class MapEnumerable : IEnumerable
	{
	    ....
		IEnumerator GetEnumerator()
		{
			return new MapEnumerator(objs.GetEnumerator(), mapper);
		}
	}
	 
	public static IEnumerable Map(this IEnumerable objs, Func1 mapper)
	{
		return new MapEnumerable(objs, mapper);
	}
	*/

    // 
    // Produza-se uma sub-sequência com os 'n' primeiros elementos da
    // sequência de entrada 'source'.
    //
    // Versão 'eager'.
    //
    public static IEnumerable EagerTake(this IEnumerable source, int n)
    {
        IList res = new List<Object>();
        foreach (Object obj in source)
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
    public static IEnumerable Take(this IEnumerable source, int n)
    {
        foreach (Object obj in source)
        {
            if (n <= 0) yield break;
            n -= 1;

            yield return obj;
        }
    }

	public static IEnumerable Map(this IEnumerable objs, Func1 mapper)
	{
		foreach (Object obj in objs) {
			Console.WriteLine(":: Generating one more item ::");
			yield return mapper(obj);
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
        
	}
}
