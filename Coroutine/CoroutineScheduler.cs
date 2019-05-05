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
                if (!(_coroutines[i].Action is null))
                {
                    if (_coroutines[i].Action.MoveNext())
                    {
                        _coroutines[i].Action = null;
                    }
                }
                else
                {
                    _coroutines[i].Routine.MoveNext();
                    if (!(_coroutines[i].Routine.Current is null))
                    {
                        _coroutines[i].Action = _coroutines[i].Routine.Current as IEnumerator;
                    }
                }
            }
        }
    }
}
