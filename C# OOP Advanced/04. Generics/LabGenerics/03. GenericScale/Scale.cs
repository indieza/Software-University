using System;

public class Scale<T> where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T Left
    {
        get { return this.left; }
        set { this.left = value; }
    }

    public T Right
    {
        get { return this.right; }
        set { this.right = value; }
    }

    public T GetHavier()
    {
        int result = this.Left.CompareTo(this.Right);

        if (result == 0)
        {
            return default(T);
        }

        return result > 0 ? this.Left : this.Right;
    }
}