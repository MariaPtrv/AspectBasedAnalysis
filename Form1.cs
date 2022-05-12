namespace AspectBasedAnalysis
{
  public partial class Form1 : Form
  {
    new List<string> aspectsList = new();
    public Form1()
    {
      InitializeComponent();
      aspectsList.Add("Врач");
      aspectsList.Add("Стоимость");
      aspectsList.Add("Качество");
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
      if (newAspectTextBox.Text.Length != 0 && !aspectsList.Contains(newAspectTextBox.Text))
      {
        aspectsList.Add(newAspectTextBox.Text);
        AspectsCheckedListBox_Update();
      } 
      else
      {

      }
    }

    private void AspectsCheckedListBox_Update()
    {
      var checkedAspects = new List<string>();
      foreach (var item in AspectsCheckedListBox.CheckedItems)
        checkedAspects.Add(item.ToString());

      checkedAspects.AddRange(checkedAspects);
      AspectsCheckedListBox.Items.AddRange(aspectsList.ToArray());
    }
  }
}