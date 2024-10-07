namespace Yemekify
{
    partial class addIngredientForm
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
            this.ingredientsCbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.addIngredientToRecipeButton = new System.Windows.Forms.Button();
            this.addNewIngredientRecipe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ingredientsCbox
            // 
            this.ingredientsCbox.FormattingEnabled = true;
            this.ingredientsCbox.Location = new System.Drawing.Point(13, 71);
            this.ingredientsCbox.Name = "ingredientsCbox";
            this.ingredientsCbox.Size = new System.Drawing.Size(266, 21);
            this.ingredientsCbox.TabIndex = 0;
            this.ingredientsCbox.SelectedIndexChanged += new System.EventHandler(this.ingredientsCbox_SelectedIndexChanged);
            this.ingredientsCbox.SelectedValueChanged += new System.EventHandler(this.ingredientsCbox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Malzeme Seçiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Miktar Belirleyiniz";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(222, 119);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(63, 13);
            this.amountLabel.TabIndex = 3;
            this.amountLabel.Text = "KİLOGRAM";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(107, 116);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(109, 20);
            this.amountTextBox.TabIndex = 4;
            // 
            // addIngredientToRecipeButton
            // 
            this.addIngredientToRecipeButton.Location = new System.Drawing.Point(16, 214);
            this.addIngredientToRecipeButton.Name = "addIngredientToRecipeButton";
            this.addIngredientToRecipeButton.Size = new System.Drawing.Size(263, 33);
            this.addIngredientToRecipeButton.TabIndex = 5;
            this.addIngredientToRecipeButton.Text = "Malzemeyi Tarife Ekle";
            this.addIngredientToRecipeButton.UseVisualStyleBackColor = true;
            this.addIngredientToRecipeButton.Click += new System.EventHandler(this.addIngredientToRecipeButton_Click);
            // 
            // addNewIngredientRecipe
            // 
            this.addNewIngredientRecipe.Location = new System.Drawing.Point(16, 156);
            this.addNewIngredientRecipe.Name = "addNewIngredientRecipe";
            this.addNewIngredientRecipe.Size = new System.Drawing.Size(263, 34);
            this.addNewIngredientRecipe.TabIndex = 6;
            this.addNewIngredientRecipe.Text = "Yeni Malzeme Ekle";
            this.addNewIngredientRecipe.UseVisualStyleBackColor = true;
            this.addNewIngredientRecipe.Click += new System.EventHandler(this.addNewIngredientRecipe_Click);
            // 
            // addIngredientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 274);
            this.Controls.Add(this.addNewIngredientRecipe);
            this.Controls.Add(this.addIngredientToRecipeButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ingredientsCbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "addIngredientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addIngredientForm";
            this.Load += new System.EventHandler(this.addIngredientForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addIngredientForm_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ingredientsCbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button addIngredientToRecipeButton;
        private System.Windows.Forms.Button addNewIngredientRecipe;
    }
}