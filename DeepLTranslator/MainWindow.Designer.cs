namespace DeepLTranslator
{
    partial class MainWindow
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_BeforeTranslate = new System.Windows.Forms.RichTextBox();
            this.txt_AfterTranslate = new System.Windows.Forms.RichTextBox();
            this.btn_Translate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(158, 719);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 0;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += btn_Load_Click;
            // 
            // btn_Translate
            // 
            this.btn_Translate.Location = new System.Drawing.Point(444, 719);
            this.btn_Translate.Name = "btn_Translate";
            this.btn_Translate.Size = new System.Drawing.Size(75, 23);
            this.btn_Translate.TabIndex = 4;
            this.btn_Translate.Text = "Translate";
            this.btn_Translate.UseVisualStyleBackColor = true;
            this.btn_Translate.Click += btn_Translate_Click;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(739, 719);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += btn_Save_Click;
            // 
            // txt_BeforeTranslate
            // 
            this.txt_BeforeTranslate.Location = new System.Drawing.Point(57, 54);
            this.txt_BeforeTranslate.Name = "txt_BeforeTranslate";
            this.txt_BeforeTranslate.Size = new System.Drawing.Size(325, 566);
            this.txt_BeforeTranslate.TabIndex = 2;
            this.txt_BeforeTranslate.Text = "";
            // 
            // txt_AfterTranslate
            // 
            this.txt_AfterTranslate.Location = new System.Drawing.Point(600, 56);
            this.txt_AfterTranslate.Name = "txt_AfterTranslate";
            this.txt_AfterTranslate.Size = new System.Drawing.Size(327, 564);
            this.txt_AfterTranslate.TabIndex = 3;
            this.txt_AfterTranslate.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 855);
            this.Controls.Add(this.btn_Translate);
            this.Controls.Add(this.txt_AfterTranslate);
            this.Controls.Add(this.txt_BeforeTranslate);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Load);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Button btn_Load;
        private Button btn_Save;
        private RichTextBox txt_BeforeTranslate;
        private RichTextBox txt_AfterTranslate;
        private Button btn_Translate;
    }
}