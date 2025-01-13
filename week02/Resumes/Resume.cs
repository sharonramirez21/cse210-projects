// step 6
public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();


    // step 8
    public void ShowResumeDetails()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.ShowJobDetails();
        }
    }
}