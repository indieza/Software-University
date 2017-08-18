using System;

public abstract class Soldier
{
    public Soldier(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public abstract void KingUnderAttack(object sender, EventArgs e);
}