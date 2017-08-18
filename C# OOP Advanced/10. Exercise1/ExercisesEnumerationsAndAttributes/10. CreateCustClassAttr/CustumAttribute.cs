using System;

public class CustumAttribute : Attribute
{
    public CustumAttribute(string author, int revision, string description, string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = reviewers;
    }

    public string Author { get; set; }

    public int Revision { get; set; }

    public string Description { get; set; }

    public string[] Reviewers { get; set; }
}