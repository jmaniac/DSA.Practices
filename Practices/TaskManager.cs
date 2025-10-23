namespace Practices.Problems
{
    public class TaskManager
    {
        private Dictionary<int, PriorityTask> Tasks;
        private PriorityQueue<AssignedTask, PriorityTask> PriorityQueue = new();

        public TaskManager(IList<IList<int>> tasks)
        {
            foreach (var task in tasks)
            {
                int userId = task[0];
                int taskId = task[1];
                int priority = task[2];
                Add(userId, taskId, priority);
            }
        }

        public void Add(int userId, int taskId, int priority)
        {
            if (!Tasks.ContainsKey(taskId))
            {
                var task = new AssignedTask(userId, taskId, priority);
                Tasks.Add(taskId, task);
                PriorityQueue.Enqueue(task, task);
            }
        }

        public void Edit(int taskId, int newPriority)
        {
            if (!Tasks.TryGetValue(taskId, out var task))
            {
                task.Priority = newPriority;

                //PriorityQueue.Enqueue(task, task);
            }
        }

        public void Rmv(int taskId)
        {
            if (Tasks.ContainsKey(taskId))
            {
                Tasks.Remove(taskId);
            }
        }

        //public int ExecTop()
        //{
        //    while (PriorityQueue.Count > 0)
        //    {
        //        var assignedTask = PriorityQueue.Dequeue();
        //        if (Tasks.ContainsKey(assignedTask.TaskId))
        //        {
        //            var task = Tasks[assignedTask.TaskId];
        //            if (assignedTask.UserId == userId && currPriority == priority)
        //            {
        //                Tasks.Remove(taskId);
        //                return userId;
        //            }
        //        }
        //    }
        //}

        public class PriorityTask : IComparable<PriorityTask>
        {
            public int TaskId { get; set; }
            public int Priority { get; set; }

            public PriorityTask(int taskId, int priority)
            {
                this.TaskId = taskId;
                this.Priority = priority;
            }

            public int CompareTo(PriorityTask other)
            {
                if (other == null) { return 1; }

                if (this.Priority == other.Priority)
                {
                    return this.TaskId.CompareTo(other.TaskId);
                }

                return this.Priority.CompareTo(other.Priority);
            }
        }

        public class AssignedTask : PriorityTask, IComparable<AssignedTask>
        {
            public int UserId { get; set; }

            public AssignedTask(int userId, int taskId, int priority) : base(taskId, priority)
            {
                this.UserId = userId;
            }

            public int CompareTo(AssignedTask other)
            {
                if (other == null) { return 1; }

                if (this.Priority == other.Priority)
                {
                    return this.TaskId.CompareTo(other.TaskId);
                }

                return this.Priority.CompareTo(other.Priority);
            }
        }
    }
}

public class TaskManagerCopied
{
    private Dictionary<int, (int taskId, int priority)> Tasks;
    private PriorityQueue<(int priority, int taskId, int userId), (int, int, int)> maxHeap;

    public TaskManagerCopied(IList<IList<int>> tasks)
    {
        Tasks = new Dictionary<int, (int, int)>();
        maxHeap = new PriorityQueue<(int priority, int taskId, int userId), (int, int, int)>(
        Comparer<(int, int, int)>.Create((a, b) =>
        {
            // Higher priority first
            if (a.Item1 != b.Item1) return b.Item1.CompareTo(a.Item1);
            // If tie → larger taskId first
            return b.Item2.CompareTo(a.Item2);
        })
        );

        foreach (var task in tasks)
        {
            int userId = task[0];
            int taskId = task[1];
            int priority = task[2];
            this.Add(userId, taskId, priority);
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        if (!Tasks.ContainsKey(taskId))
        {
            Tasks.Add(taskId, (userId, priority));
            maxHeap.Enqueue((priority, taskId, userId), (priority, taskId, userId));
        }
    }

    public void Edit(int taskId, int newPriority)
    {
        if (Tasks.ContainsKey(taskId))
        {
            var (userId, _) = Tasks[taskId];
            Tasks[taskId] = (userId, newPriority);
            maxHeap.Enqueue((newPriority, taskId, userId), (newPriority, taskId, userId));

        }
    }

    public void Rmv(int taskId)
    {
        if (Tasks.ContainsKey(taskId))
        {
            Tasks.Remove(taskId);
        }
    }

    public int ExecTop()
    {
        while (maxHeap.Count > 0)
        {
            var (priority, taskId, userId) = maxHeap.Dequeue();
            if (Tasks.ContainsKey(taskId))
            {
                var (currUserId, currPriority) = Tasks[taskId];
                if (currUserId == userId && currPriority == priority)
                {
                    Tasks.Remove(taskId);
                    return userId;
                }
            }
        }
        return -1; // No task
    }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */
