namespace BlacksmithWorkshopView
{
	partial class FormGoodsBillets
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
			this.comboBoxBillets = new System.Windows.Forms.ComboBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// comboBoxBillets
			// 
			this.comboBoxBillets.FormattingEnabled = true;
			this.comboBoxBillets.Location = new System.Drawing.Point(74, 48);
			this.comboBoxBillets.Name = "comboBoxBillets";
			this.comboBoxBillets.Size = new System.Drawing.Size(232, 21);
			this.comboBoxBillets.TabIndex = 0;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(150, 116);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(231, 116);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(74, 90);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(232, 20);
			this.textBoxCount.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "компонент";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "количество";
			// 
			// FormBilletsGoods
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.comboBoxBillets);
			this.Name = "FormBilletsGoods";
			this.Text = "заготовки товара";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxBillets;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}