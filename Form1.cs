using System.Text.RegularExpressions;
using System.Reflection;
using System.Xml.Linq;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using HtmlAgilityPack;

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
      public List<string?> Aspects { get; set; }

      public analysisSettings()
      {
        Sourse = "";
        SourseType = sourseType.None;
        Aspects = new List<string?>();
      }
    }
    public Form1()
    {
      InitializeComponent();
      ResultDataGridView.Visible = false;
    }

    private void StartPython(string pathToFile, List<string?> aspects) ///////////
    {
      var engine = Python.CreateEngine();
      var searchPaths = new List<string>();
      ScriptScope scope = engine.CreateScope();
      searchPaths.Add(@"C:\Users\by_na\AppData\Local\Packages");
      searchPaths.Add(@"C:\Users\by_na\source\repos\AspectBasedAnalysis\Libs");
      searchPaths.Add(@"C:\ProgramData\Anaconda3\Lib\site-packages");
      searchPaths.Add(@"C:\Users\by_na\AppData\Local\Packages\PythonSoftwareFoundation.Python.3.10_qbz5n2kfra8p0\LocalCache\local-packages\Python310\site-packages");
      engine.SetSearchPaths(searchPaths);
      scope.SetVariable("aspects", aspects);
      scope.SetVariable("path", pathToFile);
      engine.ExecuteFile("analysis.py", scope);
      ResultDataGridView.Visible = true;
    }

    private async Task startParserAsync(string productUrl)
    {
      string baseUrl = "http://otzovik.com";
      string pathToProductsElement = "//*[@id=\"content\"]/div/div/div/div/div[3]/div[1]/div[1]";
      string pathToLastPageElement = "//*[@id=\"content\"]/div/div/div/div/div[3]/div[1]/div[3]/a[12]";
      string patternUrlReviewPage = @"content=""(https:\/\/otzovik\.com\/review_\d*\.html)"">";
      string patternPageNumberPart = @"\/(\d*)\/";
      string pathReview = "//*[@id=\"content\"]/div/div/div/div/div[3]/div[1]/div[7]";
      List<string> urlReviewsList = new();
      List<string> chanksName = new();
      List<string> reviews = new();
      HtmlWeb web = new HtmlWeb();
      HtmlAgilityPack.HtmlDocument document = web.Load(string.Concat(baseUrl, "/", productUrl));
      var lastPage = document.DocumentNode.SelectNodes(pathToLastPageElement).First().Attributes[1];
      var lastPageNumber = int.Parse(GetGroupList(patternPageNumberPart, lastPage.Value).First());
      var currentUrlPage = String.Empty;
      var htmlFromAllProductPages = String.Empty;
      var path = "C:\\Users\\by_na\\Desktop\\reviews_urls.txt";
      Random rnd = new Random();

      List<string> addedReviews = new List<string>();
      using (StreamReader reader = new StreamReader(path))
      {
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
          addedReviews.Add(line);
      }
      for (int i = 1; i <= lastPageNumber; i++)
      {
        currentUrlPage = $"{baseUrl}/{productUrl}/{i}/";
        HtmlAgilityPack.HtmlDocument page = web.Load(currentUrlPage);
        IEnumerable<HtmlNode> reviewsChank = null;
        reviewsChank = page.DocumentNode.SelectNodes(pathToProductsElement).Nodes();
        Console.WriteLine($"Parsing url from page {i}");

        using (StreamWriter writer = new StreamWriter(path, true))
        {
          foreach (HtmlNode review in reviewsChank)
            await writer.WriteLineAsync(review.InnerHtml);
        }

        foreach (var chank in reviewsChank)
        {
          htmlFromAllProductPages += chank.InnerHtml;
        }

        int pauseValue = rnd.Next(5000, 50000);
        Thread.Sleep(5000 + pauseValue);
      }
      foreach (var line in addedReviews)
      {
        htmlFromAllProductPages += line;
      }
      urlReviewsList.AddRange(GetGroupList(patternUrlReviewPage, htmlFromAllProductPages));
      var path2 = "C:\\Users\\by_na\\Desktop\\reviews_clean_urls.txt";
      using (StreamWriter writer = new StreamWriter(path2, true))
      {
        foreach (var url in urlReviewsList)
          await writer.WriteLineAsync(url);
      }
      using (StreamReader reader = new StreamReader(path2))
      {
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
          urlReviewsList.Add(line);
      }
      int urlsCount = urlReviewsList.Count();
      List<string> addedReviewsList = new();
      addedReviewsList = GetAddedReviews();
      var counter = addedReviewsList.Count();
      foreach (var urlReview in urlReviewsList)
      {
        var url = urlReview.Replace(".html", "").Replace("https://otzovik.com/", "");

        if (!isAlreadyAddedReview(addedReviewsList, url))
        {
          HtmlAgilityPack.HtmlDocument reviewPage = web.Load(urlReview);
          var reviewDesc = reviewPage.DocumentNode.SelectNodes(pathReview).First().InnerText;
          int pauseValue = rnd.Next(5000, 50000);
          Thread.Sleep(5000 + pauseValue);

          try
          {
            if (reviewDesc != null)
            {
              counter++;
              var xEle = new XElement("Review", reviewDesc);
              xEle.SetAttributeValue("url", url);
              xEle.Save($"C:\\Users\\by_na\\Desktop\\reviews\\{url}_{pauseValue}.xml");
              Console.WriteLine("__________________________");
              Console.WriteLine($"Url: {url}  ReviewDescLength: {reviewDesc.Length}");
              Console.WriteLine($"Pause: {pauseValue}");
              Console.WriteLine($"Progress: {counter} / {urlsCount}");
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }

      try
      {
        var xEle = new XElement("REVIEWS",
          from review in reviews
          select new XElement("Review", review));

        xEle.Save("C:\\Users\\by_na\\Desktop\\reviews.xml");
        Console.WriteLine("Converted to XML");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

    }

    private void button2_Click(object sender, EventArgs e)
    {
      var path = String.Empty;
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        reviewSourseTextBox.Text = openFileDialog1.FileName;
      }
    }

    private void GetAnalisysResult()
    {
      var pathToAnswerXML = Environment.CurrentDirectory + "\\ResultsFolder\\answer.xml";
      Dictionary<string, float> resultSetniment = new();
      XDocument xdoc = XDocument.Load(pathToAnswerXML);
      var aspects = xdoc.Descendants("aspect");
      foreach (var aspect in aspects)
        resultSetniment.Add(aspect.Attribute("name").Value, float.Parse(aspect.Value));
      //return resultSetniment;
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

    public static List<string> GetGroupList(string _pattern, string _text)
    {
      List<string> groupList = new List<string>();
      Regex r = new Regex(_pattern);
      Match m = r.Match(_text);
      int matchCount = 0;
      while (m.Success)
      {
        for (int i = 1; i <= 2; i++)
        {
          Group g = m.Groups[i];
          CaptureCollection cc = g.Captures;
          for (int j = 0; j < cc.Count; j++)
          {
            Capture c = cc[j];
            groupList.Add(c.ToString());
          }
        }
        m = m.NextMatch();
      }
      return groupList;
    }

    public static bool isAlreadyAddedReview(List<string> _list, string _url)
    {
      Regex regex = new Regex(@"review_\d*");
      string urlMatch = regex.Match(_url).ToString();
      if (_list.Contains(urlMatch)) return true;
      else return false;
    }

    public static List<string> GetAddedReviews()
    {
      List<string> addedReviews = new();
      string[] fileEntries = Directory.GetFiles("C:\\Users\\by_na\\Desktop\\reviews");
      Regex regex = new Regex(@"review_\d*");

      foreach (string fileName in fileEntries)
      {
        addedReviews.Add(regex.Matches(fileName).First().ToString());
      }

      return addedReviews;
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

        if (settings.SourseType == sourseType.File)
        {
          StartPython(settings.Sourse, settings.Aspects);
          XDocument doc = XDocument.Load("answer.xml");
          foreach (var aspect in doc.Root.Elements("aspect"))
            ResultDataGridView.Rows.Add(aspect.Attribute("name")?.Value, aspect.Value);
        }
        else if (settings.SourseType == sourseType.Link)
        {
          startParserAsync(settings.Sourse);
          MessageBox.Show("Отзывы были получены с сайта Отзовик",
            "Отзывы получены",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      else MessageBox.Show("Для выполнения анализа необходимо указать: " +
        "\n- Источник отзывов" +
        "\n- Перечень анализируемых аспектов", 
                            "Невозможно выполнить анализ",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

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