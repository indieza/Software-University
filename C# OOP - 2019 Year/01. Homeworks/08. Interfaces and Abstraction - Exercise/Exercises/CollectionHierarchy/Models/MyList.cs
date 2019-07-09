namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public override string Remove()
        {
            string item = base.Data[0];
            base.Data.RemoveAt(0);
            return item;
        }

        public string Used()
        {
            return string.Join(" ", base.Data);
        }
    }
}