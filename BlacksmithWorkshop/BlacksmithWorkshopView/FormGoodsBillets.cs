using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BlacksmithWorkshopView
{
	public partial class FormGoodsBillets : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		public int Id
		{
			get { return Convert.ToInt32(comboBoxBillets.SelectedValue); }
			set { comboBoxBillets.SelectedValue = value; }
		}
		public string BilletsName { get { return comboBoxBillets.Text; } }
		public int Count
		{
			get { return Convert.ToInt32(textBoxCount.Text); }
			set
			{
				textBoxCount.Text = value.ToString();
			}
		}

		public FormGoodsBillets(IBilletsLogic logic)
		{
			InitializeComponent();
			List<BilletsViewModel> list = logic.Read(null);
			if (list != null)
			{
				comboBoxBillets.DisplayMember = "BilletsName";
				comboBoxBillets.ValueMember = "Id";
				comboBoxBillets.DataSource = list;
				comboBoxBillets.SelectedItem = null;
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка",
			   MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxBillets.SelectedValue == null)
			{
				MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
