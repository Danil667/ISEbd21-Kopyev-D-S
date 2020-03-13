namespace BlacksmithWorkshopView
{
	partial class FormCreateOrder
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
			this.comboBoxProduct = new System.Windows.Forms.ComboBox();
			this.labelProduct = new System.Windows.Forms.Label();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.textBoxSum = new System.Windows.Forms.TextBox();
			this.labelCount = new System.Windows.Forms.Label();
			this.labelSum = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBoxProduct
			// 
			this.comboBoxProduct.FormattingEnabled = true;
			this.comboBoxProduct.Location = new System.Drawing.Point(86, 39);
			this.comboBoxProduct.Name = "comboBoxProduct";
			this.comboBoxProduct.Size = new System.Drawing.Size(121, 21);
			this.comboBoxProduct.TabIndex = 0;
			this.comboBoxProduct.Click += new System.EventHandler(this.FormCreateOrder_Load);
			// 
			// labelProduct
			// 
			this.labelProduct.AutoSize = true;
			this.labelProduct.Location = new System.Drawing.Point(13, 39);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(51, 13);
			this.labelProduct.TabIndex = 1;
			this.labelProduct.Text = "Изделие";
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(86, 67);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(121, 20);
			this.textBoxCount.TabIndex = 2;
			this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
			// 
			// textBoxSum
			// 
			this.textBoxSum.Location = new System.Drawing.Point(86, 94);
			this.textBoxSum.Name = "textBoxSum";
			this.textBoxSum.Size = new System.Drawing.Size(121, 20);
			this.textBoxSum.TabIndex = 3;
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(13, 67);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(66, 13);
			this.labelCount.TabIndex = 4;
			this.labelCount.Text = "Количество";
			// 
			// labelSum
			// 
			this.labelSum.AutoSize = true;
			this.labelSum.Location = new System.Drawing.Point(13, 94);
			this.labelSum.Name = "labelSum";
			this.labelSum.Size = new System.Drawing.Size(41, 13);
			this.labelSum.TabIndex = 5;
			this.labelSum.Text = "Сумма";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(132, 120);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(51, 120);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 7;
			this.buttonSave.Text = "сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// FormCreateOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelSum);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.textBoxSum);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.labelProduct);
			this.Controls.Add(this.comboBoxProduct);
			this.Name = "FormCreateOrder";
			this.Text = "Создание заказа";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxProduct;
		private System.Windows.Forms.Label labelProduct;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.TextBox textBoxSum;
		private System.Windows.Forms.Label labelCount;
		private System.Windows.Forms.Label labelSum;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
	}
}