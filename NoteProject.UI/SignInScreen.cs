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
    public partial class SignInScreen : Form
    {
        public SignInScreen()
        {
            InitializeComponent();
        }

        UserRepository userRepository;

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = userRepository.GetUserByUserName(txtKullaniciAdi.Text);
            if (kullanici != null) 
            {
                MessageBox.Show("Kullanıcı adı zaten mevcut.");
            }
            else
            {
                if (txtSifre.Text == txtSifreTekrar.Text) 
                {
                    try
                    {
                        Kullanici kullanici1 = new Kullanici()
                        {
                            FirstName = txtAd.Text,
                            LastName = txtSoyad.Text,
                            UserName = txtKullaniciAdi.Text,
                            Password = txtSifre.Text,
                            IsActive = false,
                            CreatedDate = DateTime.Now
                        };

                        userRepository.AddUser(kullanici1);
                        CleanAll();


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
        }

        private void SignInScreen_Load(object sender, EventArgs e)
        {
            userRepository = new UserRepository();
        }

        public void CleanAll()
        {
            foreach(Control control in this.Controls) 
            {
                if(control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }
        }
    }
}
