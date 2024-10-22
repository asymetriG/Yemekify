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
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.recipeEventsTimer = new System.Windows.Forms.Timer(this.components);
            this.depoIslemleriTimer = new System.Windows.Forms.Timer(this.components);
            this.sidePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.recipePanel = new System.Windows.Forms.Panel();
            this.removeRecipeButton = new System.Windows.Forms.Button();
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.recipeEventsButton = new System.Windows.Forms.Button();
            this.depotPanel = new System.Windows.Forms.Panel();
            this.removeIngredient = new System.Windows.Forms.Button();
            this.addIngredient = new System.Windows.Forms.Button();
            this.depotEvents = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.filterButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.recipesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.recipePanel.SuspendLayout();
            this.depotPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 15;
            // 
            // recipeEventsTimer
            // 
            this.recipeEventsTimer.Interval = 15;
            this.recipeEventsTimer.Tick += new System.EventHandler(this.recipeEventsTimer_Tick);
            // 
            // depoIslemleriTimer
            // 
            this.depoIslemleriTimer.Interval = 15;
            this.depoIslemleriTimer.Tick += new System.EventHandler(this.depoIslemleriTimer_Tick);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(96)))));
            this.sidePanel.Controls.Add(this.pictureBox1);
            this.sidePanel.Controls.Add(this.recipePanel);
            this.sidePanel.Controls.Add(this.depotPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(206, 679);
            this.sidePanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Yemekify.Properties.Resources.logo_no_background;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // recipePanel
            // 
            this.recipePanel.Controls.Add(this.removeRecipeButton);
            this.recipePanel.Controls.Add(this.addRecipeButton);
            this.recipePanel.Controls.Add(this.recipeEventsButton);
            this.recipePanel.Location = new System.Drawing.Point(3, 106);
            this.recipePanel.MaximumSize = new System.Drawing.Size(201, 174);
            this.recipePanel.MinimumSize = new System.Drawing.Size(201, 54);
            this.recipePanel.Name = "recipePanel";
            this.recipePanel.Size = new System.Drawing.Size(201, 54);
            this.recipePanel.TabIndex = 4;
            // 
            // removeRecipeButton
            // 
            this.removeRecipeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(96)))));
            this.removeRecipeButton.FlatAppearance.BorderSize = 0;
            this.removeRecipeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeRecipeButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.removeRecipeButton.ForeColor = System.Drawing.Color.Black;
            this.removeRecipeButton.Image = global::Yemekify.Properties.Resources.substrct__1_;
            this.removeRecipeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeRecipeButton.Location = new System.Drawing.Point(0, 109);
            this.removeRecipeButton.Name = "removeRecipeButton";
            this.removeRecipeButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.removeRecipeButton.Size = new System.Drawing.Size(201, 62);
            this.removeRecipeButton.TabIndex = 8;
            this.removeRecipeButton.Text = "          Tarif Çıkar";
            this.removeRecipeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeRecipeButton.UseVisualStyleBackColor = false;
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(96)))));
            this.addRecipeButton.FlatAppearance.BorderSize = 0;
            this.addRecipeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRecipeButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addRecipeButton.ForeColor = System.Drawing.Color.Black;
            this.addRecipeButton.Image = global::Yemekify.Properties.Resources.plusicon__1_;
            this.addRecipeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addRecipeButton.Location = new System.Drawing.Point(0, 56);
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.addRecipeButton.Size = new System.Drawing.Size(201, 62);
            this.addRecipeButton.TabIndex = 7;
            this.addRecipeButton.Text = "          Tarif Ekle";
            this.addRecipeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addRecipeButton.UseVisualStyleBackColor = false;
            this.addRecipeButton.Click += new System.EventHandler(this.addRecipeButton_Click);
            // 
            // recipeEventsButton
            // 
            this.recipeEventsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(96)))));
            this.recipeEventsButton.FlatAppearance.BorderSize = 0;
            this.recipeEventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recipeEventsButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.recipeEventsButton.ForeColor = System.Drawing.Color.Black;
            this.recipeEventsButton.Location = new System.Drawing.Point(0, 0);
            this.recipeEventsButton.Name = "recipeEventsButton";
            this.recipeEventsButton.Size = new System.Drawing.Size(201, 62);
            this.recipeEventsButton.TabIndex = 6;
            this.recipeEventsButton.Text = "Tarif İşlemleri";
            this.recipeEventsButton.UseVisualStyleBackColor = false;
            this.recipeEventsButton.Click += new System.EventHandler(this.recipeEventsButton_Click);
            // 
            // depotPanel
            // 
            this.depotPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(96)))));
            this.depotPanel.Controls.Add(this.removeIngredient);
            this.depotPanel.Controls.Add(this.addIngredient);
            this.depotPanel.Controls.Add(this.depotEvents);
            this.depotPanel.Location = new System.Drawing.Point(3, 166);
            this.depotPanel.MaximumSize = new System.Drawing.Size(201, 174);
            this.depotPanel.MinimumSize = new System.Drawing.Size(201, 54);
            this.depotPanel.Name = "depotPanel";
            this.depotPanel.Size = new System.Drawing.Size(201, 54);
            this.depotPanel.TabIndex = 5;
            // 
            // removeIngredient
            // 
            this.removeIngredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(96)))));
            this.removeIngredient.FlatAppearance.BorderSize = 0;
            this.removeIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeIngredient.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.removeIngredient.ForeColor = System.Drawing.Color.Black;
            this.removeIngredient.Image = global::Yemekify.Properties.Resources.substrct__1_;
            this.removeIngredient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeIngredient.Location = new System.Drawing.Point(0, 109);
            this.removeIngredient.Name = "removeIngredient";
            this.removeIngredient.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.removeIngredient.Size = new System.Drawing.Size(201, 62);
            this.removeIngredient.TabIndex = 8;
            this.removeIngredient.Text = "          Malzeme Çıkar";
            this.removeIngredient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeIngredient.UseVisualStyleBackColor = false;
            this.removeIngredient.Click += new System.EventHandler(this.removeIngredient_Click);
            // 
            // addIngredient
            // 
            this.addIngredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(96)))));
            this.addIngredient.FlatAppearance.BorderSize = 0;
            this.addIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addIngredient.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addIngredient.ForeColor = System.Drawing.Color.Black;
            this.addIngredient.Image = global::Yemekify.Properties.Resources.plusicon__1_;
            this.addIngredient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addIngredient.Location = new System.Drawing.Point(0, 56);
            this.addIngredient.Name = "addIngredient";
            this.addIngredient.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.addIngredient.Size = new System.Drawing.Size(201, 62);
            this.addIngredient.TabIndex = 7;
            this.addIngredient.Text = "          Malzeme Ekle";
            this.addIngredient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addIngredient.UseVisualStyleBackColor = false;
            this.addIngredient.Click += new System.EventHandler(this.addIngredient_Click);
            // 
            // depotEvents
            // 
            this.depotEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(96)))));
            this.depotEvents.FlatAppearance.BorderSize = 0;
            this.depotEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.depotEvents.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.depotEvents.ForeColor = System.Drawing.Color.Black;
            this.depotEvents.Location = new System.Drawing.Point(0, 0);
            this.depotEvents.Name = "depotEvents";
            this.depotEvents.Size = new System.Drawing.Size(201, 62);
            this.depotEvents.TabIndex = 6;
            this.depotEvents.Text = "Depo İşlemleri";
            this.depotEvents.UseVisualStyleBackColor = false;
            this.depotEvents.Click += new System.EventHandler(this.depotEvents_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(173)))));
            this.topPanel.Controls.Add(this.filterButton);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.searchButton);
            this.topPanel.Controls.Add(this.textBox1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.topPanel.Location = new System.Drawing.Point(206, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(767, 100);
            this.topPanel.TabIndex = 1;
            // 
            // filterButton
            // 
            this.filterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filterButton.Image = global::Yemekify.Properties.Resources.filter_26;
            this.filterButton.Location = new System.Drawing.Point(438, 33);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(33, 36);
            this.filterButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.filterButton.TabIndex = 2;
            this.filterButton.TabStop = false;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tarif Ara : ";
            // 
            // searchButton
            // 
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.Image = global::Yemekify.Properties.Resources.magnifier_26;
            this.searchButton.Location = new System.Drawing.Point(399, 33);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(33, 36);
            this.searchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.searchButton.TabIndex = 0;
            this.searchButton.TabStop = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Orange;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(163, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 37);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // recipesPanel
            // 
            this.recipesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipesPanel.Location = new System.Drawing.Point(206, 100);
            this.recipesPanel.Name = "recipesPanel";
            this.recipesPanel.Size = new System.Drawing.Size(767, 579);
            this.recipesPanel.TabIndex = 2;
            this.recipesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.recipesPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 679);
            this.Controls.Add(this.recipesPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.recipePanel.ResumeLayout(false);
            this.depotPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Timer sidebarTimer;
        private Timer recipeEventsTimer;
        private Timer depoIslemleriTimer;
        private FlowLayoutPanel sidePanel;
        private Panel topPanel;
        private PictureBox pictureBox1;
        private Panel recipePanel;
        private Button recipeEventsButton;
        private Button removeRecipeButton;
        private Button addRecipeButton;
        private Panel depotPanel;
        private Button removeIngredient;
        private Button addIngredient;
        private FlowLayoutPanel recipesPanel;
        private TextBox textBox1;
        private PictureBox searchButton;
        private Label label1;
        private PictureBox filterButton;
        private Button depotEvents;
    }
}

