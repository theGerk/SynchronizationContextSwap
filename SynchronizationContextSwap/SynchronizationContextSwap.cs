using System;
using System.Threading;

namespace SynchronizationContextSwap
{
	public class SynchronizationContextSwap : IDisposable
	{
		public SynchronizationContext OldContext { get; private set; }

		SynchronizationContextSwap(SynchronizationContext newContext = null)
		{
			OldContext = SynchronizationContext.Current;
			SynchronizationContext.SetSynchronizationContext(newContext);
		}

		public void Dispose()
		{
			SynchronizationContext.SetSynchronizationContext(OldContext);
		}
	}
}
