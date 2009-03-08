#region (c)2009 Lokad - New BSD license

// Copyright (c) Lokad 2009 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

namespace System.Diagnostics.CodeAnalysis
{
	/// <summary>
	/// Used by <see cref="MeansImplicitUseAttribute"/>
	/// </summary>
	[Flags]
	public enum ImplicitUseFlags
	{
		/// <summary>
		/// Standard
		/// </summary>
		STANDARD = 0,
		/// <summary>
		/// All members used
		/// </summary>
		ALL_MEMBERS_USED = 1
	}
}