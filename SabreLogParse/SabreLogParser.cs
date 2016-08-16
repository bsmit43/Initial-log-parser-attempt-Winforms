using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

namespace SabreLogParse
{
    public partial class SabreLogParser : Form
    {
        public SabreLogParser()
        {
            InitializeComponent();
        }

        private void SabreLogParse_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Textbox cannot be empty.");
                }
                else
                {
                    try
                    {
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();
                        string fileName = textBox1.Text;
                        this.dataGridView1.DataSource = null;
                        this.dataGridView1.Rows.Clear();
                        this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                        this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                            
                        int i = 0;
                        textBox4.Clear();

                        var lines = File.ReadLines(fileName);
                        Regex Find = new Regex(textBox2.Text);
                                               
                        progressBar1.Minimum = 0;
                        label5.Text = "Searching...";

                        foreach (string fi in lines)
                        {
                        Match m = Find.Match(fi);                                                   
                            if (m.Success)
                            {
                                
                                progressBar1.Value = i++;
                                dataGridView1.ColumnCount = 3;
                                dataGridView1.Columns[0].Name = "Index";                                                            
                                dataGridView1.Columns[1].Name = "MachineName";                              
                                dataGridView1.Columns[2].Name = "Info";                                
                                this.dataGridView1.Rows.Add("",fi );
                                //dataGridView1.Rows.Add(row2);

                            }
                        }
                        //progress bar done.
                        progressBar1.Value = progressBar1.Maximum;

                        //label text changed to done
                        label5.Text = "Done.";
                        //count the number of rows
                        int noOfRows = dataGridView1.RowCount;
                        textBox4.Text = noOfRows.ToString();
                        //stop the timer
                        stopWatch.Stop();
                        //find out how much time elapsed
                        TimeSpan ts = stopWatch.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);

                        textBox5.Text = elapsedTime;
                        //this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        DataGridView gridView = sender as DataGridView;
                        if (null != gridView)
                        {
                            foreach (DataGridViewRow r in dataGridView1.Rows)
                            {
                                dataGridView1.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBox1.Text = openFileDialog1.FileName;   // <-- For debugging use.
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
    
