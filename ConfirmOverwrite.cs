using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SceneryobjectConversionUtility
{
    public partial class ConfirmOverwrite : Form
    {

        private Form1 form1;

        public ConfirmOverwrite(Form1 callingForm)
        {
            InitializeComponent();
            form1 = callingForm;
            this.exists_cmb_behaviour.SelectedIndex = 0;
        }
        private void exists_btn_cancel_click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void exists_btn_continue_click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void exists_cmb_behaviour_selectedIndexChanged(object sender, EventArgs e)
        {
            form1.existsBehaviour = exists_cmb_behaviour.SelectedIndex;
        }
    }
}
