using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Linq
{
    class Student
    {
        public int    Number  { get; set; }
        public string Name    { get; set; }
        public bool   HasQuit { get; set; }
        public int    Grade   { get; set; }
    }

    static List<Student> students = new List<Student>()
    {
        new Student { Number = 1111, Name = "Afonso",   HasQuit = false, Grade = 16 },
        new Student { Number = 2222, Name = "Sancho",   HasQuit = true },
        new Student { Number = 3333, Name = "Dinis",    HasQuit = false, Grade = 13 },
        new Student { Number = 4444, Name = "Pedro",    HasQuit = false, Grade = 17 },
        new Student { Number = 5555, Name = "Fernando", HasQuit = true },
    };
/*
    static void Show(IEnumerable<Student> data)
    {
		// IEnumerable<string> names =
		string best =
			data
				.Where(st => !st.HasQuit)
				.OrderByDescending(st => st.Grade)
				.Select(s => s.Name)
				.First();
		
		// foreach (string studentName in names) {
		//	Console.WriteLine(studentName);
		// }

		Console.WriteLine(best);
	}
*/
/*
    static void Show(IEnumerable<Student> data)
    {
		IEnumerable<string> names =
			from student in data
			where !student.HasQuit
			orderby student.Grade descending
			select student.Name;

		foreach (string studentName in names) {
			Console.WriteLine(studentName);
		}
	}
*/
    static void Show(IEnumerable<Student> data)
    {
		var res = data
			.Where(s => !s.HasQuit)
			.Select(s => new { Index = s.Name[0], Grade = s.Grade });
		
		foreach (var item in res) {
			Console.WriteLine("{0}: {1}", item.Index, item.Grade);
		}
	}

    public static void Main(string[] args)
    {
        Show(students);
    }
}
