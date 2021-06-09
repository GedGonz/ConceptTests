namespace CoreDynamic
{
    public class FieldCriterion 
    {
        public FieldCriterion()
        {

        }
        public FieldCriterion( string name)
        {
            this.name = name;
        }

        public string name { get; private set; }
        public decimal value { get; private set; }

        public void changeValueFieldCriterion(decimal value) 
        {
            this.value = value;
        }


    }
}
