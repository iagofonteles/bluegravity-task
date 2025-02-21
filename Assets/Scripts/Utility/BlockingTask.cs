using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
    public class BlockingTask : BlockingTask<BlockingTask> { }

    public abstract class BlockingTask<T> : MonoBehaviour
    {
        public static readonly Observable<bool> IsBusy = new();
        private static readonly HashSet<object> Tasks = new();

        public static void AddTask(object task)
        {
            if (Tasks.Add(task)) IsBusy.Value = Tasks.Any();
        }

        public static void RemoveTask(object task)
        {
            if (Tasks.Remove(task)) IsBusy.Value = Tasks.Any();
        }

        private void OnEnable() => AddTask(this);
        private void OnDisable() => RemoveTask(this);
    }
}