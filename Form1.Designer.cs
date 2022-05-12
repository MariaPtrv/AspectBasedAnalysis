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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.newAspectTextBox = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.button2 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.groupAspectsList = new System.Windows.Forms.GroupBox();
      this.AspectsCheckedListBox = new System.Windows.Forms.CheckedListBox();
      this.button3 = new System.Windows.Forms.Button();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupAspectsList.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(463, 223);
      this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 25;
      this.dataGridView1.Size = new System.Drawing.Size(813, 523);
      this.dataGridView1.TabIndex = 0;
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
      this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
      this.button1.FlatAppearance.BorderSize = 0;
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
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.textBox3);
      this.groupBox1.Controls.Add(this.textBox2);
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(14, 13);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Size = new System.Drawing.Size(383, 192);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(7, 95);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(45, 20);
      this.label3.TabIndex = 10;
      this.label3.Text = "label3";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 63);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 20);
      this.label2.TabIndex = 9;
      this.label2.Text = "label2";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(7, 119);
      this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(263, 26);
      this.textBox3.TabIndex = 8;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(7, 153);
      this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(263, 26);
      this.textBox2.TabIndex = 7;
      // 
      // button2
      // 
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button2.Location = new System.Drawing.Point(276, 117);
      this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(86, 31);
      this.button2.TabIndex = 6;
      this.button2.Text = "Выбрать";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 20);
      this.label1.TabIndex = 6;
      this.label1.Text = "label1";
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
      this.groupAspectsList.Size = new System.Drawing.Size(383, 296);
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
      this.AspectsCheckedListBox.Size = new System.Drawing.Size(263, 214);
      this.AspectsCheckedListBox.TabIndex = 4;
      // 
      // button3
      // 
      this.button3.BackColor = System.Drawing.Color.White;
      this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button3.ForeColor = System.Drawing.Color.Black;
      this.button3.Location = new System.Drawing.Point(276, 22);
      this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(86, 31);
      this.button3.TabIndex = 6;
      this.button3.Text = "Анализ";
      this.button3.UseVisualStyleBackColor = false;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(19, 29);
      this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(95, 24);
      this.checkBox1.TabIndex = 7;
      this.checkBox1.Text = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.checkBox1);
      this.groupBox3.Controls.Add(this.button3);
      this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.groupBox3.Location = new System.Drawing.Point(14, 517);
      this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox3.Size = new System.Drawing.Size(383, 229);
      this.groupBox3.TabIndex = 8;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "groupBox3";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(1293, 757);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupAspectsList);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.ForeColor = System.Drawing.Color.Black;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Aspect-based analysis app";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupAspectsList.ResumeLayout(false);
      this.groupAspectsList.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private DataGridView dataGridView1;
    private TextBox newAspectTextBox;
    private Button button1;
    private GroupBox groupBox1;
    private Label label3;
    private Label label2;
    private TextBox textBox3;
    private TextBox textBox2;
    private Button button2;
    private Label label1;
    private GroupBox groupAspectsList;
    private CheckedListBox AspectsCheckedListBox;
    private Button button3;
    private CheckBox checkBox1;
    private GroupBox groupBox3;
    private OpenFileDialog openFileDialog1;
  }
}