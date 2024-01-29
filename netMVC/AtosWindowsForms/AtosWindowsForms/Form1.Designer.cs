namespace AtosWindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn讀取 = new System.Windows.Forms.Button();
            this.btn寫入資料庫 = new System.Windows.Forms.Button();
            this.lab顯示資料 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(26, 49);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(257, 229);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn讀取
            // 
            this.btn讀取.Location = new System.Drawing.Point(303, 30);
            this.btn讀取.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn讀取.Name = "btn讀取";
            this.btn讀取.Size = new System.Drawing.Size(141, 53);
            this.btn讀取.TabIndex = 1;
            this.btn讀取.Text = "讀取";
            this.btn讀取.UseVisualStyleBackColor = true;
            this.btn讀取.Click += new System.EventHandler(this.btn讀取_Click);
            // 
            // btn寫入資料庫
            // 
            this.btn寫入資料庫.Location = new System.Drawing.Point(303, 107);
            this.btn寫入資料庫.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn寫入資料庫.Name = "btn寫入資料庫";
            this.btn寫入資料庫.Size = new System.Drawing.Size(141, 53);
            this.btn寫入資料庫.TabIndex = 2;
            this.btn寫入資料庫.Text = "寫入資料庫";
            this.btn寫入資料庫.UseVisualStyleBackColor = true;
            this.btn寫入資料庫.Click += new System.EventHandler(this.btn寫入資料庫_Click);
            // 
            // lab顯示資料
            // 
            this.lab顯示資料.AutoSize = true;
            this.lab顯示資料.Location = new System.Drawing.Point(23, 17);
            this.lab顯示資料.Name = "lab顯示資料";
            this.lab顯示資料.Size = new System.Drawing.Size(71, 15);
            this.lab顯示資料.TabIndex = 3;
            this.lab顯示資料.Text = "顯示資料:";
            this.lab顯示資料.Click += new System.EventHandler(this.lab顯示資料_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(451, 253);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 375);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lab顯示資料);
            this.Controls.Add(this.btn寫入資料庫);
            this.Controls.Add(this.btn讀取);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn讀取;
        private System.Windows.Forms.Button btn寫入資料庫;
        private System.Windows.Forms.Label lab顯示資料;
        private System.Windows.Forms.TextBox textBox1;
    }
}

