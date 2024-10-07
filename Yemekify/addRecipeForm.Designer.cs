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
            this.prepareTime = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ingredientsGridView = new System.Windows.Forms.DataGridView();
            this.MalzemeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MalzemeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToplamMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MalzemeBirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirimFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editSelectedIngredientButton = new System.Windows.Forms.Button();
            this.addIngredient = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.recipeTextBox = new System.Windows.Forms.RichTextBox();
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.deleteSelectedIngredient = new System.Windows.Forms.Button();
            this.deleteAllIngredients = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarif Adı";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // recipeName
            // 
            this.recipeName.AllowDrop = true;
            this.recipeName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.recipeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recipeName.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.recipeName.Location = new System.Drawing.Point(20, 100);
            this.recipeName.Name = "recipeName";
            this.recipeName.Size = new System.Drawing.Size(549, 40);
            this.recipeName.TabIndex = 1;
            this.recipeName.TextChanged += new System.EventHandler(this.recipeName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kategori";
            // 
            // categoryCbox
            // 
            this.categoryCbox.BackColor = System.Drawing.Color.LightSteelBlue;
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
            this.categoryCbox.Location = new System.Drawing.Point(20, 211);
            this.categoryCbox.Name = "categoryCbox";
            this.categoryCbox.Size = new System.Drawing.Size(549, 50);
            this.categoryCbox.TabIndex = 3;
            this.categoryCbox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // prepareTime
            // 
            this.prepareTime.BackColor = System.Drawing.Color.LightSteelBlue;
            this.prepareTime.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.prepareTime.Location = new System.Drawing.Point(20, 330);
            this.prepareTime.Mask = "00000";
            this.prepareTime.Name = "prepareTime";
            this.prepareTime.Size = new System.Drawing.Size(545, 50);
            this.prepareTime.TabIndex = 4;
            this.prepareTime.ValidatingType = typeof(int);
            this.prepareTime.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.prepareTime_MaskInputRejected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hazırlanma Süresi";
            // 
            // ingredientsGridView
            // 
            this.ingredientsGridView.AllowUserToResizeColumns = false;
            this.ingredientsGridView.AllowUserToResizeRows = false;
            this.ingredientsGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ingredientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MalzemeID,
            this.MalzemeAdi,
            this.ToplamMiktar,
            this.MalzemeBirim,
            this.BirimFiyat});
            this.ingredientsGridView.Location = new System.Drawing.Point(24, 422);
            this.ingredientsGridView.Name = "ingredientsGridView";
            this.ingredientsGridView.Size = new System.Drawing.Size(545, 150);
            this.ingredientsGridView.TabIndex = 6;
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
            // editSelectedIngredientButton
            // 
            this.editSelectedIngredientButton.BackColor = System.Drawing.Color.SkyBlue;
            this.editSelectedIngredientButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.editSelectedIngredientButton.Location = new System.Drawing.Point(20, 656);
            this.editSelectedIngredientButton.Name = "editSelectedIngredientButton";
            this.editSelectedIngredientButton.Size = new System.Drawing.Size(259, 41);
            this.editSelectedIngredientButton.TabIndex = 7;
            this.editSelectedIngredientButton.Text = "Seçilen Malzemeyi Düzenle";
            this.editSelectedIngredientButton.UseVisualStyleBackColor = false;
            this.editSelectedIngredientButton.Click += new System.EventHandler(this.editSelectedIngredientButton_Click);
            // 
            // addIngredient
            // 
            this.addIngredient.BackColor = System.Drawing.Color.SkyBlue;
            this.addIngredient.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addIngredient.Location = new System.Drawing.Point(310, 656);
            this.addIngredient.Name = "addIngredient";
            this.addIngredient.Size = new System.Drawing.Size(259, 41);
            this.addIngredient.TabIndex = 8;
            this.addIngredient.Text = "Yeni Malzeme Ekle";
            this.addIngredient.UseVisualStyleBackColor = false;
            this.addIngredient.Click += new System.EventHandler(this.addIngredient_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(741, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 45);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tarifi Giriniz";
            // 
            // recipeTextBox
            // 
            this.recipeTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.recipeTextBox.Location = new System.Drawing.Point(644, 100);
            this.recipeTextBox.Name = "recipeTextBox";
            this.recipeTextBox.Size = new System.Drawing.Size(366, 440);
            this.recipeTextBox.TabIndex = 10;
            this.recipeTextBox.Text = "";
            this.recipeTextBox.TextChanged += new System.EventHandler(this.recipeTextBox_TextChanged);
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.BackColor = System.Drawing.Color.DarkTurquoise;
            this.addRecipeButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addRecipeButton.Location = new System.Drawing.Point(644, 656);
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
            this.totalPriceLabel.Location = new System.Drawing.Point(641, 546);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(313, 39);
            this.totalPriceLabel.TabIndex = 12;
            this.totalPriceLabel.Text = "Toplam Maliyet : 0 PLN";
            this.totalPriceLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // deleteSelectedIngredient
            // 
            this.deleteSelectedIngredient.BackColor = System.Drawing.Color.SkyBlue;
            this.deleteSelectedIngredient.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteSelectedIngredient.Location = new System.Drawing.Point(20, 597);
            this.deleteSelectedIngredient.Name = "deleteSelectedIngredient";
            this.deleteSelectedIngredient.Size = new System.Drawing.Size(259, 41);
            this.deleteSelectedIngredient.TabIndex = 13;
            this.deleteSelectedIngredient.Text = "Seçilen Malzemeyi Sil";
            this.deleteSelectedIngredient.UseVisualStyleBackColor = false;
            this.deleteSelectedIngredient.Click += new System.EventHandler(this.deleteSelectedIngredient_Click);
            // 
            // deleteAllIngredients
            // 
            this.deleteAllIngredients.BackColor = System.Drawing.Color.SkyBlue;
            this.deleteAllIngredients.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteAllIngredients.Location = new System.Drawing.Point(310, 597);
            this.deleteAllIngredients.Name = "deleteAllIngredients";
            this.deleteAllIngredients.Size = new System.Drawing.Size(259, 41);
            this.deleteAllIngredients.TabIndex = 14;
            this.deleteAllIngredients.Text = "Tüm Malzemeleri Sil";
            this.deleteAllIngredients.UseVisualStyleBackColor = false;
            // 
            // addRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(131)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(1034, 722);
            this.Controls.Add(this.deleteAllIngredients);
            this.Controls.Add(this.deleteSelectedIngredient);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.addRecipeButton);
            this.Controls.Add(this.recipeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addIngredient);
            this.Controls.Add(this.editSelectedIngredientButton);
            this.Controls.Add(this.ingredientsGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prepareTime);
            this.Controls.Add(this.categoryCbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recipeName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "addRecipeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarif Ekle";
            this.Load += new System.EventHandler(this.addRecipeForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addRecipeForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox recipeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox categoryCbox;
        private System.Windows.Forms.MaskedTextBox prepareTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ingredientsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToplamMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeBirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirimFiyat;
        private System.Windows.Forms.Button editSelectedIngredientButton;
        private System.Windows.Forms.Button addIngredient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox recipeTextBox;
        private System.Windows.Forms.Button addRecipeButton;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Button deleteSelectedIngredient;
        private System.Windows.Forms.Button deleteAllIngredients;
    }
}