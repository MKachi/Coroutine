using System.Collections;

namespace Coroutine
{
    public struct Coroutine
    {
        public IEnumerator Routine { get; set; }
        public IEnumerator Action { get; set; }
    }
}