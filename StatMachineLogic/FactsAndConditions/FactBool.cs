
namespace StatsPlus
{
    public class FactBool : Fact
    {
        public bool value;

        public FactBool(string Identifier, bool value) : base(Identifier) {
            this.value = value;
        }

        public FactBool SetValue(bool value) {
            this.value = value;
            return this;
        }

        public bool IsTrue() {
            return value;
        }

        /// <summary>
        /// inverts the current boolean value
        /// </summary>
        public FactBool Flip() {
            value = !value;
            return this;
        }

        public override object getValueAsObject()
        {
            return value;
        }
    }
}
