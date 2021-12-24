using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace productionModel
{
    public partial class MainForm : Form
    {
        Tuple<HashSet<string>, HashSet<ProductionModel.Rule>> data;
        public MainForm()
        {
            InitializeComponent();
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\data\db.txt");
            string sFilePath = Path.GetFullPath(sFile);
            data = Helpers.Parse(sFilePath);
            RefreshRules();
            FillFacts();
        }

        private void RefreshRules()
        {
            foreach (var rule in data.Item2)
            {
                rule.Reviewed = false;
            }
        }

        private void FillFacts()
        {
            foreach (var fact in data.Item1)
            {
                checkedFactsBox.Items.Add(fact);
            }
        }

        public List<string> Difference(List<string> lst1, List<string> lst2)
        {
            List<string> resultSet = new List<string>();
            foreach (var elem in lst1)
            {
                if (!lst2.Contains(elem))
                    resultSet.Add(elem);
            }
            return resultSet;
        }

        private void directOutputButton_Click(object sender, EventArgs e)
        {
            RefreshRules();
            outputBox.Text = "";
            var selectedFacts = checkedFactsBox.CheckedItems.Cast<string>().ToHashSet();
            var newFacts = dFactsBox.CheckedItems.Cast<string>().ToHashSet();
            selectedFacts = selectedFacts.Union(newFacts).ToHashSet();
            int step = 1;
            outputTextBox.Text += "Прямой вывод\n";
            outputTextBox.Text += "Выбранные факты:\n";
            int factNum = 1;
            foreach (var fact in selectedFacts)
            {
                outputTextBox.Text += $"{factNum}:  {fact}\n";
                factNum++;
            }
            outputTextBox.Text += '\n';
            bool check = true;
            while (check)
            {
                check = false;

                foreach (var rule in Helpers.DirectOutput(selectedFacts, data.Item2))
                {
                    selectedFacts.Add(rule.Action);
                    outputTextBox.Text += $"\nШаг # {step}\n";
                    outputTextBox.Text += "--------------------------------\n";
                    outputTextBox.Text += $"Комментарий: {rule.Comment}\n";
                    outputTextBox.Text += $"Применяемое правило: {rule}\n";
                    outputTextBox.Text += $"Полученный факт: {rule.Action}\n";
                    check = true;
                    if (rule.IsSolution)
                    {
                        solutionTextBox.Text += "--------------------------------\n";
                        solutionTextBox.Text += $"Комментарий: {rule.Comment}\n";
                        solutionTextBox.Text += $"Применяемое правило: {rule}\n";
                        solutionTextBox.Text += $"Полученный результат: {rule.Action}\n";
                    }
                }
                step++;
            }
            var sel = checkedFactsBox.CheckedItems.Cast<string>().ToHashSet();
            var res = Difference(selectedFacts.ToList(), sel.ToList());
            outputTextBox.Text += "--------------------------------------------------------------\n";
            outputTextBox.Text += "Полученные факты:\n";
            factNum = 1;
            foreach (var fact in res)
            {
                if (!dFactsBox.Items.Contains(fact))
                {
                    dFactsBox.Items.Add(fact);
                    dFactsBox.SetItemChecked(dFactsBox.Items.IndexOf(fact), true);
                    outputTextBox.Text += $"{factNum}:  {fact}\n";
                    factNum++;
                }
            }
            dFactsBox.Visible = true;
        }

        private void clearTextBoxButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = "";
            solutionTextBox.Text = "";
        }

        private void getPath(Helpers.Node solution, HashSet<string> evlRules)
        {
            if (solution != null && solution.Proves != null)
            {
                if (!evlRules.Contains(solution.Rule.ToString()))
                    evlRules.Add(solution.Rule.ToString());
                foreach (var prove in solution.Proves)
                {

                    if (!evlRules.Contains(prove.ToString()) && prove.Proves != null)
                    {
                        evlRules.Add(prove.ToString());

                    }
                }
                foreach (var p in solution.Proves)
                    getPath(p, evlRules);
            }

        }

        private void backwardOutputButton_Click(object sender, EventArgs e)
        {
            RefreshRules();
            outputTextBox.Text = "";
            var selecteddFacts = dFactsBox.CheckedItems.Cast<string>().ToHashSet();
            var selectedFacts = checkedFactsBox.CheckedItems.Cast<string>().ToHashSet();
            outputTextBox.Text += "Обратный поиск\n";
            outputTextBox.Text += "Выбранные факты:\n";
            int factNum = 1;
            foreach (var fact in selecteddFacts)
            {
                outputTextBox.Text += $"{factNum}:  {fact}\n";
                factNum++;
            }
            outputTextBox.Text += '\n';
            var solution = Helpers.Prove(selecteddFacts.First(), selectedFacts, data.Item2);
            if (solution == null)
            {
                outputTextBox.Text += "--------------------------------------------------------------\n";
                outputTextBox.Text += "Правило невыводимо\n";
                outputTextBox.Text += "--------------------------------------------------------------\n";

            }
            else
            {
                HashSet<string> evlRules = new HashSet<string>();
                getPath(solution, evlRules);
                var rul = evlRules.ToList();
                for (int i = 0; i < rul.Count; i++)
                {
                    outputTextBox.Text += $"\nШаг # {i + 1}\n";
                    outputTextBox.Text += "--------------------------------------------------------------\n";
                    outputTextBox.Text += $"Полученное правило: {rul[i]}\n";
                    outputTextBox.Text += "--------------------------------------------------------------\n";
                }
            }
        }
    }
}
