namespace _01.Logger.Layouts.Contracts
{
   public interface ILayoutFactory
   {
       ILayout CreateLayout(string layoutType);
   }
}
