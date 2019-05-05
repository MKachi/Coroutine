using System;
using System.Collections;

namespace Coroutine
{
    public class WaitForMilliSeconds : IEnumerator
    {
        private DateTime _targetTime;
        private int _waitTime = 0;

        public object Current { get; set; }

        public WaitForMilliSeconds(int millisecond)
        {
            _waitTime = millisecond;
            Reset();
        }

        public bool MoveNext()
        {
            if (DateTime.Now >= _targetTime)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            Current = null;
            _targetTime = DateTime.Now.AddMilliseconds(_waitTime);
        }
    }
}
