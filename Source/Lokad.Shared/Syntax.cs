#region (c)2009 Lokad - New BSD license

// Copyright (c) Lokad 2009 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System;
using System.ComponentModel;
using Lokad.Diagnostics.CodeAnalysis;

namespace Lokad
{
	/// <summary>
	/// Helper class for creating fluent APIs
	/// </summary>
	/// <typeparam name="T">underlying type</typeparam>
	[Immutable]
	[Serializable]
	[NoCodeCoverage]
	public sealed class Syntax<T> : Syntax
	{
		readonly T _inner;

		/// <summary>
		/// Initializes a new instance of the <see cref="Syntax{T}"/> class.
		/// </summary>
		/// <param name="inner">The underlying instance.</param>
		public Syntax(T inner)
		{
			_inner = inner;
		}

		/// <summary>
		/// Gets the underlying object.
		/// </summary>
		/// <value>The underlying object.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public T Target
		{
			get { return _inner; }
		}

		internal static Syntax<T> For(T item)
		{
			return new Syntax<T>(item);
		}
	}

	/// <summary>
	/// Helper class for creating fluent APIs, that hides unused signatures
	/// </summary>
	[Immutable]
	[Serializable]
	[NoCodeCoverage]
	public abstract class Syntax
	{
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
		/// </returns>
		/// <exception cref="T:System.NullReferenceException">
		/// The <paramref name="obj"/> parameter is null.
		/// </exception>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>
		/// Gets the <see cref="T:System.Type"/> of the current instance.
		/// </summary>
		/// <returns>
		/// The <see cref="T:System.Type"/> instance that represents the exact runtime type of the current instance.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return base.GetType();
		}

		internal static Syntax<T> For<T>(T inner)
		{
			return new Syntax<T>(inner);
		}
	}
}