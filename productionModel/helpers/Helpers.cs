
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
                        var res2 = res[1].Split(new string[] { "{", "}" }, StringSplitOptions.None);

                        var comment = res2[1].Trim();

                        var action = res2[0].ToLower().Trim();

                        rules.Add(new Rule(new HashSet<string>(res[0].Split(',').Select(x => x.ToLower().Trim())), action.Replace("!", ""), action.Contains('!'), comment));

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


        public class Node
        {
            Rule rule;
            List<Node> steps;

            public Rule Rule
            {
                get { return rule; }
                set { rule = value; }
            }

            public List<Node> Steps
            {
                get { return steps; }
            }

            public Node(Rule rule, List<Node> steps)
            {
                this.rule = rule;
                this.steps = steps;
            }

            public Node(string fact, List<Node> steps)
            {
                var prereqs = steps.ConvertAll(x => x.rule.Action);
                rule = new Rule(new HashSet<string>(prereqs), fact);
                this.steps = steps;
            }


            public Node(string fact)
            {
                rule = new Rule(new HashSet<string> { fact }, fact);
            }

            public override string ToString()
            {
                var res = "";

                if (Steps == null)
                {
                    res = rule.Action;
                }
                else
                {
                    foreach (var proof in Steps)
                    {
                        res += proof.Rule.Action;
                        if (proof != Steps.Last())
                            res += ",";
                    }
                    res += " ­-> " + rule.Action;
                }
                return res;
            }
        }

        public class SubTree
        {
            public string prove { get; set; }
            public int stage { get; set; }

            public int nodeNum { get; set; }    //or
            public int factNum { get; set; }    //and
            public List<Node> buffer { get; set; }
            public List<string> path { get; set; }

            public SubTree(string prove, List<Node> nodes, List<string> path, int stage = 0, int nodeNum = 0, int factNum = 0)
            {
                this.prove = prove;
                buffer = nodes;
                this.stage = stage;
                this.nodeNum = nodeNum;
                this.factNum = factNum;
                this.path = path;
            }
            public SubTree(string prove, List<Node> nodes, int stage = 0, int nodeNum = 0, int factNum = 0)
            {
                this.prove = prove;
                buffer = nodes;
                this.stage = stage;
                this.nodeNum = nodeNum;
                this.factNum = factNum;
                path = new List<string>();
            }

            public SubTree(string prove, int stage = 0, int nodeNum = 0, int factNum = 0)
            {
                this.prove = prove;
                buffer = new List<Node>();
                this.stage = stage;
                this.nodeNum = nodeNum;
                this.factNum = factNum;
                path = new List<string>();
            }
        }

        public static Node unsolvable = new Node("unsolvable");

        public static Node BackwardOutput(string toProve, HashSet<string> facts, HashSet<Rule> rules)
        {
            Node solution = null;
            var subTrees = new Stack<SubTree>();
            subTrees.Push(new SubTree(toProve));


            while (subTrees.Count != 0)
            {
                var currST = subTrees.Pop();

                if (currST.stage == 0)
                {
                    if (facts.Contains(currST.prove))
                    {
                        solution = new Node(currST.prove);
                        continue;
                    }
                    var possibleRules = rules.Where(x => x.Action == currST.prove).ToList();
                    if (possibleRules.Count == 0)
                    {
                        solution = unsolvable;
                        continue;
                    }
                    else
                    {
                        subTrees.Push(new SubTree(currST.prove, new List<Node>(), currST.path, 1));
                        continue;
                    }
                }
                else if (currST.stage == 1)
                {
                    var possibleRules = rules.Where(x => x.Action == currST.prove).ToList();
                    
                    if (currST.path.Contains(currST.prove))
                    {
                        solution = unsolvable;
                        continue;
                    }
                    if (possibleRules.Count <= currST.nodeNum)
                    {
                        continue;
                    }
                    if (solution != null && solution != unsolvable && !currST.buffer.Contains(solution))
                    {
                        currST.buffer.Add(solution);
                        solution = null;
                    }
                    if (possibleRules[currST.nodeNum].Conditions.Count == currST.factNum)
                    {
                        if (currST.buffer.Count != 0 && solution != unsolvable)
                            solution = new Node(currST.prove, currST.buffer);
                        else if (possibleRules.Count - 1 > currST.nodeNum)
                        {
                            solution = null;
                            subTrees.Push(new SubTree(currST.prove, 1, currST.nodeNum + 1, 0));
                        }
                        continue;
                    }
                    if (solution == unsolvable)
                    {
                        continue;
                    }
                    else
                    {
                        var t = currST.path.ToList();
                        t.Add(currST.prove);
                        subTrees.Push(new SubTree(currST.prove, currST.buffer, currST.path, 1, currST.nodeNum, currST.factNum + 1));
                        subTrees.Push(new SubTree(possibleRules[currST.nodeNum].Conditions.ToList()[currST.factNum], currST.buffer, t, 0));
                        continue;
                    }
                }
            }
            if (solution == unsolvable)
                solution = null;
            return solution;
        }
    }
}
