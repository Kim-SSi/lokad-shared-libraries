#region (c)2009-2010 Lokad - New BSD license

// Copyright (c) Lokad 2009-2010 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

namespace Lokad.Testing
{
	static class Assert
	{
		public static void Fail(string message, params object[] args)
		{
			throw new FailedAssertException(string.Format(message, args));
		}

		public static void IsTrue(bool expression, string message, params object[] args)
		{
			if (!expression)
				throw new FailedAssertException(string.Format(message, args));
		}

		public static void IsFalse(bool expression, string message, params object[] args)
		{
			if (expression)
				throw new FailedAssertException(string.Format(message, args));
		}
	}
}