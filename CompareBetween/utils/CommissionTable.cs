using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareBetween
{
    public enum TYPETABE_COMMISION 
    {
        REGIONAL_MANAGER,
        PRODUCT_MANAGER,
        ADVISER

    }

    public enum TYPRANGE
    {
        MONEY,
        PERCENTAGE

    }
    public class CommissionTable {
        public CommissionTable(int id, string name, string description, TYPETABE_COMMISION typeTable, TYPRANGE typerange, List<Ranges> ranges)
        {
            Id = id;
            Name = name;
            Description = description;
            TypeTable = typeTable;
            Typerange = typerange;
            Ranges = ranges;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public TYPETABE_COMMISION TypeTable { get; private set; }
        public TYPRANGE Typerange { get; set; }
        private List<Ranges> Ranges { get;  set; }


        public string getValueFromRanges(decimal venta) {
            return Ranges.FirstOrDefault(x => venta.IsBetween(x.rangeInit, x.rangeEnd)).value;
    }

    }

    public class Ranges
    {
        public Ranges(decimal rangeInit, decimal rangeEnd, string value)
        {
            validateRanges(rangeInit, rangeEnd);
            this.rangeInit = rangeInit;
            this.rangeEnd = rangeEnd;
            this.value = value;
        }

        public decimal rangeInit { get; private set; }
        public decimal rangeEnd { get; private set; }
        public string value { get; set; }
        

        private void validateRanges(decimal rangeInit, decimal rangeEnd) 
        {
            if (rangeInit == 0)
                throw new Exception("Initial range cannot be zero ");
            if (rangeInit < 0 || rangeEnd < 0)
                throw new Exception("Range cannot be negative");

        }
    }
}
