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
			this.labelClient = new System.Windows.Forms.Label();
			this.comboBoxClient = new System.Windows.Forms.ComboBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBoxProduct
			// 
			this.comboBoxProduct.FormattingEnabled = true;
			this.comboBoxProduct.Location = new System.Drawing.Point(106, 26);
			this.comboBoxProduct.Name = "comboBoxProduct";
			this.comboBoxProduct.Size = new System.Drawing.Size(121, 21);
			this.comboBoxProduct.TabIndex = 0;
			this.comboBoxProduct.Click += new System.EventHandler(this.FormCreateOrder_Load);
			// 
			// labelProduct
			// 
			this.labelProduct.AutoSize = true;
			this.labelProduct.Location = new System.Drawing.Point(36, 26);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(51, 13);
			this.labelProduct.TabIndex = 1;
			this.labelProduct.Text = "Изделие";
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(106, 80);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(121, 20);
			this.textBoxCount.TabIndex = 2;
			this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
			// 
			// textBoxSum
			// 
			this.textBoxSum.Location = new System.Drawing.Point(106, 108);
			this.textBoxSum.Name = "textBoxSum";
			this.textBoxSum.Size = new System.Drawing.Size(121, 20);
			this.textBoxSum.TabIndex = 3;
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(36, 80);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(66, 13);
			this.labelCount.TabIndex = 4;
			this.labelCount.Text = "Количество";
			// 
			// labelSum
			// 
			this.labelSum.AutoSize = true;
			this.labelSum.Location = new System.Drawing.Point(36, 108);
			this.labelSum.Name = "labelSum";
			this.labelSum.Size = new System.Drawing.Size(41, 13);
			this.labelSum.TabIndex = 5;
			this.labelSum.Text = "Сумма";
			// 
			// labelClient
			// 
			this.labelClient.AutoSize = true;
			this.labelClient.Location = new System.Drawing.Point(36, 54);
			this.labelClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelClient.Name = "labelClient";
			this.labelClient.Size = new System.Drawing.Size(43, 13);
			this.labelClient.TabIndex = 15;
			this.labelClient.Text = "Клиент";
			// 
			// comboBoxClient
			// 
			this.comboBoxClient.FormattingEnabled = true;
			this.comboBoxClient.Location = new System.Drawing.Point(106, 51);
			this.comboBoxClient.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxClient.Name = "comboBoxClient";
			this.comboBoxClient.Size = new System.Drawing.Size(121, 21);
			this.comboBoxClient.TabIndex = 16;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(273, 147);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(184, 147);
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
			this.ClientSize = new System.Drawing.Size(422, 242);
			this.Controls.Add(this.comboBoxClient);
			this.Controls.Add(this.labelClient);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelSum);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.textBoxSum);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.labelProduct);
			this.Controls.Add(this.comboBoxProduct);
			this.Name = "FormCreateOrder";
			this.Text = "Создать заказ";
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
		private System.Windows.Forms.Label labelClient;
		private System.Windows.Forms.ComboBox comboBoxClient;
	}
}