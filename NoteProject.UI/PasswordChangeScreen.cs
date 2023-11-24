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
    public partial class PasswordChangeScreen : Form
    {
        public PasswordChangeScreen()
        {
            InitializeComponent();
        }
        public PasswordChangeScreen(int Id)
        {
            InitializeComponent();
            this.Id = Id;
        }
        int Id;
        UserRepository repository;
        private void PasswordChangeScreen_Load(object sender, EventArgs e)
        {
            repository = new UserRepository();
        }

        private void btnSifreDegis_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = repository.GetUserById(Id);
            if (kullanici.Password == txtEskiSifre.Text) 
            {
                if (txtYeniSifre.Text == txtYeniSifreTekrar.Text) 
                {
                    try
                    {
                        kullanici.Password = txtYeniSifre.Text;
                        kullanici.UpdatedDate = DateTime.Now;
                        repository.UpdateUser(kullanici);

                        ClearAll();
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor.");
                }
            }
            else
            {
                MessageBox.Show("Eski şifre yanlış.");
            }
        }

        public void ClearAll()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }
        }
    }
}
