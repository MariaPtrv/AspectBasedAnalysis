namespace AspectBasedAnalysis
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.ResultDataGridView = new System.Windows.Forms.DataGridView();
      this.AspectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.TonalityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.newAspectTextBox = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.reviewSourseTextBox = new System.Windows.Forms.TextBox();
      this.button2 = new System.Windows.Forms.Button();
      this.SourseTypeLabel = new System.Windows.Forms.Label();
      this.groupAspectsList = new System.Windows.Forms.GroupBox();
      this.AspectsCheckedListBox = new System.Windows.Forms.CheckedListBox();
      this.AnalysButton = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.NoResultLabel = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.ResultDataGridView)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupAspectsList.SuspendLayout();
      this.SuspendLayout();
      // 
      // ResultDataGridView
      // 
      this.ResultDataGridView.BackgroundColor = System.Drawing.Color.White;
      this.ResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ResultDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AspectColumn,
            this.DescColumn,
            this.TonalityColumn});
      this.ResultDataGridView.Location = new System.Drawing.Point(482, 225);
      this.ResultDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.ResultDataGridView.Name = "ResultDataGridView";
      this.ResultDataGridView.RowTemplate.Height = 25;
      this.ResultDataGridView.Size = new System.Drawing.Size(783, 364);
      this.ResultDataGridView.TabIndex = 0;
      // 
      // AspectColumn
      // 
      this.AspectColumn.HeaderText = "Аспект";
      this.AspectColumn.MinimumWidth = 200;
      this.AspectColumn.Name = "AspectColumn";
      this.AspectColumn.ReadOnly = true;
      this.AspectColumn.Width = 200;
      // 
      // DescColumn
      // 
      this.DescColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.DescColumn.HeaderText = "Тональные слова";
      this.DescColumn.Name = "DescColumn";
      this.DescColumn.ReadOnly = true;
      // 
      // TonalityColumn
      // 
      this.TonalityColumn.HeaderText = "Тональность";
      this.TonalityColumn.MinimumWidth = 150;
      this.TonalityColumn.Name = "TonalityColumn";
      this.TonalityColumn.ReadOnly = true;
      this.TonalityColumn.Width = 150;
      // 
      // newAspectTextBox
      // 
      this.newAspectTextBox.Location = new System.Drawing.Point(19, 29);
      this.newAspectTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.newAspectTextBox.Name = "newAspectTextBox";
      this.newAspectTextBox.Size = new System.Drawing.Size(263, 26);
      this.newAspectTextBox.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.Transparent;
      this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.button1.ForeColor = System.Drawing.Color.Teal;
      this.button1.Location = new System.Drawing.Point(288, 29);
      this.button1.Name = "button1";
      this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.button1.Size = new System.Drawing.Size(27, 26);
      this.button1.TabIndex = 2;
      this.button1.Text = "+";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.label);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.reviewSourseTextBox);
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.SourseTypeLabel);
      this.groupBox1.Location = new System.Drawing.Point(14, 13);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Size = new System.Drawing.Size(446, 192);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Источник отзывов";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(40, 71);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(201, 20);
      this.label1.TabIndex = 12;
      this.label1.Text = "- Ссылка на сайте otzovik.com;";
      // 
      // label
      // 
      this.label.AutoSize = true;
      this.label.Location = new System.Drawing.Point(6, 140);
      this.label.Name = "label";
      this.label.Size = new System.Drawing.Size(124, 20);
      this.label.TabIndex = 11;
      this.label.Text = "Источник отзывов:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(40, 50);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(189, 20);
      this.label3.TabIndex = 10;
      this.label3.Text = "- Путь к файлу с отзывами ();";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(227, 20);
      this.label2.TabIndex = 9;
      this.label2.Text = "Источником может быть один типа:";
      // 
      // reviewSourseTextBox
      // 
      this.reviewSourseTextBox.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.reviewSourseTextBox.Location = new System.Drawing.Point(7, 109);
      this.reviewSourseTextBox.Margin = new System.Windows.Forms.Padding(5);
      this.reviewSourseTextBox.Name = "reviewSourseTextBox";
      this.reviewSourseTextBox.Size = new System.Drawing.Size(341, 22);
      this.reviewSourseTextBox.TabIndex = 8;
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.White;
      this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button2.ForeColor = System.Drawing.Color.Black;
      this.button2.Location = new System.Drawing.Point(354, 106);
      this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(86, 31);
      this.button2.TabIndex = 6;
      this.button2.Text = "Выбрать";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // SourseTypeLabel
      // 
      this.SourseTypeLabel.AutoSize = true;
      this.SourseTypeLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
      this.SourseTypeLabel.Location = new System.Drawing.Point(165, 149);
      this.SourseTypeLabel.Name = "SourseTypeLabel";
      this.SourseTypeLabel.Size = new System.Drawing.Size(0, 20);
      this.SourseTypeLabel.TabIndex = 6;
      // 
      // groupAspectsList
      // 
      this.groupAspectsList.BackColor = System.Drawing.Color.White;
      this.groupAspectsList.Controls.Add(this.AspectsCheckedListBox);
      this.groupAspectsList.Controls.Add(this.newAspectTextBox);
      this.groupAspectsList.Controls.Add(this.button1);
      this.groupAspectsList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.groupAspectsList.ForeColor = System.Drawing.Color.Black;
      this.groupAspectsList.Location = new System.Drawing.Point(14, 213);
      this.groupAspectsList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupAspectsList.Name = "groupAspectsList";
      this.groupAspectsList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupAspectsList.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.groupAspectsList.Size = new System.Drawing.Size(446, 334);
      this.groupAspectsList.TabIndex = 5;
      this.groupAspectsList.TabStop = false;
      this.groupAspectsList.Text = "Список аспектов";
      // 
      // AspectsCheckedListBox
      // 
      this.AspectsCheckedListBox.BackColor = System.Drawing.Color.White;
      this.AspectsCheckedListBox.FormattingEnabled = true;
      this.AspectsCheckedListBox.Location = new System.Drawing.Point(19, 63);
      this.AspectsCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.AspectsCheckedListBox.Name = "AspectsCheckedListBox";
      this.AspectsCheckedListBox.Size = new System.Drawing.Size(263, 193);
      this.AspectsCheckedListBox.TabIndex = 4;
      // 
      // AnalysButton
      // 
      this.AnalysButton.BackColor = System.Drawing.Color.White;
      this.AnalysButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.AnalysButton.ForeColor = System.Drawing.Color.Black;
      this.AnalysButton.Location = new System.Drawing.Point(374, 555);
      this.AnalysButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.AnalysButton.Name = "AnalysButton";
      this.AnalysButton.Size = new System.Drawing.Size(86, 31);
      this.AnalysButton.TabIndex = 6;
      this.AnalysButton.Text = "Анализ";
      this.AnalysButton.UseVisualStyleBackColor = false;
      this.AnalysButton.Click += new System.EventHandler(this.AnalysisButton_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // NoResultLabel
      // 
      this.NoResultLabel.AutoSize = true;
      this.NoResultLabel.BackColor = System.Drawing.Color.Transparent;
      this.NoResultLabel.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.NoResultLabel.ForeColor = System.Drawing.Color.Silver;
      this.NoResultLabel.Location = new System.Drawing.Point(707, 310);
      this.NoResultLabel.Name = "NoResultLabel";
      this.NoResultLabel.Size = new System.Drawing.Size(228, 23);
      this.NoResultLabel.TabIndex = 12;
      this.NoResultLabel.Text = "Нет данных для отображения";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(482, 23);
      this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(145, 20);
      this.label4.TabIndex = 13;
      this.label4.Text = "Количество аспектов:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(482, 48);
      this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(190, 20);
      this.label5.TabIndex = 14;
      this.label5.Text = "Количество тональных слов:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(482, 76);
      this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(248, 20);
      this.label6.TabIndex = 15;
      this.label6.Text = "Количество положительных аспектов:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(482, 101);
      this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(219, 20);
      this.label7.TabIndex = 16;
      this.label7.Text = "Количество негативных аспектов:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(482, 126);
      this.label8.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(230, 20);
      this.label8.TabIndex = 17;
      this.label8.Text = "Количество нейтральных аспектов:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(741, 23);
      this.label9.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(145, 20);
      this.label9.TabIndex = 18;
      this.label9.Text = "Количество аспектов:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(1276, 599);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.NoResultLabel);
      this.Controls.Add(this.AnalysButton);
      this.Controls.Add(this.groupAspectsList);
      this.Controls.Add(this.ResultDataGridView);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.ForeColor = System.Drawing.Color.Black;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Aspect-based analysis app";
      ((System.ComponentModel.ISupportInitialize)(this.ResultDataGridView)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupAspectsList.ResumeLayout(false);
      this.groupAspectsList.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DataGridView ResultDataGridView;
    private TextBox newAspectTextBox;
    private Button button1;
    private GroupBox groupBox1;
    private Label label3;
    private Label label2;
    private TextBox reviewSourseTextBox;
    private Button button2;
    private Label SourseTypeLabel;
    private GroupBox groupAspectsList;
    private CheckedListBox AspectsCheckedListBox;
    private Button AnalysButton;
    private OpenFileDialog openFileDialog1;
    private DataGridViewTextBoxColumn AspectColumn;
    private DataGridViewTextBoxColumn DescColumn;
    private DataGridViewTextBoxColumn TonalityColumn;
    private Label label;
    private Label NoResultLabel;
    private Label label1;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
  }
}