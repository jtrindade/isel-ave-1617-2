package pt.isel.leic.ave;

public class StrJoins
{
	public static String joinWithPlus(String[] parts)
	{
		String res = "";
		for (int i = 0; i < parts.length; ++i) {
			res += parts[i];
		}
		return res;
	}

	public static String joinWithBuilder(String[] parts)
	{
		StringBuilder res = new StringBuilder();
		for (int i = 0; i < parts.length; ++i) {
			res.append(parts[i]);
		}
		return res.toString();
	}

	public static String joinWithJoin(String[] parts)
	{
		return String.join("", parts);
	}

}
