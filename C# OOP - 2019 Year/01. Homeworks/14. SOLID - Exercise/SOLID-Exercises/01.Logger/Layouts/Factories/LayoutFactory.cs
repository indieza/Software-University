namespace _01.Logger.Layouts.Factories
{
    using System;
    using Contracts;

    public class LayoutFactory:ILayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            switch (layoutType.ToLower())
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
