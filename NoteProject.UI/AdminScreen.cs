using NoteProject.Repositories.Repositories;
using NoteProjectDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteProject.UI
{
    public partial class AdminScreen : Form
    {
        public AdminScreen()
        {
            InitializeComponent();
        }

        UserRepository repository;
        private void AdminScreen_Load(object sender, EventArgs e)
        {
            repository = new UserRepository();

            Refresh();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDurum_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                Kullanici k = repository.GetUserById((int)lvi.Tag);
                if (k.UserName != "admin")
                {
                    if (k.IsActive)
                    {
                        k.IsActive = false;
                        repository.UpdateUser(k);
                    }
                    else
                    {
                        k.IsActive = true;
                        repository.UpdateUser(k);
                    }
                }
                else
                {
                    MessageBox.Show("Admin durumu değiştirilemez.");
                }
                

                Refresh();
            }
        }

        public void Refresh()
        {
            listView1.Items.Clear();
            List<Kullanici> kullanicilar = repository.GetUsers();

            foreach (Kullanici k in kullanicilar)
            {
                string[] data = { k.FirstName, k.LastName, k.UserName, k.IsActive ? "Aktif" : "Pasif" };
                ListViewItem lvi = new ListViewItem(data);
                lvi.Tag = k.Id;
                listView1.Items.Add(lvi);
            }
        }
    }
}
