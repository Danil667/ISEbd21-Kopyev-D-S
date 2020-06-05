using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlacksmithWorkshopClientView
{
	public partial class FormCreateOrder : Form
	{
		public FormCreateOrder()
		{
			InitializeComponent();
		}
		private void FormCreateOrder_Load(object sender, EventArgs e)
		{
			try
			{
				comboBoxGoods.DisplayMember = "GoodsName";
				comboBoxGoods.ValueMember = "Id";
				comboBoxGoods.DataSource =
			   APIClient.GetRequest<List<GoodsViewModel>>("api/main/getGoodslist");
				comboBoxGoods.SelectedItem = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}
		private void CalcSum()
		{
			if (comboBoxGoods.SelectedValue != null &&
		   !string.IsNullOrEmpty(textBoxCount.Text))
			{
				try
				{
					int id = Convert.ToInt32(comboBoxGoods.SelectedValue);
					GoodsViewModel Goods =
					APIClient.GetRequest<GoodsViewModel>($"api/main/getGoods?GoodsId={id}");
					int count = Convert.ToInt32(textBoxCount.Text);
					textBoxSum.Text = (count * Goods.Price).ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				   MessageBoxIcon.Error);
				}
			}
		}
		private void TextBoxCount_TextChanged(object sender, EventArgs e)
		{
			CalcSum();
		}
		private void ComboBoxGoods_SelectedIndexChanged(object sender, EventArgs e)
		{
			CalcSum();
		}
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка",
			   MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxGoods.SelectedValue == null)
			{
				MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}
			try
			{
				APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
				{
					ClientId = Program.Client.Id,
					GoodsId = Convert.ToInt32(comboBoxGoods.SelectedValue),
					Count = Convert.ToInt32(textBoxCount.Text),
					Sum = Convert.ToDecimal(textBoxSum.Text)
				});
				MessageBox.Show("Заказ создан", "Сообщение", MessageBoxButtons.OK,
			   MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}
	}
}
