using BlacksmithWorkshopBusinessLogic.BindingModels;
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
	public partial class FormGoods : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		public int Id { set { id = value; } }
		private readonly IGoodsLogic logic;
		private int? id;
		private Dictionary<int, (string, int)> GoodsBillets;

		public FormGoods(IGoodsLogic service)
		{
			InitializeComponent();
			this.logic = service;
		}

		private void FormGoods_Load(object sender, EventArgs e)
		{
			if (id.HasValue)
			{
				try
				{
					GoodsViewModel view = logic.Read(new GoodsBindingModel
					{
						Id = id.Value
					})?[0];
					if (view != null)
					{
						textBoxName.Text = view.GoodsName;
						textBoxPrice.Text = view.Price.ToString();
						GoodsBillets = view.GoodsBillets;
						LoadData();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				   MessageBoxIcon.Error);
				}
			}
			else
			{
				GoodsBillets = new Dictionary<int, (string, int)>();
			}
		}

		private void LoadData()
		{
			try
			{
				if (GoodsBillets != null)
				{
					dataGridView.Rows.Clear();
					foreach (var pc in GoodsBillets)
					{
						dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1,
pc.Value.Item2 });
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormGoodsBillets>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (GoodsBillets.ContainsKey(form.Id))
				{
					GoodsBillets[form.Id] = (form.BilletsName, form.Count);
				}
				else
				{
					GoodsBillets.Add(form.Id, (form.BilletsName, form.Count));
				}
				LoadData();
			}
		}

		private void ButtonUpd_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var form = Container.Resolve<FormGoodsBillets>();
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				form.Id = id;
				form.Count = GoodsBillets[id].Item2;
				if (form.ShowDialog() == DialogResult.OK)
				{
					GoodsBillets[form.Id] = (form.BilletsName, form.Count);
					LoadData();
				}
			}
		}

		private void ButtonDel_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
			   MessageBoxIcon.Question) == DialogResult.Yes)
				{
					try
					{

						GoodsBillets.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					   MessageBoxIcon.Error);
					}
					LoadData();
				}
			}
		}

		private void ButtonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxName.Text))
			{
				MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(textBoxPrice.Text))
			{
				MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}
			if (GoodsBillets == null || GoodsBillets.Count == 0)
			{
				MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}
			try
			{
				logic.CreateOrUpdate(new GoodsBindingModel
				{
					Id = id,
					GoodsName = textBoxName.Text,
					Price = Convert.ToDecimal(textBoxPrice.Text),
					GoodsBillets = GoodsBillets
				});
				MessageBox.Show("Сохранение прошло успешно", "Сообщение",
			   MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
