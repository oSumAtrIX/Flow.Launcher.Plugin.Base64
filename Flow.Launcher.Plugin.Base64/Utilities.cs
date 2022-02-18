using System;
using System.Text;
using System.Windows.Documents;

namespace Flow.Launcher.Plugin.Base64
{
	internal static class Utilities
	{
		internal static string ToBase64String(this string text)
			=> Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
		
		internal static string FromBase64String(this string base64Text)
		{
			var buffer = new byte[(base64Text.Length * 3 + 3) / 4 - (base64Text.Length > 0 && base64Text[^1] == '=' ? 
				base64Text.Length > 1 && base64Text[^2] == '=' ? 2 : 1 : 0)];
			
			return !Convert.TryFromBase64String(base64Text, buffer, out int written) ? 
				"Invalid base64 string" : Encoding.UTF8.GetString(buffer[..written]);
		}
	}

	
}