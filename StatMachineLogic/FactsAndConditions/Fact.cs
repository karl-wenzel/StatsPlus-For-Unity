
namespace StatsPlus
{
    public abstract class Fact : Named
    {
        public Fact(string Identifier) : base(Identifier)
        {
        }

        public abstract object getValueAsObject();
    }
}
