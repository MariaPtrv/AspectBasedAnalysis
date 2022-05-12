namespace AspectBasedAnalysis
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      AspectsCheckedListBox.Items.Add("врач", false);
      AspectsCheckedListBox.Items.Add("стоимость", false);
      AspectsCheckedListBox.Items.Add("качество", false);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var path = String.Empty;
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        path = openFileDialog1.FileName;
        textBox3.Text = path;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (newAspectTextBox.Text.Length != 0
        && !AspectsCheckedListBox.Items.Contains(newAspectTextBox.Text)
        && !AspectsCheckedListBox.Items.Contains(newAspectTextBox.Text.ToLower()))
      {
        AspectsCheckedListBox.Items.Add(newAspectTextBox.Text.ToLower(), true);
        newAspectTextBox.Text = String.Empty;
      }
      else
        MessageBox.Show("Такой аспект уже добавлен", "Error",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}