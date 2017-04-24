using System;

public static class StrBench {

    private static readonly String[] GREEK_CHARS = new String[]
    {
        "Alpha", "Beta", "Gamma", "Delta", "Epsilon",
        "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda",
        "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma",
        "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega"
    };

    public static Object noJoin() {
		return null;
    }

    public static Object testJoinWithPlus() {
		return StrJoins.JoinWithPlus(GREEK_CHARS);
    }

    public static Object testJoinWithBuilder() {
		return StrJoins.JoinWithBuilder(GREEK_CHARS);
    }

    public static Object testJoinWithJoin() {
		return StrJoins.JoinWithJoin(GREEK_CHARS);
    }

	public static void Main()
	{
		const long ITER_TIME  = 1000;
		const long NUM_WARMUP = 10;
		const long NUM_ITER   = 10;

		NBench.Benchmark(new BenchmarkMethod(StrBench.noJoin), "noJoin", ITER_TIME, NUM_WARMUP, NUM_ITER);
		NBench.Benchmark(new BenchmarkMethod(StrBench.testJoinWithPlus), "JoinWithPlus", ITER_TIME, NUM_WARMUP, NUM_ITER);
		NBench.Benchmark(new BenchmarkMethod(StrBench.testJoinWithBuilder), "JoinWithBuilder", ITER_TIME, NUM_WARMUP, NUM_ITER);
		NBench.Benchmark(new BenchmarkMethod(StrBench.testJoinWithJoin), "JoinWithJoin", ITER_TIME, NUM_WARMUP, NUM_ITER);
	}
}
