using System;
using System.Collections;
using System.Threading.Tasks;

namespace Coroutine
{
    class Program
    {
        private static CoroutineScheduler _scheduler = new CoroutineScheduler();

        static void Main(string[] args)
        {
            Task coroutineTask = null;
            try
            {
                coroutineTask = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        _scheduler.Update();
                    }
                });
                StartCoroutine(Test());
                while (true) ;
            }
            catch (Exception except)
            {
                Console.WriteLine(except.Message);
            }
            finally
            {
                if (!(coroutineTask is null)) 
                {
                    coroutineTask.Dispose();
                    coroutineTask = null;
                }
            }
        }

        private static void StartCoroutine(IEnumerator coroutine)
        {
            _scheduler.Add(coroutine);
        }
        private static void StopCoroutine(IEnumerator coroutine)
        {
            _scheduler.Remove(coroutine);
        }

        private static IEnumerator Test()
        {
            Console.WriteLine("Hello");
            yield return new WaitForSeconds(1.0f);
            Console.WriteLine("Test 1");
            yield return new WaitForSeconds(1.0f);
            Console.WriteLine("Test 2");
        }
    }
}
