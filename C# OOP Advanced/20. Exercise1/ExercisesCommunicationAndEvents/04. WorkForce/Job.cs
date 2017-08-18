using System;

public class Job
{
    public Job(string name, int workHoursRequired, BaseEmploee emploee)
    {
        this.Name = name;
        this.WorkHoursRequired = workHoursRequired;
        this.Emploee = emploee;
        this.IsDone = false;
    }

    public event StartUp.JobDoneEventHandler JobDone;

    public string Name { get; private set; }

    public int WorkHoursRequired { get; private set; }

    public BaseEmploee Emploee { get; private set; }

    public bool IsDone { get; private set; }

    public void Update()
    {
        this.WorkHoursRequired -= this.Emploee.WorkHoursPerWeek;
        if (this.WorkHoursRequired <= 0 && !this.IsDone)
        {
            this.JobDone?.Invoke(this, new JobEventArgs(this));
        }
    }

    public void OnJobDone(object sebder, JobEventArgs e)
    {
        Console.WriteLine($"Job {this.Name} done!");
        this.IsDone = true;
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
    }
}