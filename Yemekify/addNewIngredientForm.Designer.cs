namespace Yemekify
{
    partial class addNewIngredientForm
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
            this.ingredientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.typePrice = new System.Windows.Forms.TextBox();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.ingredientTypeCbox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ingredientName
            // 
            this.ingredientName.Location = new System.Drawing.Point(107, 53);
            this.ingredientName.Name = "ingredientName";
            this.ingredientName.Size = new System.Drawing.Size(188, 20);
            this.ingredientName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Malzeme Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Toplam Miktar";
            // 
            // totalAmount
            // 
            this.totalAmount.Location = new System.Drawing.Point(107, 85);
            this.totalAmount.Name = "totalAmount";
            this.totalAmount.Size = new System.Drawing.Size(188, 20);
            this.totalAmount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Malzeme Birimi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Birim Fiyat";
            // 
            // typePrice
            // 
            this.typePrice.Location = new System.Drawing.Point(107, 180);
            this.typePrice.Name = "typePrice";
            this.typePrice.Size = new System.Drawing.Size(188, 20);
            this.typePrice.TabIndex = 7;
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(16, 225);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(279, 23);
            this.addIngredientButton.TabIndex = 8;
            this.addIngredientButton.Text = "Malzeme Ekle";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // ingredientTypeCbox
            // 
            this.ingredientTypeCbox.FormattingEnabled = true;
            this.ingredientTypeCbox.Items.AddRange(new object[] {
            "Kilogram",
            "Gram",
            "Çay Kaşığı",
            "Tatlı Kaşığı",
            "Yemek Kaşığı",
            "Bardak",
            "Litre",
            "Mililitre",
            "Ton",
            "Adet"});
            this.ingredientTypeCbox.Location = new System.Drawing.Point(107, 132);
            this.ingredientTypeCbox.Name = "ingredientTypeCbox";
            this.ingredientTypeCbox.Size = new System.Drawing.Size(188, 21);
            this.ingredientTypeCbox.TabIndex = 9;
            // 
            // addNewIngredientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 297);
            this.Controls.Add(this.ingredientTypeCbox);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.typePrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ingredientName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "addNewIngredientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addNewIngredientForm";
            this.Load += new System.EventHandler(this.addNewIngredientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ingredientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox typePrice;
        private System.Windows.Forms.Button addIngredientButton;
        private System.Windows.Forms.ComboBox ingredientTypeCbox;
    }
}