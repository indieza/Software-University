using System.Collections.Generic;

internal class PrimitiveCalculator
{
    private IStrategy strategy;
    private IDictionary<char, IStrategy> strategies;

    public PrimitiveCalculator(IStrategy strategy, IDictionary<char, IStrategy> strategies)
    {
        this.strategy = strategy;
        this.strategies = strategies;
    }

    public void ChangeStrategy(char @operator)
    {
        this.strategy = this.strategies[@operator];
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}