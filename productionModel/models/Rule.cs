using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionModel
{
    public class Rule
    {
        public HashSet<string> Conditions { get; }
        public string Action { get; }
        public string Comment { get; }
        public bool Reviewed { get; set; }
        public bool IsSolution { get; set; }


        public Rule(HashSet<string> conditions, string action,  bool isSolution = false, string comment = "")
        {
            Conditions = conditions;
            Action = action;
            Comment = comment;
            IsSolution = isSolution;
            Reviewed = false;
        }

        public override string ToString()
        {
            string res = "";

            foreach (var i in Conditions)
            {
                res += i;
                if (i != Conditions.Last())
                    res += ",";
            }

            res += " -> " + Action;
            return res;
        }

        public override bool Equals(object obj)
        {


            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var Rule = (Rule)obj;
            return Rule.Conditions.SetEquals(this.Conditions) && Rule.Action.Equals(this.Action);
        }

        public override int GetHashCode()
        {
            var res = 1;
            foreach (var i in Conditions)
                res *= i.GetHashCode();
            return res * Action.GetHashCode();
        }
    }
}