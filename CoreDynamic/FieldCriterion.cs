namespace CoreDynamic
{
    public class FieldCriterion 
    {
        public FieldCriterion()
        {

        }
        public FieldCriterion(int id, string name, decimal value)
        {
            this.id = id;
            this.name = name;
            this.value = value;
        }

        public int id { get; set; }
        public string name { get; private set; }
        public decimal value { get; private set; }

        public void changeValueFieldCriterion(decimal value) 
        {
            this.value = value;
        }


    }
}
