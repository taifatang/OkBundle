namespace OkBundle.Results
{
    public class If : Result
    {
        public bool Predicate { get; set; }

        public If(bool predicate)
        {
            Predicate = predicate;
        }
    }
}