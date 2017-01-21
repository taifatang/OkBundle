namespace OkBundle
{
    public class OkResult
    {
        public bool Predicate { get; private set; }

        public OkResult(bool predicate)
        {
            Predicate = predicate;
        }
        public static OkResult Create(bool predicate)
        {
            return new OkResult(predicate);
        }
    }
    public class OkSwitchResult
    {
        public bool SwitchItem { get; private set; }

        public OkSwitchResult(bool switchItem)
        {
            SwitchItem = switchItem;
        }
        public static OkResult Create(bool switchItem)
        {
            return new OkSwitchResult(switchItem);
        }
    }
}