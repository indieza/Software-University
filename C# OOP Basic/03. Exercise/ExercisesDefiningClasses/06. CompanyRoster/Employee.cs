public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string department, string email, int age)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email) : this(name, salary, position, department, email, -1)
    {
    }

    public Employee(string name, decimal salary, string position, string department, int age) : this(name, salary, position, department, "n/a", age)
    {
    }

    public Employee(string name, decimal salary, string position, string department) : this(name, salary, position, department, "n/a", -1)
    {
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public string Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.salary:F2} {this.email} {this.age}";
    }
}