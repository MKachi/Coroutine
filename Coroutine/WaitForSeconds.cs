using System;
using System.Collections;

namespace Coroutine
{
    public class WaitForSeconds : IEnumerator
    {
        private DateTime _targetTime;
        private double _waitTime = 0;

        public object Current { get; set; }

        public WaitForSeconds(double second)
        {
            _waitTime = second;
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
            _targetTime = DateTime.Now.AddSeconds(_waitTime);
        }
    }
}
