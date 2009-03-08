#region (c)2008 Lokad - New BSD license

// Copyright (c) Lokad 2008 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System.Diagnostics.CodeAnalysis;

namespace System
{
	/// <summary>
	/// Extension methods for the <see cref="INamedProvider{TValue}"/>
	/// of <see cref="ILog"/>
	/// </summary>
	[NoCodeCoverage]
	public static class ILogProviderExtensions
	{
		/// <summary>
		/// Creates new log using the type as name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static ILog CreateLog<T>(this INamedProvider<ILog> logProvider) where T : class
		{
			return logProvider.Get(typeof (T).Name);
		}
	}
}