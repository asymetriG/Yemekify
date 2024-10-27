namespace Yemekify
{
    partial class addRecipeForm
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
            this.recipeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryCbox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ingredientsGridView = new System.Windows.Forms.DataGridView();
            this.MalzemeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MalzemeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToplamMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MalzemeBirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirimFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.recipeTextBox = new System.Windows.Forms.RichTextBox();
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.deleteSelectedIngredient = new System.Windows.Forms.Button();
            this.addedIngredientsGridView = new System.Windows.Forms.DataGridView();
            this.addedMalzemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedMalzemeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedEklenenMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedMalzemeBirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedOlusanFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.addIngredientToDown = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ingredientSeachBar = new System.Windows.Forms.TextBox();
            this.typeOfIngredientCbox = new System.Windows.Forms.ComboBox();
            this.prepareTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.selectedImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addedIngredientsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarif Adı";
            // 
            // recipeName
            // 
            this.recipeName.AllowDrop = true;
            this.recipeName.BackColor = System.Drawing.Color.Orange;
            this.recipeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recipeName.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.recipeName.Location = new System.Drawing.Point(20, 81);
            this.recipeName.Name = "recipeName";
            this.recipeName.Size = new System.Drawing.Size(545, 43);
            this.recipeName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(316, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kategori";
            // 
            // categoryCbox
            // 
            this.categoryCbox.BackColor = System.Drawing.Color.Orange;
            this.categoryCbox.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.categoryCbox.FormattingEnabled = true;
            this.categoryCbox.Items.AddRange(new object[] {
            "Sıcak Başlangıç",
            "Soğuk Başlangıç",
            "Çorba",
            "Ana Yemek",
            "Ara Sıcak",
            "Tatlı",
            "Hamur İşi",
            "İçecek"});
            this.categoryCbox.Location = new System.Drawing.Point(324, 175);
            this.categoryCbox.Name = "categoryCbox";
            this.categoryCbox.Size = new System.Drawing.Size(241, 50);
            this.categoryCbox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(16, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hazırlanma Süresi";
            // 
            // ingredientsGridView
            // 
            this.ingredientsGridView.AllowUserToResizeColumns = false;
            this.ingredientsGridView.AllowUserToResizeRows = false;
            this.ingredientsGridView.BackgroundColor = System.Drawing.Color.Orange;
            this.ingredientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MalzemeID,
            this.MalzemeAdi,
            this.ToplamMiktar,
            this.MalzemeBirim,
            this.BirimFiyat});
            this.ingredientsGridView.Location = new System.Drawing.Point(28, 295);
            this.ingredientsGridView.MultiSelect = false;
            this.ingredientsGridView.Name = "ingredientsGridView";
            this.ingredientsGridView.Size = new System.Drawing.Size(544, 147);
            this.ingredientsGridView.TabIndex = 6;
            this.ingredientsGridView.SelectionChanged += new System.EventHandler(this.ingredientsGridView_SelectionChanged);
            // 
            // MalzemeID
            // 
            this.MalzemeID.HeaderText = "MalzemeID";
            this.MalzemeID.Name = "MalzemeID";
            // 
            // MalzemeAdi
            // 
            this.MalzemeAdi.HeaderText = "MalzemeAdi";
            this.MalzemeAdi.Name = "MalzemeAdi";
            // 
            // ToplamMiktar
            // 
            this.ToplamMiktar.HeaderText = "ToplamMiktar";
            this.ToplamMiktar.Name = "ToplamMiktar";
            // 
            // MalzemeBirim
            // 
            this.MalzemeBirim.HeaderText = "MalzemeBirim";
            this.MalzemeBirim.Name = "MalzemeBirim";
            // 
            // BirimFiyat
            // 
            this.BirimFiyat.HeaderText = "BirimFiyat";
            this.BirimFiyat.Name = "BirimFiyat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(705, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 45);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tarifi Giriniz";
            // 
            // recipeTextBox
            // 
            this.recipeTextBox.BackColor = System.Drawing.Color.Orange;
            this.recipeTextBox.Location = new System.Drawing.Point(617, 81);
            this.recipeTextBox.Name = "recipeTextBox";
            this.recipeTextBox.Size = new System.Drawing.Size(366, 201);
            this.recipeTextBox.TabIndex = 10;
            this.recipeTextBox.Text = "";
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.BackColor = System.Drawing.Color.DarkOrange;
            this.addRecipeButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addRecipeButton.Location = new System.Drawing.Point(617, 735);
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Size = new System.Drawing.Size(366, 41);
            this.addRecipeButton.TabIndex = 11;
            this.addRecipeButton.Text = "Tarifi Ekle";
            this.addRecipeButton.UseVisualStyleBackColor = false;
            this.addRecipeButton.Click += new System.EventHandler(this.addRecipeButton_Click);
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalPriceLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalPriceLabel.Location = new System.Drawing.Point(683, 640);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(91, 39);
            this.totalPriceLabel.TabIndex = 12;
            this.totalPriceLabel.Text = "0 PLN";
            this.totalPriceLabel.Click += new System.EventHandler(this.totalPriceLabel_Click);
            // 
            // deleteSelectedIngredient
            // 
            this.deleteSelectedIngredient.BackColor = System.Drawing.Color.DarkOrange;
            this.deleteSelectedIngredient.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteSelectedIngredient.Location = new System.Drawing.Point(29, 735);
            this.deleteSelectedIngredient.Name = "deleteSelectedIngredient";
            this.deleteSelectedIngredient.Size = new System.Drawing.Size(544, 41);
            this.deleteSelectedIngredient.TabIndex = 13;
            this.deleteSelectedIngredient.Text = "Seçilen Malzemeyi Sil";
            this.deleteSelectedIngredient.UseVisualStyleBackColor = false;
            this.deleteSelectedIngredient.Click += new System.EventHandler(this.deleteSelectedIngredient_Click);
            // 
            // addedIngredientsGridView
            // 
            this.addedIngredientsGridView.AllowUserToResizeColumns = false;
            this.addedIngredientsGridView.AllowUserToResizeRows = false;
            this.addedIngredientsGridView.BackgroundColor = System.Drawing.Color.Orange;
            this.addedIngredientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addedIngredientsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addedMalzemeId,
            this.addedMalzemeAdi,
            this.addedEklenenMiktar,
            this.addedMalzemeBirim,
            this.addedOlusanFiyat});
            this.addedIngredientsGridView.Location = new System.Drawing.Point(29, 555);
            this.addedIngredientsGridView.MultiSelect = false;
            this.addedIngredientsGridView.Name = "addedIngredientsGridView";
            this.addedIngredientsGridView.Size = new System.Drawing.Size(543, 138);
            this.addedIngredientsGridView.TabIndex = 15;
            // 
            // addedMalzemeId
            // 
            this.addedMalzemeId.HeaderText = "MalzemeID";
            this.addedMalzemeId.Name = "addedMalzemeId";
            // 
            // addedMalzemeAdi
            // 
            this.addedMalzemeAdi.HeaderText = "MalzemeAdi";
            this.addedMalzemeAdi.Name = "addedMalzemeAdi";
            // 
            // addedEklenenMiktar
            // 
            this.addedEklenenMiktar.HeaderText = "Eklenen Miktar";
            this.addedEklenenMiktar.Name = "addedEklenenMiktar";
            // 
            // addedMalzemeBirim
            // 
            this.addedMalzemeBirim.HeaderText = "MalzemeBirim";
            this.addedMalzemeBirim.Name = "addedMalzemeBirim";
            // 
            // addedOlusanFiyat
            // 
            this.addedOlusanFiyat.HeaderText = "Oluşan Fiyat";
            this.addedOlusanFiyat.Name = "addedOlusanFiyat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(30, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 45);
            this.label5.TabIndex = 16;
            this.label5.Text = "Malzeme Seç";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(21, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 45);
            this.label6.TabIndex = 17;
            this.label6.Text = "Miktar Giriniz :";
            // 
            // amountTextBox
            // 
            this.amountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.amountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.amountTextBox.Location = new System.Drawing.Point(267, 457);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(102, 28);
            this.amountTextBox.TabIndex = 19;
            // 
            // addIngredientToDown
            // 
            this.addIngredientToDown.Location = new System.Drawing.Point(475, 453);
            this.addIngredientToDown.Name = "addIngredientToDown";
            this.addIngredientToDown.Size = new System.Drawing.Size(99, 37);
            this.addIngredientToDown.TabIndex = 20;
            this.addIngredientToDown.Text = "Malzemeyi Ekle";
            this.addIngredientToDown.UseVisualStyleBackColor = true;
            this.addIngredientToDown.Click += new System.EventHandler(this.addIngredientToDown_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(153, 510);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(290, 33);
            this.label7.TabIndex = 21;
            this.label7.Text = "Eklenen Malzeme Listesi";
            // 
            // ingredientSeachBar
            // 
            this.ingredientSeachBar.AllowDrop = true;
            this.ingredientSeachBar.BackColor = System.Drawing.Color.Orange;
            this.ingredientSeachBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ingredientSeachBar.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ingredientSeachBar.Location = new System.Drawing.Point(267, 239);
            this.ingredientSeachBar.Name = "ingredientSeachBar";
            this.ingredientSeachBar.Size = new System.Drawing.Size(298, 43);
            this.ingredientSeachBar.TabIndex = 22;
            this.ingredientSeachBar.TextChanged += new System.EventHandler(this.ingredientSeachBar_TextChanged);
            // 
            // typeOfIngredientCbox
            // 
            this.typeOfIngredientCbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.typeOfIngredientCbox.FormattingEnabled = true;
            this.typeOfIngredientCbox.Location = new System.Drawing.Point(378, 454);
            this.typeOfIngredientCbox.Name = "typeOfIngredientCbox";
            this.typeOfIngredientCbox.Size = new System.Drawing.Size(91, 32);
            this.typeOfIngredientCbox.TabIndex = 23;
            // 
            // prepareTime
            // 
            this.prepareTime.AllowDrop = true;
            this.prepareTime.BackColor = System.Drawing.Color.Orange;
            this.prepareTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prepareTime.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.prepareTime.Location = new System.Drawing.Point(24, 178);
            this.prepareTime.Name = "prepareTime";
            this.prepareTime.Size = new System.Drawing.Size(286, 43);
            this.prepareTime.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(696, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 45);
            this.label8.TabIndex = 26;
            this.label8.Text = "Resim Seçiniz";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(683, 601);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 39);
            this.label9.TabIndex = 27;
            this.label9.Text = "Toplam Maliyet ";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // selectedImage
            // 
            this.selectedImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectedImage.Image = global::Yemekify.Properties.Resources.selectimg;
            this.selectedImage.Location = new System.Drawing.Point(690, 353);
            this.selectedImage.Name = "selectedImage";
            this.selectedImage.Size = new System.Drawing.Size(233, 231);
            this.selectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectedImage.TabIndex = 25;
            this.selectedImage.TabStop = false;
            this.selectedImage.Click += new System.EventHandler(this.selectedImage_Click);
            // 
            // addRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(1003, 788);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.selectedImage);
            this.Controls.Add(this.prepareTime);
            this.Controls.Add(this.typeOfIngredientCbox);
            this.Controls.Add(this.ingredientSeachBar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addIngredientToDown);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addedIngredientsGridView);
            this.Controls.Add(this.deleteSelectedIngredient);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.addRecipeButton);
            this.Controls.Add(this.recipeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ingredientsGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.categoryCbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recipeName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "addRecipeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarif Ekle";
            this.Load += new System.EventHandler(this.addRecipeForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addRecipeForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addedIngredientsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox recipeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox categoryCbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ingredientsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToplamMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeBirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirimFiyat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox recipeTextBox;
        private System.Windows.Forms.Button addRecipeButton;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Button deleteSelectedIngredient;
        private System.Windows.Forms.DataGridView addedIngredientsGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button addIngredientToDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ingredientSeachBar;
        private System.Windows.Forms.ComboBox typeOfIngredientCbox;
        private System.Windows.Forms.TextBox prepareTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedMalzemeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedMalzemeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedEklenenMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedMalzemeBirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedOlusanFiyat;
        private System.Windows.Forms.PictureBox selectedImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}