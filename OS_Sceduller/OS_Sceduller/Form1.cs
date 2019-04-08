﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Sceduller
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> input_process = new List<int>();
        List<int> input_burst = new List<int>();
        List<int> input_priority = new List<int>();
        List<int> id = new List<int>();
        void jop_first(List<int> input_process, List<int> input_burst)
        {
            int begin = 0, end = 0, cnt;
            cnt = input_process.Count;
            List<int> no_process = new List<int>();
            for (int ii = 0; ii < cnt; ii++)
            {
                no_process.Add(ii);
            }
            int index = 0, i = 0;
            while (input_process.Count != 0)
            {

                int j = 0;
                index = 0;
                if (input_process.Count != 1)
                {
                    while (input_process[j] <= begin && input_process[j + 1] <= begin)
                    {
                        if (input_burst[j + 1] < input_burst[j])
                        {
                            index++;
                        }
                        j++;
                        if (j + 1 >= input_process.Count)
                            break;
                    }
                }
                end += input_burst[index];
                chart1.Series[0].Points.AddXY(no_process[index], begin, end);
                begin = end;
                input_process.RemoveAt(index);
                input_burst.RemoveAt(index);
                no_process.RemoveAt(index);
                i++;
            }
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_process_Click(object sender, EventArgs e)
        {
            input_process.Add(Convert.ToInt32(arriv.Text));
            input_burst.Add(Convert.ToInt32(burst.Text));
            input_priority.Add(Convert.ToInt32(priority.Text));
            arriv.Clear();
            burst.Clear();
            priority.Clear();
            id.Clear();
        }

        private void FCFS_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            int begin = 0, end = 0;
            for (int i = 0; i < input_process.Count; i++)
            {
                end += input_burst[i];
                chart1.Series[0].Points.AddXY(i, begin, end);
                begin = end;
            }
        }

        private void SJF_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            
            List<int> copy_process = new List<int>(input_process);
            List<int> copy_burst = new List<int>(input_burst);
            jop_first(copy_process, copy_burst);
           
        }

       

        

    }
}
