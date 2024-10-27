namespace Yemekify
{
    partial class showRecipeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recipeNameLabel = new System.Windows.Forms.Label();
            this.ingredientsListBox = new System.Windows.Forms.ListBox();
            this.recipeImagePictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prepareTimeLabel = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.recipeInstructionsTextBox = new System.Windows.Forms.RichTextBox();
            this.removeRecipeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.recipeImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // recipeNameLabel
            // 
            this.recipeNameLabel.AutoSize = true;
            this.recipeNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.recipeNameLabel.Location = new System.Drawing.Point(12, 39);
            this.recipeNameLabel.Name = "recipeNameLabel";
            this.recipeNameLabel.Size = new System.Drawing.Size(215, 40);
            this.recipeNameLabel.TabIndex = 0;
            this.recipeNameLabel.Text = "Tarif Adı (Tatlı)";
            // 
            // ingredientsListBox
            // 
            this.ingredientsListBox.FormattingEnabled = true;
            this.ingredientsListBox.ItemHeight = 21;
            this.ingredientsListBox.Location = new System.Drawing.Point(12, 332);
            this.ingredientsListBox.Name = "ingredientsListBox";
            this.ingredientsListBox.Size = new System.Drawing.Size(270, 109);
            this.ingredientsListBox.TabIndex = 2;
            // 
            // recipeImagePictureBox
            // 
            this.recipeImagePictureBox.Location = new System.Drawing.Point(12, 94);
            this.recipeImagePictureBox.Name = "recipeImagePictureBox";
            this.recipeImagePictureBox.Size = new System.Drawing.Size(270, 171);
            this.recipeImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recipeImagePictureBox.TabIndex = 1;
            this.recipeImagePictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(58, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Malzemeler";
            // 
            // prepareTimeLabel
            // 
            this.prepareTimeLabel.AutoSize = true;
            this.prepareTimeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.prepareTimeLabel.Location = new System.Drawing.Point(12, 534);
            this.prepareTimeLabel.Name = "prepareTimeLabel";
            this.prepareTimeLabel.Size = new System.Drawing.Size(282, 30);
            this.prepareTimeLabel.TabIndex = 4;
            this.prepareTimeLabel.Text = "Hazirlama Suresi : 120 dakika";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalPriceLabel.Location = new System.Drawing.Point(12, 483);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(248, 30);
            this.totalPriceLabel.TabIndex = 5;
            this.totalPriceLabel.Text = "Toplam Maliyet : 120 PLN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(444, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tarifin Yapılışı";
            // 
            // recipeInstructionsTextBox
            // 
            this.recipeInstructionsTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.recipeInstructionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recipeInstructionsTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.recipeInstructionsTextBox.Location = new System.Drawing.Point(397, 94);
            this.recipeInstructionsTextBox.Name = "recipeInstructionsTextBox";
            this.recipeInstructionsTextBox.ReadOnly = true;
            this.recipeInstructionsTextBox.Size = new System.Drawing.Size(295, 437);
            this.recipeInstructionsTextBox.TabIndex = 7;
            this.recipeInstructionsTextBox.Text = "";
            // 
            // removeRecipeButton
            // 
            this.removeRecipeButton.Location = new System.Drawing.Point(397, 553);
            this.removeRecipeButton.Name = "removeRecipeButton";
            this.removeRecipeButton.Size = new System.Drawing.Size(295, 44);
            this.removeRecipeButton.TabIndex = 8;
            this.removeRecipeButton.Text = "Tarifi Sil";
            this.removeRecipeButton.UseVisualStyleBackColor = true;
            this.removeRecipeButton.Click += new System.EventHandler(this.removeRecipeButton_Click);
            // 
            // showRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 618);
            this.Controls.Add(this.removeRecipeButton);
            this.Controls.Add(this.recipeInstructionsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.prepareTimeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ingredientsListBox);
            this.Controls.Add(this.recipeImagePictureBox);
            this.Controls.Add(this.recipeNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "showRecipeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "showRecipeForm";
            this.Load += new System.EventHandler(this.showRecipeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recipeImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recipeNameLabel;
        private System.Windows.Forms.PictureBox recipeImagePictureBox;
        private System.Windows.Forms.ListBox ingredientsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label prepareTimeLabel;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox recipeInstructionsTextBox;
        private System.Windows.Forms.Button removeRecipeButton;
    }
}