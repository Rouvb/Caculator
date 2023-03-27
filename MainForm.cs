using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        bool fOp = false;
        string strOpType = "";
        bool fResult = false;
        double dNum1 = 0, dNum2 = 0, dResult = 0.0;

        private bool IsNumeric(string strValue)
        {
            bool fNumber = true;
            try
            {
                double dValue = double.Parse(strValue);
            }
            catch
            {
                MessageBox.Show("입력한 문자열을 수로 변환할 수 없습니다.");
                fNumber = false;
            }
            return fNumber;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (fOp || fResult)
            {
                lblResult.Text = "0.";
                fOp = false;
                fResult = false;
            }
            else
            {
                string sValue = lblResult.Text + ".";
                if ((IsNumeric(sValue))) lblResult.Text = sValue;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblResult.Text = (double.Parse(lblResult.Text) * (-1)).ToString();
        }

        private void btnInfixOperator_Click(object sender, EventArgs e)
        {
            Button infixOp = (Button)sender;
            dNum1 = double.Parse(lblResult.Text);
            fOp = true;
            strOpType = infixOp.Text;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            fResult = true;
            dNum2 = double.Parse(lblResult.Text);

            switch (strOpType)
            {
                case "+": dResult = dNum1 + dNum2; break;
                case "-": dResult = dNum1 - dNum2; break;
                case "*": dResult = dNum1 * dNum2; break;
                case "/":
                    if (dNum2 != 0.0)
                    {
                        dResult = dNum1 / dNum2;
                    }
                    else
                    {
                        MessageBox.Show("0으로 나눌 수 없습니다.");

                        fOp = true;
                        fResult = false;
                        return;
                    }
                    break;
                case "%":
                    if (dNum2 != 0.0)
                    {
                        dResult = dNum1 % dNum2;
                    }
                    else
                    {
                        MessageBox.Show("0으로 나눌 수 없습니다.");
                        fOp = true;
                        fResult = false;
                        return;
                    }
                    break;
            }
            strOpType = "";
            lblResult.Text = dResult.ToString();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            lblResult.Text = Math.Sqrt(double.Parse(lblResult.Text)).ToString();
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            if (double.Parse(lblResult.Text) != 0.0)
            {
                lblResult.Text = (1 / (double.Parse(lblResult.Text))).ToString();
            }
            else
            {
                MessageBox.Show("0은 역수를 취할 수 없습니다.");

                return;
            }
        }

        private void btnBs_Click(object sender, EventArgs e)
        {
            if (lblResult.Text.Length == 1)
                lblResult.Text = "0";
            else
                lblResult.Text = lblResult.Text.Substring(0, lblResult.Text.Length - 1);
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            dNum1 = dNum2 = dResult = 0;
            fOp = false;
            strOpType = "";
            fResult = false;
        }

        private void btnNumeric_Click(string btnInputText)
        {
            if (lblResult.Text == "0" || fOp == true)
            {
                lblResult.Text = btnInputText;
                fOp = false;
            }
            else
            {
                string sValue = lblResult.Text + btnInputText;
                if (IsNumeric(sValue)) lblResult.Text = sValue;
            }
        }

        private void btnn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblResult.Text == "0" || fOp == true || fResult == true)
            {
                lblResult.Text = btn.Text;
                fOp = false;
                fResult = false;
            }
            else
            {
                string sValue = lblResult.Text + btn.Text;
                if (IsNumeric(sValue)) lblResult.Text = sValue;
            }
        }
    }
}
