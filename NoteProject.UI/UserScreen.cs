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
    public partial class UserScreen : Form
    {
        public UserScreen()
        {
            InitializeComponent();

        }

        public UserScreen(int Id)
        {
            InitializeComponent();

            this.Id = Id;
        }

        NoteRepository repository;
        UserRepository userRepository;
        int Id;
        private void UserScreen_Load(object sender, EventArgs e)
        {
            repository = new NoteRepository();
            userRepository = new UserRepository();

            Refresh();
        }
        List<Note> notes;
        public void Refresh()
        {

            notes = repository.GetUserNotesIncludingUnsaved(Id).ToList();

            lboxNotlar.DataSource = null;
            lboxNotlar.DataSource = notes;
            lboxNotlar.DisplayMember = "Title";
            lboxNotlar.ValueMember = "Id";


        }

        private void btnYeniNot_Click(object sender, EventArgs e)
        {
            Note note = new Note()
            {
                Title = txtBaslik.Text,
                Content = txtIcerik.Text,
                UserRefId = Id
            };

            repository.AddNote(note);
            Unselect();
            Refresh();
            ClearAll();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedItems.Count > 0)
            {
                Note note = (Note)lboxNotlar.SelectedItems[0];
                if (note.Title != txtBaslik.Text && note.Content != txtIcerik.Text && txtBaslik.Text != string.Empty && txtIcerik.Text != string.Empty) 
                {
                    Note note1 = repository.GetNoteById(note.Id);

                    if (note1 != null) 
                    {
                        note.Title = txtBaslik.Text;
                        note.Content = txtIcerik.Text;
                        note.UpdatedDate = DateTime.Now;
                        repository.UpdateNote(note);
                    }
                    
                }
            }
            repository.SaveAll();
            ClearAll();
            Unselect();
            Refresh();
        }

        private void btnNotSil_Click(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedItems.Count > 0)
            {
                Note note = (Note)lboxNotlar.SelectedItems[0];
                repository.DeleteNote(note.Id);
                if (repository.DeleteNote(note.Id) == false) 
                {
                    repository.DeleteLocalNote(note.Id);
                }
            }

            Unselect();
            Refresh();
        }

        private void linkSifreDegis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordChangeScreen pcs = new PasswordChangeScreen(Id);
            this.Hide();
            pcs.ShowDialog();
            this.Show();
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

        private void lboxNotlar_DoubleClick(object sender, EventArgs e)
        {
            if (lboxNotlar.SelectedItems.Count > 0)
            {
                Note note = (Note)lboxNotlar.SelectedItems[0];

                txtBaslik.Text = note.Title;
                txtIcerik.Text = note.Content;
            }
        }

        public void Unselect()
        {
            lboxNotlar.SelectedIndex = -1;
        }
    }
}
