using System.Collections.Generic;

namespace CoreDynamic
{
    public class VariableExpression 
    {
        public VariableExpression()
        {

        }
        public VariableExpression(string value, List<FieldCriterion> fieldCriterion)
        {
            this.value = value;
            this.fieldCriterion = fieldCriterion;
        }

        public string value { get; private set; }
        private List<FieldCriterion> fieldCriterion { get; set; }

        public List<FieldCriterion> getFieldsCriterion() 
        {
            return fieldCriterion;
        }
    }
}
