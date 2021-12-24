
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
            List<Node> proves;
            //Применяемое правило
            public Rule Rule
            {
                get { return rule; }
                set { rule = value; }
            }
            //Node доказательства для всех фактов, требуемых для выполнения правила в этом ноде
            public List<Node> Proves
            {
                get { return proves; }
            }

            public Node(Rule rule, List<Node> proves)
            {
                this.rule = rule;
                this.proves = proves;
            }

            public Node(string fact, List<Node> proves)
            {
                var prereqs = proves.ConvertAll(x => x.rule.Action);
                rule = new Rule(new HashSet<string>(prereqs), fact);
                this.proves = proves;
            }


            public Node(string fact)
            {
                rule = new Rule(new HashSet<string> { fact }, fact);
            }

            public override string ToString()
            {
                var res = "";

                if (Proves == null)
                {
                    res = rule.Action;
                }
                else
                {
                    foreach (var proof in Proves)
                    {
                        res += proof.Rule.Action;
                        if (proof != Proves.Last())
                            res += ",";
                    }
                    res += " ­-> " + rule.Action;
                }
                return res;
            }
        }

        //Представление ветви дерева. Хранит данные, нужные для каждого уровня глубины и определения, на каком И/Или node мы находимся
        public class SubTree
        {
            public string prove { get; set; }
            public int stage { get; set; }

            //Номер "Или" поддерева
            public int nodeNum { get; set; }
            //Номер "И" поддерева
            public int factNum { get; set; }
            public List<Node> buffer { get; set; }

            public List<string> proofPath { get; set; }

            public SubTree(string prove, List<Node> nodes, List<string> proofPath, int stage = 0, int nodeNum = 0, int factNum = 0)
            {
                this.prove = prove;
                buffer = nodes;
                this.stage = stage;
                this.nodeNum = nodeNum;
                this.factNum = factNum;
                this.proofPath = proofPath;
            }
            public SubTree(string prove, List<Node> nodes, int stage = 0, int nodeNum = 0, int factNum = 0)
            {
                this.prove = prove;
                buffer = nodes;
                this.stage = stage;
                this.nodeNum = nodeNum;
                this.factNum = factNum;
                proofPath = new List<string>();
            }

            public SubTree(string prove, int stage = 0, int nodeNum = 0, int factNum = 0)
            {
                this.prove = prove;
                buffer = new List<Node>();
                this.stage = stage;
                this.nodeNum = nodeNum;
                this.factNum = factNum;
                proofPath = new List<string>();
            }
        }

        public static Node unsolvable = new Node("unsolvable");

        //Нерекурсивный алгоритм обратного поиска. Принимает на вход факт который нужно доказать, начальные факты, и правила.
        //Возвращает одностороннее дерево нодов, рекурсивно определяемое как Rules - применяемое правило и Proves - ноды доказательства для всех фактов, требуемых для его выполнения.
        //Возвращает null, если решение не найдено
        public static Node Prove(string prove, HashSet<string> facts, HashSet<Rule> rules)
        {
            Node solution = null;
            var branches = new Stack<SubTree>();
            branches.Push(new SubTree(prove));


            while (branches.Count != 0)
            {
                var currBranch = branches.Pop();
                //Рассчёт доказуемости каждого факта
                if (currBranch.stage == 0)
                {
                    if (facts.Contains(currBranch.prove))
                    {
                        solution = new Node(currBranch.prove);
                        continue;
                    }
                    var possibleRules = rules.Where(x => x.Action == currBranch.prove).ToList();
                    if (possibleRules.Count == 0)
                    {
                        solution = unsolvable;
                        continue;
                    }
                    else
                    {
                        branches.Push(new SubTree(currBranch.prove, new List<Node>(), currBranch.proofPath, 1));
                        continue;
                    }
                }
                //Рассмотрение структуры дерева
                else if (currBranch.stage == 1)
                {
                    var possibleRules = rules.Where(x => x.Action == currBranch.prove).ToList();
                    //Защита от зацикливания. Да, она говно. Нет, она работает.
                    if (currBranch.proofPath.Contains(currBranch.prove))
                    {
                        solution = unsolvable;
                        continue;
                    }
                    if (possibleRules.Count <= currBranch.nodeNum)
                    {
                        continue;
                    }
                    if (solution != null && solution != unsolvable && !currBranch.buffer.Contains(solution))
                    {
                        currBranch.buffer.Add(solution);
                        solution = null;
                    }
                    if (possibleRules[currBranch.nodeNum].Conditions.Count == currBranch.factNum)
                    {
                        if (currBranch.buffer.Count != 0 && solution != unsolvable)
                            solution = new Node(currBranch.prove, currBranch.buffer);
                        else if (possibleRules.Count - 1 > currBranch.nodeNum)
                        {
                            solution = null;
                            branches.Push(new SubTree(currBranch.prove, 1, currBranch.nodeNum + 1, 0));
                        }
                        continue;
                    }
                    if (solution == unsolvable)
                    {
                        continue;
                    }
                    else
                    {
                        var t = currBranch.proofPath.ToList();
                        t.Add(currBranch.prove);
                        branches.Push(new SubTree(currBranch.prove, currBranch.buffer, currBranch.proofPath, 1, currBranch.nodeNum, currBranch.factNum + 1));
                        branches.Push(new SubTree(possibleRules[currBranch.nodeNum].Conditions.ToList()[currBranch.factNum], currBranch.buffer, t, 0));
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
