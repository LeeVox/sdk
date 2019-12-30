using System;

namespace LeeVox.Sdk
{
	public static class BytesExtensions
	{
		public static string ToHexaString(this byte[] bytes)
			=> BitConverter.ToString(bytes).Replace("-", string.Empty);

		public static string ToBase64String(this byte[] bytes)
			=> Convert.ToBase64String(bytes);
	}
}