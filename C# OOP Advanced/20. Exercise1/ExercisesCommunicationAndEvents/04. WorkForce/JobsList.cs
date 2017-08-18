using System.Collections.Generic;

public class JobsList : List<Job>
{
    public void OnJobDone(object sender, JobEventArgs e)
    {
        this.Remove(e.Job);
    }
}