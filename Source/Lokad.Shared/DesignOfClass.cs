#region (c)2009-2010 Lokad - New BSD license

// Copyright (c) Lokad 2009-2010 


// Company: http://www.lokad.com


// This code is released under the terms of the new BSD licence

#endregion

using System;
using Lokad.Quality;

namespace Lokad
{
	/// <summary>
	/// 	Class design markers for the Lokad namespace
	/// </summary>
	public static class DesignOfClass
	{
	

		/// <summary>
		/// 	Indicates that a class is an immutable model with fields
		/// </summary>
		[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
		public sealed class ImmutableFieldsModel : ClassDesignAttribute
		{
			/// <summary>
			/// 	Initializes a new instance of the
			/// 	<see cref="ImmutableFieldsModel" />
			/// 	class.
			/// </summary>
			public ImmutableFieldsModel()
				: base(DesignTag.Model, DesignTag.ImmutableWithFields)
			{
			}
		}

		/// <summary>
		/// 	Indicates that a class is an immutable model with properties
		/// </summary>
		[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
		public sealed class ImmutablePropertiesModel : ClassDesignAttribute
		{
			/// <summary>
			/// 	Initializes a new instance of the
			/// 	<see cref="ImmutablePropertiesModel" />
			/// 	class.
			/// </summary>
			public ImmutablePropertiesModel() : base(DesignTag.Model, DesignTag.ImmutableWithProperties)
			{
			}
		}
	}
}