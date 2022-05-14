using System.Text.RegularExpressions;
namespace AspectBasedAnalysis
{
  public partial class Form1 : Form
  {
    public enum sourseType
    {
      File,
      Link,
      None
    }
    public class analysisSettings
    {
      public string Sourse { get; set; }
      public sourseType SourseType { get; set; }
      public List<string> Aspects { get; set; }

      public analysisSettings()
      {
        Sourse = "";
        SourseType = sourseType.None;
        Aspects = new List<string>();
      }
    }
    public Form1()
    {
      InitializeComponent();
      AspectsCheckedListBox.Items.Add("врач", false);
      AspectsCheckedListBox.Items.Add("стоимость", false);
      AspectsCheckedListBox.Items.Add("качество", false);
      ResultDataGridView.Visible = false;
      RenderButton.Visible = false;
      StatisticsGroupBox.Visible = false;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var path = String.Empty;
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        reviewSourseTextBox.Text = openFileDialog1.FileName;
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

    private bool isReviewLink(string s)
    {
      Regex regex = new Regex(@"^https://otzovik.com/reviews/\w+/$");
      MatchCollection matches = regex.Matches(s);
      return matches.Count > 0 ? true : false; 
    }

    private void AnalysisButton_Click(object sender, EventArgs e)
    {
      var settings = new analysisSettings();
      var hasSourse = false;

      if (reviewSourseTextBox.Text.Length > 0)
      {
        if (File.Exists(reviewSourseTextBox.Text))
        {
          SourseTypeLabel.Text = Path.GetExtension(reviewSourseTextBox.Text) + " файл";
          settings.SourseType = sourseType.File;
          hasSourse = true;
        }
        else if (isReviewLink(reviewSourseTextBox.Text))
        {
          SourseTypeLabel.Text = "otzovik.com";
          settings.SourseType = sourseType.File;
          hasSourse = true;
        }
        else MessageBox.Show("Укажите источник отзывов", "Error",
         MessageBoxButtons.OK, MessageBoxIcon.Error);
      } 

      if (AspectsCheckedListBox.CheckedItems.Count > 0 && hasSourse)
      {
        NoResultLabel.Visible = false;
        //стянуть настройки
        //запустить питон код
        //предоставить результат

      }
      else MessageBox.Show("Для выполнения анализа необходимо указать: \n- Источник отзывов\n- Перечень анализируемых аспектов", 
                            "Невозможно выполнить анализ",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

    }

    private void RenderButton_Click(object sender, EventArgs e)
    {

    }

    private void reviewSourseTextBox_TextChanged(object sender, EventArgs e)
    {
      if (File.Exists(reviewSourseTextBox.Text))
        SourseTypeLabel.Text = Path.GetExtension(reviewSourseTextBox.Text) + " файл";
      else if (isReviewLink(reviewSourseTextBox.Text))
        SourseTypeLabel.Text = "otzovik.com";
      else SourseTypeLabel.Text = "не определено";
    }
  }
}