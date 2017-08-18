using System;
using System.Text;

public class Worker : Human
{
    private double weeklySalary;
    private double workingHours;

    public Worker(string firstName, string lastName, double weeklySalary, double workingHours) : base(firstName, lastName)
    {
        this.WeeklySalary = weeklySalary;
        this.WorkingHours = workingHours;
    }

    public double WeeklySalary
    {
        get { return this.weeklySalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weeklySalary = value;
        }
    }

    public double WorkingHours
    {
        get { return this.workingHours; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workingHours = value;
        }
    }

    private double SalaryPerHour
    {
        get
        {
            double result = this.weeklySalary / (this.workingHours * 5);
            return result;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"First Name: {base.FirstName}");
        stringBuilder.AppendLine($"Last Name: {this.LastName}");
        stringBuilder.AppendLine($"Week Salary: {this.weeklySalary:F2}");
        stringBuilder.AppendLine($"Hours per day: {this.workingHours:F2}");
        stringBuilder.AppendLine($"Salary per hour: {this.SalaryPerHour:F2}");

        return stringBuilder.ToString();
    }
}