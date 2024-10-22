namespace Yemekify
{
    partial class addIngredint
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
            this.ingredientTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedIngredientLabel = new System.Windows.Forms.Label();
            this.toBeAddedAmountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.addNewIngredientButton = new System.Windows.Forms.Button();
            this.ingredientsGridView = new System.Windows.Forms.DataGridView();
            this.MalzemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MalzemeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToplamMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MalzemeBirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirimFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(194, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Malzeme Ekle";
            // 
            // ingredientTextBox
            // 
            this.ingredientTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ingredientTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ingredientTextBox.Location = new System.Drawing.Point(162, 74);
            this.ingredientTextBox.Name = "ingredientTextBox";
            this.ingredientTextBox.Size = new System.Drawing.Size(396, 22);
            this.ingredientTextBox.TabIndex = 1;
            this.ingredientTextBox.TextChanged += new System.EventHandler(this.ingredientTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Malzeme Adı";
            // 
            // selectedIngredientLabel
            // 
            this.selectedIngredientLabel.AutoSize = true;
            this.selectedIngredientLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.selectedIngredientLabel.Location = new System.Drawing.Point(13, 329);
            this.selectedIngredientLabel.Name = "selectedIngredientLabel";
            this.selectedIngredientLabel.Size = new System.Drawing.Size(231, 21);
            this.selectedIngredientLabel.TabIndex = 4;
            this.selectedIngredientLabel.Text = "Seçilen Malzeme : Domates (Kg)";
            // 
            // toBeAddedAmountTextBox
            // 
            this.toBeAddedAmountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toBeAddedAmountTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toBeAddedAmountTextBox.Location = new System.Drawing.Point(162, 385);
            this.toBeAddedAmountTextBox.Name = "toBeAddedAmountTextBox";
            this.toBeAddedAmountTextBox.Size = new System.Drawing.Size(387, 22);
            this.toBeAddedAmountTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(13, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Eklenecek Miktar";
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(17, 437);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(532, 39);
            this.addIngredientButton.TabIndex = 7;
            this.addIngredientButton.Text = "Malzeme Ekle";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // addNewIngredientButton
            // 
            this.addNewIngredientButton.Location = new System.Drawing.Point(17, 482);
            this.addNewIngredientButton.Name = "addNewIngredientButton";
            this.addNewIngredientButton.Size = new System.Drawing.Size(532, 39);
            this.addNewIngredientButton.TabIndex = 8;
            this.addNewIngredientButton.Text = "Depoya Yeni Malzeme Ekle";
            this.addNewIngredientButton.UseVisualStyleBackColor = true;
            this.addNewIngredientButton.Click += new System.EventHandler(this.addNewIngredientButton_Click);
            // 
            // ingredientsGridView
            // 
            this.ingredientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MalzemeId,
            this.MalzemeAdi,
            this.ToplamMiktar,
            this.MalzemeBirim,
            this.BirimFiyat});
            this.ingredientsGridView.Location = new System.Drawing.Point(17, 123);
            this.ingredientsGridView.Name = "ingredientsGridView";
            this.ingredientsGridView.Size = new System.Drawing.Size(541, 187);
            this.ingredientsGridView.TabIndex = 9;
            this.ingredientsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientsGridView_CellContentClick);
            this.ingredientsGridView.SelectionChanged += new System.EventHandler(this.ingredientsGridView_SelectionChanged);
            // 
            // MalzemeId
            // 
            this.MalzemeId.HeaderText = "MalzemeId";
            this.MalzemeId.Name = "MalzemeId";
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
            // addIngredint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 539);
            this.Controls.Add(this.ingredientsGridView);
            this.Controls.Add(this.addNewIngredientButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toBeAddedAmountTextBox);
            this.Controls.Add(this.selectedIngredientLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ingredientTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "addIngredint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addIngredint";
            this.Load += new System.EventHandler(this.addIngredint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ingredientTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label selectedIngredientLabel;
        private System.Windows.Forms.TextBox toBeAddedAmountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addIngredientButton;
        private System.Windows.Forms.Button addNewIngredientButton;
        private System.Windows.Forms.DataGridView ingredientsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToplamMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeBirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirimFiyat;
    }
}