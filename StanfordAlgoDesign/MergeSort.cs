using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanfordAlgoDesign
{
    class MergeSort
    {
        Form1 form;
        RichTextBox outputBox;

        public MergeSort(Form1 form)
        {
            this.form = form;
            outputBox = form.outputBox;
            outputBox.AppendText("Enter input...");
        }

        internal enum MessageTypes { Default, Error, Alert, Complete };

        internal void displayMessage(string message, MessageTypes type = MessageTypes.Default)
        {
            int oldText = outputBox.TextLength;
            outputBox.AppendText("\n" + message);

            if (type != MessageTypes.Default)
            {
                outputBox.SelectionStart = oldText;
                outputBox.SelectionLength = message.Length;
            }

            switch (type)
            {
                case MessageTypes.Error:
                    outputBox.SelectionColor = Color.Red;
                    break;
                case MessageTypes.Alert:
                    outputBox.SelectionColor = Color.Blue;
                    break;
                case MessageTypes.Complete:
                    outputBox.SelectionColor = Color.Green;
                    break;
                default:
                    break;
            }
        }

        public void run(String input)
        {
            List<int> intArray = extractIntArray(input);
            List<int> sortedArray = mergeSortAlgo(intArray);

            string displayArray = formatArrayForOutput(sortedArray);
            displayMessage(displayArray);
        }

        private string formatArrayForOutput(List<int> intArray)
        {
            string returnStr = "";
            foreach (int num in intArray)
            {
                if (returnStr == "")
                {
                    returnStr += num;
                }
                else
                {
                    returnStr += ", " + num;
                }
            }

            return returnStr;
        }

        private List<int> extractIntArray(string input)
        {
            try
            {

                string[] stringArray = input.Split(' ');
                List<int> intArray = new List<int>();
                foreach (string str in stringArray)
                {
                    intArray.Add(int.Parse(str));
                }
                return intArray;
            }
            catch (Exception e)
            {
                displayMessage(e.ToString(), MessageTypes.Error);
                return new List<int>();
            }
        }

        private List<int> mergeSortAlgo(List<int> m)
        {
            // Base case
            if (m.Count <= 1)
            {
                return m;
            }

            // Recursive case
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int middle = m.Count / 2;

            for (int i = m.Count - 1; i >= middle; i--)
            {
                right.Add(m[i]);
                m.Remove(m[i]);
            }
            left = m;

            // Recursively sort sublists
            left = mergeSortAlgo(left);
            right = mergeSortAlgo(right);

            // Merge the sorted sublists
            return merge(left, right);

        }

        private List<int> merge(List<int> left, List<int> right)
        {
            List<int> sorted = new List<int>();
            int n = left.Count + right.Count - 1;
            int i = 0;
            int j = 0;
            for (int k = 0; k <= n; k++)
            {
                if (i > left.Count - 1)
                {
                    sorted.Add(right[j]);
                }
                else if (j > right.Count - 1)
                {
                    sorted.Add(left[i]);
                }
                else
                {
                    if (left[i] < right[j])
                    {
                        sorted.Add(left[i]);
                        i++;
                    }
                    else
                    {
                        sorted.Add(right[j]);
                        j++;
                    }
                }
            }

            return sorted;
        }
    }
}
