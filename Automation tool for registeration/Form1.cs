
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using static System.Windows.Forms.LinkLabel;

namespace Automation_tool_for_registeration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }



       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Select a Text File";

            // Show the dialog and check if user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Read the contents of the selected file

                    string[] fileContent = File.ReadAllLines(openFileDialog.FileName);

                    NumberBox.Items.Clear();


                    foreach (var line in fileContent)
                    {




                        string trimmedLine = line.Trim();
                        if (!string.IsNullOrEmpty(trimmedLine))
                        {
                            // Try to parse the number (use long for larger numbers)
                            if (long.TryParse(trimmedLine, out long number))
                            {
                                // Add the valid number to the ListView
                                ListViewItem item = new ListViewItem(number.ToString());
                                
                                NumberBox.Items.Add(item);
                                
                            }
                        }

                        


                    }

                    ProcessStartInfo psInfo = new ProcessStartInfo
                    {
                        FileName = "https://web.telegram.org/k",
                        UseShellExecute = true
                    };
                    Process.Start(psInfo);






                }
                catch (Exception ex)
                {
                    // Handle potential errors (e.g., file access errors)
                    MessageBox.Show("An error occurred while reading the file: " + ex.Message);
                }
            }
        }

        private void NumberBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

