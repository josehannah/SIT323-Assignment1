using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1SIT323
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void validateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                String TAFFfilename = openFileDialog.FileName;

                Configuration configuration = new Configuration();
                TaskAllocation taskAllocation = new TaskAllocation();

                if (taskAllocation.GetCffFilename(TAFFfilename))
                {
                    if (taskAllocation.Validate(TAFFfilename) && configuration.Validate(taskAllocation.CffFilename))
                    {
                        Console.WriteLine("The LogFile: " + configuration.LogFileName);

                        MessageBox.Show(configuration.LogFileName);

                        // Enabling the Allocation menu
                        allocationToolStripMenuItem.Enabled = true;
                    }
                }

            }
        }

        private void allocationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
