// Inheritance -- son class
class WritingAssignment : Assignment
{
    private string _title;


    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"Title: {_title}, writen by: {_studentName}";
    }
}