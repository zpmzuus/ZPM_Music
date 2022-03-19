using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ZPM_Music
{
    public partial class FormLogin : Form
    {
        public string userLogin = "";
        private Dictionary<string, string> allUser = new Dictionary<string, string>();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            XmlDocument xml =new XmlDocument();
            xml.Load(Application.StartupPath + "\\UserInfo.xml");
            XmlNode sXmlNode = xml.SelectSingleNode("Users");
            XmlNode fXmlNode = sXmlNode.FirstChild;
            XmlNode lXmlNode = sXmlNode.LastChild;

            foreach(XmlNode xn in lXmlNode.ChildNodes)
            {
                allUser.Add(xn.FirstChild.InnerText, xn.LastChild.InnerText);
            }

            if (fXmlNode.HasChildNodes)
            {
                string isPwd = fXmlNode.Attributes["isPwd"].Value;
                string isLogin = fXmlNode.Attributes["isLogin"].Value;

                if (isPwd == "True")
                {
                    ucCheckBoxPwd.Checked = true;
                }

                if (isLogin == "True")
                {
                    ucCheckBoxAutoLogin.Checked = true;
                }

                XmlNode fU = fXmlNode.FirstChild;
                XmlNode sP = fXmlNode.LastChild;

                textBoxUser.InputText=fU.InnerText;
                ucTextBoxPwd.InputText=sP.InnerText;

                if (ucCheckBoxAutoLogin.Checked)
                {
                    userLogin = fU.InnerText;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void ucBtnLogin_BtnClick(object sender, EventArgs e)
        {
            string u = textBoxUser.InputText;
            string p = ucTextBoxPwd.InputText;

            if (string.IsNullOrEmpty(u))
            {
                MessageBox.Show("请输入账号");
                return;
            }

            if (string.IsNullOrEmpty(p))
            {
                MessageBox.Show("请输入密码");
                return;
            }

            if (allUser.Keys.Contains(u))
            {
                if (allUser[u] == p)
                {
                    if (ucCheckBoxPwd.Checked)
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(Application.StartupPath + "\\UserInfo.xml");
                        XmlNode sXmlNode = xml.SelectSingleNode("Users");
                        XmlNode fXmlNode = sXmlNode.FirstChild;
                        XmlNode lXmlNode = sXmlNode.LastChild;

                        foreach(XmlNode node in lXmlNode.ChildNodes)
                        {
                            if(node.FirstChild .InnerText == u)
                            {
                                node.Attributes["isPwd"].Value = "True";
                                break;
                            }
                        }

                        fXmlNode.Attributes["isPwd"].Value = "True";
                        fXmlNode.FirstChild.InnerText = u;
                        fXmlNode.LastChild.InnerText = p;

                        if (ucCheckBoxAutoLogin.Checked)
                        {                    
                            fXmlNode.Attributes["isLogin"].Value = "True";
                        }

                        xml.Save(Application.StartupPath + "\\UserInfo.xml");
                    }

                    userLogin = u;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("账号或密码错误");
                }
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }
        }

        private void ucBtnExtReg_BtnClick(object sender, EventArgs e)
        {
            string u = textBoxUser.InputText;
            string p = ucTextBoxPwd.InputText;

            if (string.IsNullOrEmpty(u))
            {
                MessageBox.Show("请输入账号");
                return;
            }

            if (string.IsNullOrEmpty(p))
            {
                MessageBox.Show("请输入密码");
                return;
            }

            if(allUser.Keys.Contains(u))
            {
                MessageBox.Show("已经存在此用户");
                return;
            }

            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "\\UserInfo.xml");
            XmlNode sXmlNode = xml.SelectSingleNode("Users");
            XmlNode lXmlNode = sXmlNode.LastChild;

            XmlElement element = xml.CreateElement("Users");
            XmlElement elementU = xml.CreateElement("ID"); elementU.InnerText = u;
            XmlElement elementP = xml.CreateElement("PWD"); elementP.InnerText = p;

            XmlAttribute iP = xml.CreateAttribute("isPwd");iP.Value = "False";
            XmlAttribute iL = xml.CreateAttribute("isLogin"); iL.Value = "False";

            element.SetAttributeNode(iP);
            element.SetAttributeNode(iL);

            element.AppendChild(elementU);
            element.AppendChild(elementP);

            lXmlNode.AppendChild(element);

            xml.Save(Application.StartupPath + "\\UserInfo.xml");

            allUser.Add(u, p);

            MessageBox.Show("注册成功");
        }

        private void ucCheckBoxPwd_CheckedChangeEvent(object sender, EventArgs e)
        {

        }

        private void ucCheckBoxAutoLogin_CheckedChangeEvent(object sender, EventArgs e)
        {
            if (ucCheckBoxAutoLogin.Checked)
            {
                if (!ucCheckBoxPwd.Checked)
                {
                    MessageBox.Show("请先选择记住账号密码");
                    ucCheckBoxAutoLogin.Checked = false;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool isClick = false;
        int mX = 0;
        int mY = 0;
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            isClick = true;
            mX = e.X;
            mY = e.Y;
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            isClick = false;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClick)
            {
                this.Location = new Point(Location.X + (e.X - mX), Location.Y + (e.Y - mY));
            }
        }
    }
}
