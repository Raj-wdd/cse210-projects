using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Backend Developer";
        job1._company = "Microsoft";
        job1._startYear = 2017;
        job1._endYear = 2019;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Google";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Raj Patil";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}
