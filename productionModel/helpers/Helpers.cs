
namespace productionModel
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using Rule = ProductionModel.Rule;

    static public partial class Helpers
        {
            static public Tuple<HashSet<string>, HashSet<Rule>> Parse(string fileName)
            {
                var facts = new HashSet<string>();
                var rules = new HashSet<Rule>();

                var Reader = File.OpenText(fileName);
                string line;
                while ((line = Reader.ReadLine()) != null && line != "#")
                {
                    if (line != "")
                        facts.Add(line.ToLower().Trim());
                }


                while ((line = Reader.ReadLine()) != null)
                {
                    if (!line.Equals(""))
                    {
                            var res = line.Split(new string[] { "=>" }, StringSplitOptions.None);
                            if (res.Count() == 2)
                            {
                            var res2 = res[1].Split(new string[] { "{","}" }, StringSplitOptions.None);

                            var comment = res2[1].Trim();
                            
                            var action = res2[0].ToLower().Trim();
                            
                            rules.Add(new Rule(new HashSet<string>(res[0].Split(',').Select(x => x.ToLower().Trim())), action.Replace("!",""), action.Contains('!'), comment));

                            }
                        
                    }
                }

                return new Tuple<HashSet<string>, HashSet<Rule>>(facts, rules);
            }

            public static HashSet<Rule> DirectOutput(HashSet<string> facts, HashSet<Rule> rules)
            {
                var res = new HashSet<Rule>();
                foreach (var rule in rules)
                {
                    if (!rule.Reviewed && rule.Conditions.All(x => facts.Contains(x)))
                    {
                        res.Add(rule);
                        rule.Reviewed = true;
                    }
                }
                return res;
            }
        }
}
