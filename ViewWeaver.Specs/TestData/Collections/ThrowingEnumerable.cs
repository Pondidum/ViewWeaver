using System;
using System.Collections;
using System.Collections.Generic;

namespace ViewWeaver.Specs.TestData.Collections
{
	public class ThrowingEnumerable<T> : IEnumerable<T>, IEnumerator<T>
	{
		#region IEnumerable

		public IEnumerator<T> GetEnumerator() { return this; }
		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

		#endregion

		#region IEnumerator

		public T Current { get { return default(T); } }
		object IEnumerator.Current { get { return Current; } }

		public void Dispose() { }
		public bool MoveNext() { throw new NotSupportedException(); }
		public void Reset() { }

		#endregion
	}
}
