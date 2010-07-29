﻿#region (c)2009-2010 Lokad - New BSD license

// Copyright (c) Lokad 2009-2010 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Lokad.Quality;

namespace Lokad.Serialization
{
	[UsedImplicitly]
	public class ProtoBufSerializer : IDataSerializer, IDataContractMapper
	{
		readonly IDictionary<string, Type> _contract2Type = new Dictionary<string, Type>();
		readonly IDictionary<Type, string> _type2Contract = new Dictionary<Type, string>();
		readonly IDictionary<Type, IFormatter> _type2Formatter = new Dictionary<Type, IFormatter>();

		[UsedImplicitly]
		public ProtoBufSerializer(ICollection<Type> knownTypes)
		{
			foreach (var type in knownTypes)
			{
				var reference = ProtoBufUtil.GetContractReference(type);
				var formatter = ProtoBufUtil.CreateFormatter(type);

				_contract2Type.Add(reference, type);
				_type2Contract.Add(type, reference);
				_type2Formatter.Add(type, formatter);
			}
		}

		public void Serialize(object instance, Stream destination)
		{
			_type2Formatter
				.GetValue(instance.GetType())
				.ExposeException("Unknown object type {0}", instance.GetType())
				.Serialize(destination, instance);
		}

		public object Deserialize(Stream source, Type type)
		{
			return _type2Formatter
				.GetValue(type)
				.ExposeException("Unknown object type {0}", type)
				.Deserialize(source);
		}

		public Maybe<string> GetContractNameByType(Type messageType)
		{
			return _type2Contract.GetValue(messageType);
		}

		public Maybe<Type> GetTypeByContractName(string contractName)
		{
			return _contract2Type.GetValue(contractName);
		}
	}
}