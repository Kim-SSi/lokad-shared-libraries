#region (c)2009 Lokad - New BSD license

// Copyright (c) Lokad 2009 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Lokad.Quality;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace Lokad.Testing
{
	/// <summary>
	/// Container that automatically resolves all unknown dependencies as stubs
	/// </summary>
	[Immutable, UsedImplicitly]
	public class MockContainer : IDisposable
	{
		readonly IContainer _container = new Container();


		/// <summary>
		/// Creates strongly-typed mocking container
		/// </summary>
		/// <typeparam name="TSubject">The type of the subject.</typeparam>
		/// <returns>new container instance</returns>
		public static MockContainer<TSubject> For<TSubject>()
		{
			return new MockContainer<TSubject>();
		}

		/// <summary>
		/// Gets the actial container.
		/// </summary>
		/// <value>The container.</value>
		public IContainer Container
		{
			get { return _container; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MockContainer"/> class.
		/// </summary>
		public MockContainer()
		{
			

			var builder = new ContainerBuilder();
			builder.RegisterSource(new RhinoRegistrationSource());
			_container = builder.Build();
		}

		/// <summary>
		/// Registers the specified component in this container.
		/// </summary>
		/// <typeparam name="TComponent">The type of the component.</typeparam>
		public void Register<TComponent>()
		{
			Build(builder => builder.RegisterType<TComponent>());
		}

		/// <summary>
		/// Registers the specified component instance in this container.
		/// </summary>
		/// <typeparam name="TComponent">The type of the component.</typeparam>
		/// <param name="instance">The actual instance.</param>
		public void Register<TComponent>(TComponent instance)
			where TComponent : class
		{
			Build(builder => builder.RegisterInstance(instance).ExternallyOwned());
		}

		/// <summary>
		/// Builds the specified registration into the container.
		/// </summary>
		/// <param name="registration">The registration.</param>
		public void Build(Action<ContainerBuilder> registration)
		{
			var builder = new ContainerBuilder();
			registration(builder);
			builder.Update(_container);
		}

		/// <summary>
		/// Resolves the specified service from the container
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <returns></returns>
		public TService Resolve<TService>()
		{
			return _container.Resolve<TService>();
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			_container.Dispose();
		}

		/// <summary>
		/// Stubs the specified action against the specified service.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="action">The action.</param>
		/// <returns>method options for the additional configuration</returns>
		public IMethodOptions<TResult> Stub<TService, TResult>(Func<TService, TResult> action) where TService : class
		{
			return _container.Resolve<TService>().Stub(t => action(t));
		}


		/// <summary>
		/// Raises the specified event on the <typeparamref name="TEventSource"/> resolved from the container.
		/// </summary>
		/// <typeparam name="TEventSource">The type of the service.</typeparam>
		/// <param name="eventSubscription">The event subscription that specifies the event to be called.</param>
		/// <param name="args">The optional arguments to be passed to the event.</param>
		/// <returns>same instance of the mock container</returns>
		/// <seealso cref="RhinoMocksExtensions.GetEventRaiser{TEventSource}"/>
		/// <seealso cref="IEventRaiser.Raise(object[])"/>
		public MockContainer RaiseEventOn<TEventSource>(Action<TEventSource> eventSubscription, params object[] args)
			where TEventSource : class
		{
			_container
				.Resolve<TEventSource>()
				.GetEventRaiser(eventSubscription).Raise(args);

			return this;
		}

		/// <summary>
		/// Asserts that a particular method was called on the specified mock object
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <param name="action">The action.</param>
		/// <seealso cref="RhinoMocksExtensions.AssertWasCalled{T}(T,System.Action{T})"/>
		/// <returns>same instance of the mock container</returns>
		public MockContainer AssertWasCalled<TService>(Action<TService> action)
		{
			var resolve = _container
				.Resolve<TService>();
			resolve.AssertWasCalled(action);
			return this;
		}
	}
}