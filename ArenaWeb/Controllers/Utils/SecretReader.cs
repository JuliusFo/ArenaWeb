namespace ArenaWeb.Controllers.Utils
{
	public static class SecretReader
	{
		public const string secretPath = "F:/Temp/Secrets.ini";

		/// <summary>
		/// Returns the value for a given key.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetValue(string key)
		{
			IniReader reader = new IniReader(secretPath);
			return reader.GetValue(key);
		}
	}
}