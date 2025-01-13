using System;

class Program
{
    static void Main(string[] args)
    {
        // step 4 and 7
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer ";
        job1._endYear = 2022;
        job1._startYear = 2019;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2023;

        /// step 7
        Resume myresume = new Resume();
        myresume._name = "Allison Rose";
        myresume._jobs.Add(job1);
        myresume._jobs.Add(job2);

        myresume.ShowResumeDetails();
    }
}