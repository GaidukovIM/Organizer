using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class WindowAddNote : Form
    {
        public Note Notenew;
        public DateTime chosenTime;
        public WindowAddNote()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            chosenTime = dateTimePicker1.Value;
            Notenew = new Note(textBoxName.Text, (prioritylevel)comboBoxPriority.SelectedIndex, textBoxMainInf.Text,dateTimePicker1.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
