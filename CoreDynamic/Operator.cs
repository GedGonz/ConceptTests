namespace CoreDynamic
{
    public class Operator {
        public Operator()
        {

        }
        public Operator( string value)
        {

            this.value = value;
        }

        public string value { get; private set; }

        public override string ToString()
        {
            return value;
        }
    }

}
