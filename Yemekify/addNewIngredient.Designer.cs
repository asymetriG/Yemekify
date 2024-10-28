namespace Yemekify
{
    partial class addNewIngredient
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ingredientNameTextBox = new System.Windows.Forms.TextBox();
            this.totalAmountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.typeOfIngredientCbox = new System.Windows.Forms.ComboBox();
            this.birimFiyatTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(109, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yeni Malzeme Ekle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Malzeme Adı ";
            // 
            // ingredientNameTextBox
            // 
            this.ingredientNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ingredientNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ingredientNameTextBox.Location = new System.Drawing.Point(146, 81);
            this.ingredientNameTextBox.Name = "ingredientNameTextBox";
            this.ingredientNameTextBox.Size = new System.Drawing.Size(277, 22);
            this.ingredientNameTextBox.TabIndex = 2;
            // 
            // totalAmountTextBox
            // 
            this.totalAmountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalAmountTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalAmountTextBox.Location = new System.Drawing.Point(146, 123);
            this.totalAmountTextBox.Name = "totalAmountTextBox";
            this.totalAmountTextBox.Size = new System.Drawing.Size(277, 22);
            this.totalAmountTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(13, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Toplam Miktar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(13, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Malzeme Birimi";
            // 
            // typeOfIngredientCbox
            // 
            this.typeOfIngredientCbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.typeOfIngredientCbox.FormattingEnabled = true;
            this.typeOfIngredientCbox.Items.AddRange(new object[] {
            "Gram",
            "Kilogram",
            "Mililitre",
            "Litre",
            "Adet"});
            this.typeOfIngredientCbox.Location = new System.Drawing.Point(163, 167);
            this.typeOfIngredientCbox.Name = "typeOfIngredientCbox";
            this.typeOfIngredientCbox.Size = new System.Drawing.Size(260, 28);
            this.typeOfIngredientCbox.TabIndex = 6;
            // 
            // birimFiyatTextBox
            // 
            this.birimFiyatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.birimFiyatTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.birimFiyatTextBox.Location = new System.Drawing.Point(146, 219);
            this.birimFiyatTextBox.Name = "birimFiyatTextBox";
            this.birimFiyatTextBox.Size = new System.Drawing.Size(277, 22);
            this.birimFiyatTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(13, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Birim Fiyat";
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addIngredientButton.Location = new System.Drawing.Point(18, 268);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(405, 39);
            this.addIngredientButton.TabIndex = 9;
            this.addIngredientButton.Text = "Malzemeyi Depoya Ekle";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // addNewIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 331);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.birimFiyatTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.typeOfIngredientCbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalAmountTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ingredientNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "addNewIngredient";
            this.Text = "addNewIngredient";
            this.Load += new System.EventHandler(this.addNewIngredient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ingredientNameTextBox;
        private System.Windows.Forms.TextBox totalAmountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox typeOfIngredientCbox;
        private System.Windows.Forms.TextBox birimFiyatTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addIngredientButton;
    }
}