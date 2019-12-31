using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using RepeatSystem.Classes;

namespace TestProject
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            //dTPicker.Value = new DateTime(2013, 2, 28);
            dTPicker.Value = new DateTime(2013, 5, 31);
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            DateTime date = dTPicker.Value.Date;

            date = date.AddDays(1);

            dTPicker.Value = date;

            CreateMemoryDatesText(date);
        }

        private void btnPreviousDate_Click(object sender, EventArgs e)
        {
            DateTime date = dTPicker.Value.Date;

            date = date.AddDays(-1);

            dTPicker.Value = date;

            CreateMemoryDatesText(date);
        }

        private void btnCreateMemoryDates_Click(object sender, EventArgs e)
        {
            DateTime date = dTPicker.Value.Date;

            CreateMemoryDatesText(date);
        }

        private void CreateMemoryDatesText(DateTime date)
        {
            Collection<RepetitionDate> memoryDates = RepetitionDate.GenerateMemoryDates(date);

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine(date.ToShortDateString());
            strBuilder.AppendLine();

            int number = (int)memoryDates[0].RepetitionType.Number;

            foreach (RepetitionDate memDate in memoryDates)
            {
                if (number != memDate.RepetitionType.Number)
                {
                    number = memDate.RepetitionType.Number;
                    strBuilder.AppendLine();
                }

                strBuilder.AppendLine(memDate.ToString());
            }

            textBox1.Text = strBuilder.ToString();
        }

        private void btnCheckAllDates_Click(object sender, EventArgs e)
        {
            DateTime firstDate = new DateTime(2011, 1, 1);
            DateTime finalDate = new DateTime(2014, 12, 31);

            Hashtable coveredDates = new Hashtable();

            while (firstDate <= finalDate)
            {
                Collection<RepetitionDate> memoDates = RepetitionDate.GenerateMemoryDates(firstDate);

                foreach (RepetitionDate item in memoDates)
                {
                    for (DateTime dateStart = item.DateBegin; dateStart <= item.DateEnd; dateStart = dateStart.AddDays(1))
                    {
                        Collection<int> numbers = null;

                        if (coveredDates.Contains(dateStart))
                        {
                            numbers = (Collection<int>)coveredDates[dateStart];
                        }
                        else
                        {
                            numbers = new Collection<int>();
                            coveredDates.Add(dateStart, numbers);
                        }

                        if (!numbers.Contains(item.RepetitionType.Number))
                        {
                            numbers.Add(item.RepetitionType.Number);    
                        }
                    }
                }

                firstDate = firstDate.AddDays(1);
            }


            ArrayList result = new ArrayList();

            firstDate = new DateTime(2012, 1, 1);
            finalDate = new DateTime(2012, 12, 31);

            while (firstDate <= finalDate)
            {
                bool add = true;

                if (coveredDates.Contains(firstDate))
                {
                    add = false;

                    Collection<int> numbers = (Collection<int>)coveredDates[firstDate];

                    for (int ind = 1; ind < 8; ind++)
                    {
                        if (!numbers.Contains(ind))
                        {
                            add = true;
                        }
                    }
                }

                if (add)
                {
                    result.Add(firstDate);
                }

                firstDate = firstDate.AddDays(1);
            }

            result.Sort();

            StringBuilder strBuilder = new StringBuilder();

            foreach (DateTime item in result)
            {
                strBuilder.Append(item.ToShortDateString());

                if (coveredDates.Contains(item))
                {
                    Collection<int> numbers = (Collection<int>)coveredDates[item];

                    strBuilder.Append(" -");

                    for (int ind = 1; ind < 8; ind++)
                    {
                        if (!numbers.Contains(ind))
                        {
                            strBuilder.AppendFormat(" {0}", ind.ToString());
                        }
                    }
                }

                strBuilder.AppendLine();
            }


            textBox1.Text = strBuilder.ToString();

            MessageBox.Show("Готово!");
        }
    }
}
