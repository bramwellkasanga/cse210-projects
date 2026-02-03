using System;

// Derived class for writing assignments
public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor that calls the base class constructor
    public WritingAssignment(string studentName, string topic, string title) 
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Using GetStudentName() method from base class to access the student name
        return _title + " by " + GetStudentName();
    }
}
