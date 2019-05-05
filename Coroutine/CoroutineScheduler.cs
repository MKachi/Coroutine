using System;
using System.Collections;
using System.Collections.Generic;

namespace Coroutine
{
    public class CoroutineScheduler
    {
        private List<Coroutine> _coroutines = new List<Coroutine>();

        public void Add(IEnumerator routine)
        {
            Coroutine coroutine = new Coroutine
            {
                Routine = routine,
                Action = null
            };
            _coroutines.Add(coroutine);
        }
        public void Remove(IEnumerator routine)
        {
            _coroutines.RemoveAll(new Predicate<Coroutine>((Coroutine target) =>
            {
                if (target.Routine.Equals(routine))
                {
                    return true;
                }
                return false;
            }));
        }

        public void Update()
        {
            for (int i = 0; i < _coroutines.Count; ++i)
            {
                Coroutine coroutine = _coroutines[i];
                if (!(coroutine.Routine is null))
                {
                    if (coroutine.Routine.MoveNext())
                    {
                        coroutine.Action = null;
                    }
                }
                else
                {
                    coroutine.Routine.MoveNext();
                    if (!(coroutine.Routine.Current is null))
                    {
                        coroutine.Action = coroutine.Routine.Current as IEnumerator;
                    }
                }
            }
        }
    }
}
