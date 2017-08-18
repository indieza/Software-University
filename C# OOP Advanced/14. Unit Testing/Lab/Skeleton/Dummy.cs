using System;

public class Dummy
{
    private int health;
    private int experience;

    public Dummy(int health, int experience)
    {
        this.Health = health;
        this.Experience = experience;
    }

    public int Health
    {
        get { return this.health; }
        set { this.health = value; }
    }

    public int Experience
    {
        get { return this.experience; }
        set { this.experience = value; }
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.experience;
    }

    public bool IsDead()
    {
        return this.health <= 0;
    }
}