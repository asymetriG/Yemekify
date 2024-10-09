using System.Drawing;
using System.Windows.Forms;

namespace Yemekify
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.sidebarContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.tarifPanel = new System.Windows.Forms.Panel();
            this.deleteRecipeButton = new System.Windows.Forms.Button();
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.editRecipeButton = new System.Windows.Forms.Button();
            this.depotPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.tarifIslemleriTimer = new System.Windows.Forms.Timer(this.components);
            this.depotButton = new System.Windows.Forms.Button();
            this.addIngredientToDepot = new System.Windows.Forms.Button();
            this.viewIngredients = new System.Windows.Forms.Button();
            this.deleteIngredient = new System.Windows.Forms.Button();
            this.depoIslemleriTimer = new System.Windows.Forms.Timer(this.components);
            this.sidebarContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tarifPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.depotPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarContainer
            // 
            this.sidebarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sidebarContainer.Controls.Add(this.panel1);
            this.sidebarContainer.Controls.Add(this.tarifPanel);
            this.sidebarContainer.Controls.Add(this.panel3);
            this.sidebarContainer.Controls.Add(this.depotPanel);
            this.sidebarContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarContainer.Location = new System.Drawing.Point(0, 0);
            this.sidebarContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sidebarContainer.MaximumSize = new System.Drawing.Size(215, 479);
            this.sidebarContainer.MinimumSize = new System.Drawing.Size(54, 479);
            this.sidebarContainer.Name = "sidebarContainer";
            this.sidebarContainer.Size = new System.Drawing.Size(215, 479);
            this.sidebarContainer.TabIndex = 0;
            this.sidebarContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.sidebarContainer_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 101);
            this.panel1.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.button5.Location = new System.Drawing.Point(-2, 24);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(213, 52);
            this.button5.TabIndex = 1;
            this.button5.Text = " ≡       Menü";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tarifPanel
            // 
            this.tarifPanel.Controls.Add(this.deleteRecipeButton);
            this.tarifPanel.Controls.Add(this.addRecipeButton);
            this.tarifPanel.Controls.Add(this.panel2);
            this.tarifPanel.Controls.Add(this.editRecipeButton);
            this.tarifPanel.Location = new System.Drawing.Point(2, 107);
            this.tarifPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tarifPanel.MaximumSize = new System.Drawing.Size(213, 151);
            this.tarifPanel.MinimumSize = new System.Drawing.Size(213, 39);
            this.tarifPanel.Name = "tarifPanel";
            this.tarifPanel.Size = new System.Drawing.Size(213, 39);
            this.tarifPanel.TabIndex = 2;
            // 
            // deleteRecipeButton
            // 
            this.deleteRecipeButton.Location = new System.Drawing.Point(2, 114);
            this.deleteRecipeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleteRecipeButton.Name = "deleteRecipeButton";
            this.deleteRecipeButton.Size = new System.Drawing.Size(211, 35);
            this.deleteRecipeButton.TabIndex = 4;
            this.deleteRecipeButton.Text = "Tarif Sil";
            this.deleteRecipeButton.UseVisualStyleBackColor = true;
            this.deleteRecipeButton.Click += new System.EventHandler(this.deleteRecipeButton_Click);
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.Location = new System.Drawing.Point(2, 39);
            this.addRecipeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Size = new System.Drawing.Size(211, 34);
            this.addRecipeButton.TabIndex = 3;
            this.addRecipeButton.Text = "Tarif Ekle";
            this.addRecipeButton.UseVisualStyleBackColor = true;
            this.addRecipeButton.Click += new System.EventHandler(this.addRecipeButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 34);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-4, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tarif İşlemleri";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // editRecipeButton
            // 
            this.editRecipeButton.Location = new System.Drawing.Point(2, 76);
            this.editRecipeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editRecipeButton.Name = "editRecipeButton";
            this.editRecipeButton.Size = new System.Drawing.Size(211, 34);
            this.editRecipeButton.TabIndex = 4;
            this.editRecipeButton.Text = "Tarif Düzenle";
            this.editRecipeButton.UseVisualStyleBackColor = true;
            this.editRecipeButton.Click += new System.EventHandler(this.editRecipeButton_Click);
            // 
            // depotPanel
            // 
            this.depotPanel.Controls.Add(this.deleteIngredient);
            this.depotPanel.Controls.Add(this.viewIngredients);
            this.depotPanel.Controls.Add(this.addIngredientToDepot);
            this.depotPanel.Controls.Add(this.depotButton);
            this.depotPanel.Location = new System.Drawing.Point(2, 188);
            this.depotPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.depotPanel.MaximumSize = new System.Drawing.Size(211, 152);
            this.depotPanel.MinimumSize = new System.Drawing.Size(211, 38);
            this.depotPanel.Name = "depotPanel";
            this.depotPanel.Size = new System.Drawing.Size(211, 38);
            this.depotPanel.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(2, 150);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(213, 34);
            this.panel3.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Tarif Bulma Aracı";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 15;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // tarifIslemleriTimer
            // 
            this.tarifIslemleriTimer.Interval = 15;
            this.tarifIslemleriTimer.Tick += new System.EventHandler(this.tarifIslemleriTimer_Tick);
            // 
            // depotButton
            // 
            this.depotButton.BackColor = System.Drawing.Color.White;
            this.depotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.depotButton.Location = new System.Drawing.Point(-4, 2);
            this.depotButton.Margin = new System.Windows.Forms.Padding(2);
            this.depotButton.Name = "depotButton";
            this.depotButton.Size = new System.Drawing.Size(213, 34);
            this.depotButton.TabIndex = 3;
            this.depotButton.Text = "Depo İşlemleri";
            this.depotButton.UseVisualStyleBackColor = false;
            this.depotButton.Click += new System.EventHandler(this.depotButton_Click);
            // 
            // addIngredientToDepot
            // 
            this.addIngredientToDepot.BackColor = System.Drawing.Color.White;
            this.addIngredientToDepot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addIngredientToDepot.Location = new System.Drawing.Point(0, 40);
            this.addIngredientToDepot.Margin = new System.Windows.Forms.Padding(2);
            this.addIngredientToDepot.Name = "addIngredientToDepot";
            this.addIngredientToDepot.Size = new System.Drawing.Size(213, 34);
            this.addIngredientToDepot.TabIndex = 4;
            this.addIngredientToDepot.Text = "Depoya Malzeme Ekle";
            this.addIngredientToDepot.UseVisualStyleBackColor = false;
            this.addIngredientToDepot.Click += new System.EventHandler(this.addIngredientToDepot_Click);
            // 
            // viewIngredients
            // 
            this.viewIngredients.BackColor = System.Drawing.Color.White;
            this.viewIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewIngredients.Location = new System.Drawing.Point(0, 78);
            this.viewIngredients.Margin = new System.Windows.Forms.Padding(2);
            this.viewIngredients.Name = "viewIngredients";
            this.viewIngredients.Size = new System.Drawing.Size(213, 34);
            this.viewIngredients.TabIndex = 5;
            this.viewIngredients.Text = "Depoyaki Malzemeyi Görüntüle";
            this.viewIngredients.UseVisualStyleBackColor = false;
            this.viewIngredients.Click += new System.EventHandler(this.viewIngredients_Click);
            // 
            // deleteIngredient
            // 
            this.deleteIngredient.BackColor = System.Drawing.Color.White;
            this.deleteIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteIngredient.Location = new System.Drawing.Point(0, 116);
            this.deleteIngredient.Margin = new System.Windows.Forms.Padding(2);
            this.deleteIngredient.Name = "deleteIngredient";
            this.deleteIngredient.Size = new System.Drawing.Size(213, 34);
            this.deleteIngredient.TabIndex = 6;
            this.deleteIngredient.Text = "Depoyaki Malzemeyi Sil";
            this.deleteIngredient.UseVisualStyleBackColor = false;
            this.deleteIngredient.Click += new System.EventHandler(this.deleteIngredient_Click);
            // 
            // depoIslemleriTimer
            // 
            this.depoIslemleriTimer.Interval = 15;
            this.depoIslemleriTimer.Tick += new System.EventHandler(this.depoIslemleriTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 479);
            this.Controls.Add(this.sidebarContainer);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.sidebarContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tarifPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.depotPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel sidebarContainer;
        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Panel panel3;
        private Button button2;
        private Panel depotPanel;
        private Button button5;
        private Panel tarifPanel;
        private Button addRecipeButton;
        private Button deleteRecipeButton;
        private Button editRecipeButton;
        private Timer sidebarTimer;
        private Timer tarifIslemleriTimer;
        private Button addIngredientToDepot;
        private Button depotButton;
        private Button viewIngredients;
        private Button deleteIngredient;
        private Timer depoIslemleriTimer;
    }
}

