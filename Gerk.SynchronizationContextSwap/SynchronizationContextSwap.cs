using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gerk.SynchronizationContextSwap
{
	/// <summary>
	/// Use within using statment to swap to new context.
	/// Lets you use <see cref="Task.Wait()"/> or <see cref="Task{T}.Result"/> within the using block.
	/// </summary>
	public class SynchronizationContextSwap<T> : IDisposable
	{
		/// <summary>
		/// The old context that is replaced.
		/// </summary>
		public SynchronizationContext OldContext { get; private set; }

		/// <summary>
		/// Constructor. Passing nothing is default behavior.
		/// </summary>
		/// <param name="newContext">The new SynchronizationContext being passed in. Leave <see langword="null"/> for default behavior.</param>
		public SynchronizationContextSwap(SynchronizationContext newContext = null)
		{
			OldContext = SynchronizationContext.Current;
			SynchronizationContext.SetSynchronizationContext(newContext);
		}

		/// <summary>
		/// Returns to the original context.
		/// </summary>
		public void Dispose()
		{
			SynchronizationContext.SetSynchronizationContext(OldContext);
		}
	}
}
