using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmark.Common {
    public class TaskManager {
        static object lockerCore = new object();
        static TaskManager managerCore;
        public static TaskManager Current {
            get {
                if(managerCore == null)
                    managerCore = new TaskManager();
                return managerCore;
            }
        }
        public static object Locker {
            get { return lockerCore; }
        }
        public void RunTasks<T>(IEnumerable<T> elements, Action<T> action) {
            RunTasksCore(elements, (el) => action(el));
        }
        public T[] RunTasks<U, T>(IEnumerable<U> elements, Func<U, T> action) {
            List<T> results = new List<T>();
            RunTasksCore(elements, (el) =>
            {
                T result = action(el);
                lock(lockerCore)
                    results.Add(result);
            });
            return results.ToArray();
        }

        //void RunListenerTask<T>(IEnumerable<T> elements, Action<T> action) {
        //    Task listener = Task.Factory.StartNew(() => RunTasksCore(elements, action))
        //        .ContinueWith(task => task.RunSynchronously());
        //}
        void RunTasksCore<T>(IEnumerable<T> elements, Action<T> action) {
            try {
                List<Task> pool = new List<Task>();
                SemaphoreSlim semaphore = new SemaphoreSlim(0, 5);
                foreach(T el in elements) {
                    pool.Add(Task.Factory.StartNew(() =>
                                    {
                                        semaphore.Wait();
                                        action(el);
                                        semaphore.Release();
                                    }));
                }
                semaphore.Release(5);
                Task.WaitAll(pool.ToArray());
                DestroyTasks(pool);
            }
            catch { }
        }
        void DestroyTasks(IEnumerable<Task> tasks) {
            if(tasks == null) return;
            foreach(Task task in tasks)
                task.Dispose();
        }
    }
}