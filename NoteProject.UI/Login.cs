using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        UserRepository userRepository;

        private void btnGiris_Click(object sender, EventArgs e)
        {
            userRepository = new UserRepository();

            string girilenUsername = string.Empty;
            string girilenPassword = string.Empty;

            girilenUsername = txtKullaniciAdi.Text;
            girilenPassword = txtSifre.Text;

            List<Kullanici> users = userRepository.GetUsersByUserName(girilenUsername);

            if (users.Count != 0)
            {
                Kullanici kullanici = users.FirstOrDefault(x => x.Password == girilenPassword);
                if (kullanici != null)
                {
                    if (kullanici.IsActive)
                    {
                        if (kullanici.UserName == "admin")
                        {
                            AdminScreen adminScreen = new AdminScreen();
                            this.Hide();
                            adminScreen.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            UserScreen screen = new UserScreen(kullanici.Id);
                            this.Hide();
                            screen.ShowDialog();
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı aktif değil.");
                    }

                }
                else
                {
                    MessageBox.Show("Yanlış şifre");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı mevcut değil.");
            }
        }

        private void linkKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInScreen signInScreen = new SignInScreen();
            this.Hide();
            signInScreen.ShowDialog();
            this.Show();
        }
    }
}
