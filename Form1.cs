using System.Text.RegularExpressions;
using System.Reflection;
using System.Xml.Linq;

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
      AspectsCheckedListBox.Items.Add("качество", true);
      AspectsCheckedListBox.Items.Add("сервис", true);
      AspectsCheckedListBox.Items.Add("аппаратура", true);
      AspectsCheckedListBox.Items.Add("питание", true);
      AspectsCheckedListBox.Items.Add("удобство", true);
      AspectsCheckedListBox.Items.Add("размещение", true);
      AspectsCheckedListBox.Items.Add("расположение", true);
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

    private void WriteSettingsToXML(string pathToFile, List<string> aspects)
    {
      var pathToFolder =Environment.CurrentDirectory+ "\\SettingsFolder";
      bool isEnd = false;
      while (!isEnd)
      {
        if (Directory.Exists(pathToFolder))
        {
          Directory.Delete(pathToFolder, true);
        }
        else
        {
          Directory.CreateDirectory(pathToFolder);
          XDocument xdoc = new XDocument();
          XElement xsettings = new XElement("settings");
          XElement xpath = new XElement("dataPath", pathToFile);
          XElement xfolderPath = new XElement("folderPath", pathToFolder);
          xsettings.Add(xpath);
          xsettings.Add(xfolderPath);
          XElement xaspects = new XElement("aspects");
          foreach (var aspect in aspects)
          {
            XElement xaspect = new XElement("aspect", aspect);
            xaspects.Add(xaspect);
          }
          xsettings.Add(xaspects);
          xdoc.Add(xsettings);
          xdoc.Save($"{pathToFolder}\\Input.xml");
          isEnd = true;
        }
      }
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
          settings.Sourse = reviewSourseTextBox.Text;
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
        for (int x = 0; x < AspectsCheckedListBox.CheckedItems.Count; x++)
        {
          settings.Aspects.Add(AspectsCheckedListBox.CheckedItems[x].ToString());
        }
        WriteSettingsToXML(settings.Sourse, settings.Aspects);
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