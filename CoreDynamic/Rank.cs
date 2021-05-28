namespace CoreDynamic
{
    public class Rank {
        public Rank()
        {

        }
        public Rank(int id, Operator Operator, decimal valueRank, decimal value)
        {
            this.id = id;
            this.Operator = Operator;
            this.valueRank = valueRank;
            this.value = value;
        }

        public int id { get; private set; }
        public Operator Operator { get; private set; }
        private FieldCriterion fieldCriterion { get; set; }
        public decimal valueRank { get; private set; }
        public decimal value { get; private set; }
        private TypeRank typeRank { get; set; }

        public void addFieldCriterion(FieldCriterion fieldCriterion) 
        {
            this.fieldCriterion = fieldCriterion;
        }
        public FieldCriterion getFieldCriterion() 
        {
            return fieldCriterion;
        }
        public void changeValueFieldCriterion(decimal value) 
        {
            fieldCriterion.changeValueFieldCriterion(value);
        }

        public void isPorcentage()
        {
            typeRank = TypeRank.PERCENTAGE;
        }
        public void isMonetary()
        {
            typeRank = TypeRank.MONETARY;
        }

        public TypeRank getTypeRank() 
        {
            return typeRank;
        }

    }
}
