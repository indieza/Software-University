using System;

public class King
{
    public King(string name)
    {
        this.Name = name;
    }

    public event EventHandler UnderAttack;

    public string Name { get; private set; }

    public void OnUnderAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");

        if (this.UnderAttack != null)
        {
            this.UnderAttack(this, new EventArgs());
        }
    }
}