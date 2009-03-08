#region (c)2009 Lokad - New BSD license

// Copyright (c) Lokad 2009 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Lokad.Quality
{
	/// <summary>
	/// Extensions for the <see cref="ModuleDefinition"/>
	/// </summary>
	public static class MethodDefinitionExtensions
	{
		/// <summary>
		/// Gets the instructions for the specified method.
		/// </summary>
		/// <param name="method">The method.</param>
		/// <returns>enumerator over the instructions within the method</returns>
		public static IEnumerable<Instruction> GetInstructions(this MethodDefinition method)
		{
			if (!method.HasBody)
				return Enumerable.Empty<Instruction>();

			return method.Body.Instructions.Cast<Instruction>();
		}



		/// <summary>
		/// Determines whether the provided <see cref="MethodDefinition"/> 
		/// has specified attribute (matching is done by full name)
		/// </summary>
		/// <typeparam name="TAttribute">The type of the attribute.</typeparam>
		/// <param name="reference">The <see cref="MethodDefinition"/> to check.</param>
		/// <returns>
		/// 	<c>true</c> if the specified attribute is found otherwise, <c>false</c>.
		/// </returns>
		public static bool Has<TAttribute>(this MethodDefinition reference) where TAttribute : Attribute
		{
			foreach (CustomAttribute attribute in reference.CustomAttributes)
			{
				if (attribute.Constructor.DeclaringType.Is<TAttribute>())
					return true;
			}

			return false;
		}
	}
}