﻿namespace BlacksmithWorkshopView
{
	partial class FormMain
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
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.списокЗаготовокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.заготовкиПоТоварамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.buttonCreateOrder = new System.Windows.Forms.Button();
			this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
			this.buttonOrderReady = new System.Windows.Forms.Button();
			this.buttonPayOrder = new System.Windows.Forms.Button();
			this.buttonRef = new System.Windows.Forms.Button();
			this.menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(800, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// справочникиToolStripMenuItem
			// 
			this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.клиентыToolStripMenuItem});
			this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.справочникиToolStripMenuItem.Text = "Справочники";
			// 
			// компонентыToolStripMenuItem
			// 
			this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
			this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.компонентыToolStripMenuItem.Text = "Компоненты";
			this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
			// 
			// изделияToolStripMenuItem
			// 
			this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
			this.изделияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.изделияToolStripMenuItem.Text = "Изделия";
			this.изделияToolStripMenuItem.Click += new System.EventHandler(this.ИзделияToolStripMenuItem_Click);
			// 
			// клиентыToolStripMenuItem
			// 
			this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
			this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.клиентыToolStripMenuItem.Text = "Клиенты";
			this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
			// 
			// отчетыToolStripMenuItem
			// 
			this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокЗаготовокToolStripMenuItem,
            this.заготовкиПоТоварамToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
			this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
			this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.отчетыToolStripMenuItem.Text = "Отчеты";
			// 
			// списокЗаготовокToolStripMenuItem
			// 
			this.списокЗаготовокToolStripMenuItem.Name = "списокЗаготовокToolStripMenuItem";
			this.списокЗаготовокToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.списокЗаготовокToolStripMenuItem.Text = "Список заготовок";
			this.списокЗаготовокToolStripMenuItem.Click += new System.EventHandler(this.списокЗаготовокToolStripMenuItem_Click);
			// 
			// заготовкиПоТоварамToolStripMenuItem
			// 
			this.заготовкиПоТоварамToolStripMenuItem.Name = "заготовкиПоТоварамToolStripMenuItem";
			this.заготовкиПоТоварамToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.заготовкиПоТоварамToolStripMenuItem.Text = "Заготовки по товарам";
			this.заготовкиПоТоварамToolStripMenuItem.Click += new System.EventHandler(this.заготовкиПоТоварамToolStripMenuItem_Click);
			// 
			// списокЗаказовToolStripMenuItem
			// 
			this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
			this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
			this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(0, 28);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(633, 338);
			this.dataGridView.TabIndex = 1;
			// 
			// buttonCreateOrder
			// 
			this.buttonCreateOrder.Location = new System.Drawing.Point(639, 27);
			this.buttonCreateOrder.Name = "buttonCreateOrder";
			this.buttonCreateOrder.Size = new System.Drawing.Size(149, 23);
			this.buttonCreateOrder.TabIndex = 2;
			this.buttonCreateOrder.Text = "Создать заказ";
			this.buttonCreateOrder.UseVisualStyleBackColor = true;
			this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
			// 
			// buttonTakeOrderInWork
			// 
			this.buttonTakeOrderInWork.Location = new System.Drawing.Point(639, 56);
			this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
			this.buttonTakeOrderInWork.Size = new System.Drawing.Size(149, 23);
			this.buttonTakeOrderInWork.TabIndex = 3;
			this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
			this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
			this.buttonTakeOrderInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
			// 
			// buttonOrderReady
			// 
			this.buttonOrderReady.Location = new System.Drawing.Point(639, 85);
			this.buttonOrderReady.Name = "buttonOrderReady";
			this.buttonOrderReady.Size = new System.Drawing.Size(149, 23);
			this.buttonOrderReady.TabIndex = 4;
			this.buttonOrderReady.Text = "Заказ готов";
			this.buttonOrderReady.UseVisualStyleBackColor = true;
			this.buttonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
			// 
			// buttonPayOrder
			// 
			this.buttonPayOrder.Location = new System.Drawing.Point(639, 114);
			this.buttonPayOrder.Name = "buttonPayOrder";
			this.buttonPayOrder.Size = new System.Drawing.Size(149, 23);
			this.buttonPayOrder.TabIndex = 5;
			this.buttonPayOrder.Text = "Заказ оплачен";
			this.buttonPayOrder.UseVisualStyleBackColor = true;
			this.buttonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(639, 143);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(149, 23);
			this.buttonRef.TabIndex = 6;
			this.buttonRef.Text = "Обновить список";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonPayOrder);
			this.Controls.Add(this.buttonOrderReady);
			this.Controls.Add(this.buttonTakeOrderInWork);
			this.Controls.Add(this.buttonCreateOrder);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FormMain";
			this.Text = "Кузнечная мастерская";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button buttonCreateOrder;
		private System.Windows.Forms.Button buttonTakeOrderInWork;
		private System.Windows.Forms.Button buttonOrderReady;
		private System.Windows.Forms.Button buttonPayOrder;
		private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокЗаготовокToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem заготовкиПоТоварамToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
	}
}