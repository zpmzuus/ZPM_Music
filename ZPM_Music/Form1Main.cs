using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace ZPM_Music
{
    public partial class Form1Main : Form
    {
        #region init variable
        public string user { get; set; }
        private Dictionary<string, string> musicPlay = new Dictionary<string, string>();
        private Dictionary<string, string> musicHis = new Dictionary<string, string>();
        Button beforeAddBtn = null;
        private string playHis = "";
        private bool isGrid = false;
        private bool isPlay = false;
        private enum DATA{
            MUSIC_NAME,
            PATH,
            IMAGE,
            NAME,
            DURATION,
            PLAY,
            ADD
        }

        private enum PLAYDATA
        {
            PLAY,
            NAME,
            URL,
            IMAGE,
            TIME,
            DELETE,
        }
        #endregion

        public Form1Main()
        {
            InitializeComponent();
        }

        #region form load
        private void Form1Main_Load(object sender, EventArgs e)
        {
            musicPlay.Clear();
            musicHis.Clear();
            labelUser.Text = user;
            InitDgv();
            timerPlay.Stop();
            axWindowsMediaPlayer1.settings.volume = (int)ucTrackBarVoice.Value;

            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "\\MusicInfo.xml");
            XmlNode xmlNode = xml.SelectSingleNode("Music");

            bool hasUser=false;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Attributes["ID"].Value == user)
                {
                    XmlNode xmlNodeP = node.SelectSingleNode("MusicPlay");
                    XmlNode xmlNodeH = node.SelectSingleNode("MusicHis");

                    foreach (XmlNode xmlNode1 in xmlNodeP.ChildNodes)
                    {
                        musicPlay.Add(xmlNode1.FirstChild.InnerText, xmlNode1.LastChild.InnerText);
                    }

                    foreach (XmlNode xmlNode1 in xmlNodeH.ChildNodes)
                    {
                        musicHis.Add(xmlNode1.FirstChild.InnerText, xmlNode1.LastChild.InnerText);
                    }

                    DataTable dt = new DataTable();
                    foreach (string s in Enum.GetNames(typeof(PLAYDATA)))
                    {
                        if (s == "DELETE")
                        {
                            dt.Columns.Add(s, typeof(Image));
                        }
                        else
                        {
                            dt.Columns.Add(s);
                        }
                    }

                    foreach (string key in musicPlay.Keys)
                    {
                        string[] mu = musicPlay[key].Split('✄');
                        dt.Rows.Add(null, key.Replace("✄", " - "), mu[0], mu[1], mu[2], Properties.Resources.删除__1_);
                    }

                    dataGridViewPlayl.DataSource = dt;

                    DataTable dt1 = new DataTable();
                    foreach (string s in Enum.GetNames(typeof(PLAYDATA)))
                    {
                        if (s == "DELETE")
                        {
                            dt1.Columns.Add(s, typeof(Image));
                        }
                        else
                        {
                            dt1.Columns.Add(s);
                        }
                    }

                    foreach (string key in musicHis.Keys)
                    {
                        string[] mu = musicHis[key].Split('✄');
                        dt1.Rows.Add(null, key.Replace("✄", " - "), mu[0], mu[1], mu[2], Properties.Resources.删除__1_);
                    }

                    dataGridViewHIS.DataSource = dt1;

                    dataGridViewPlayl.ClearSelection();
                    dataGridViewHIS.ClearSelection();

                    hasUser = true;
                    break;
                }
            }

            if (!hasUser)
            {
                XmlElement element = xml.CreateElement("User");
                XmlElement elementp = xml.CreateElement("MusicPlay");
                XmlElement elementh = xml.CreateElement("MusicHis");

                element.AppendChild(elementp);
                element.AppendChild(elementh);

                XmlAttribute attribute = xml.CreateAttribute("ID"); attribute.Value = user;
                element.SetAttributeNode(attribute);
                xmlNode.AppendChild(element);

                xml.Save(Application.StartupPath + "\\MusicInfo.xml");
            }
        }

        private void InitDgv()
        {
            dgvMusic.DataSource = null;
            dgvMusic.Columns.Clear();

            dgvMusic.setDGVColumns("歌曲名", DATA.MUSIC_NAME.ToString(), DataGridViewContentAlignment.MiddleLeft, true, true, 500);
            dgvMusic.setDGVColumns("歌曲名", DATA.PATH.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 300);
            dgvMusic.setDGVColumns("歌曲名", DATA.IMAGE.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 300);
            dgvMusic.setDGVColumns("歌手", DATA.NAME.ToString(), DataGridViewContentAlignment.MiddleLeft, true, true, 120);
            dgvMusic.setDGVColumns("dur", DATA.DURATION.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 120);
            dgvMusic.setDGVColumns("播放", DATA.PLAY.ToString(), DataGridViewContentAlignment.MiddleCenter, true, true, 50,new DataGridViewImageColumn());
            dgvMusic.setDGVColumns("添加", DATA.ADD.ToString(), DataGridViewContentAlignment.MiddleCenter, true, true, 50, new DataGridViewImageColumn());

            dgvMusic.setDGVStyle(Color.White);
            dgvMusic.setDoubleBufferedDataGirdView(true);

            dataGridViewPlayl.DataSource = null;
            dataGridViewPlayl.Columns.Clear();

            dataGridViewPlayl.setDGVColumns("播放", PLAYDATA.PLAY.ToString(), DataGridViewContentAlignment.MiddleLeft, true, true, 20);
            dataGridViewPlayl.setDGVColumns("歌曲名", PLAYDATA.NAME.ToString(), DataGridViewContentAlignment.MiddleLeft, true, true, 250);
            dataGridViewPlayl.setDGVColumns("ur", PLAYDATA.URL.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 300);
            dataGridViewPlayl.setDGVColumns("im", PLAYDATA.IMAGE.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 120);
            dataGridViewPlayl.setDGVColumns("im", PLAYDATA.TIME.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 120);
            dataGridViewPlayl.setDGVColumns("del", PLAYDATA.DELETE.ToString(), DataGridViewContentAlignment.MiddleLeft, true, true, 30, new DataGridViewImageColumn());

            dataGridViewPlayl.setDGVStyle(Color.White);
            dataGridViewPlayl.setDoubleBufferedDataGirdView(true);

            dataGridViewHIS.DataSource = null;
            dataGridViewHIS.Columns.Clear();

            dataGridViewHIS.setDGVColumns("播放", PLAYDATA.PLAY.ToString(), DataGridViewContentAlignment.MiddleLeft, true, true, 20);
            dataGridViewHIS.setDGVColumns("歌曲名", PLAYDATA.NAME.ToString(), DataGridViewContentAlignment.MiddleLeft, true, true, 250);
            dataGridViewHIS.setDGVColumns("ur", PLAYDATA.URL.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 300);
            dataGridViewHIS.setDGVColumns("im", PLAYDATA.IMAGE.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 120);
            dataGridViewHIS.setDGVColumns("im", PLAYDATA.TIME.ToString(), DataGridViewContentAlignment.MiddleLeft, false, true, 120);
            dataGridViewHIS.setDGVColumns("del", PLAYDATA.DELETE.ToString(), DataGridViewContentAlignment.MiddleLeft, true, true, 30, new DataGridViewImageColumn());
            
            dataGridViewHIS.setDGVStyle(Color.White);
            dataGridViewHIS.setDoubleBufferedDataGirdView(true);
        }
        #endregion

        #region search songs
        private void buttonSearch_Click(object sender, EventArgs e)
        {          
            if (string.IsNullOrEmpty(textBoxName.InputText))
            {
                MessageBox.Show("输入歌曲名");
                return;
            }

            isGrid = true;

            string songName = Get(string.Format("http://search.kuwo.cn/r.s?{0}={1}&ft=music&rformat=json&encoding=utf8&rn=30&callback=song&vipver=MUSIC_8.0.3.1", "SONGNAME", textBoxName.InputText.Trim()));
            string aName = Get(string.Format("http://search.kuwo.cn/r.s?{0}={1}&ft=music&rformat=json&encoding=utf8&rn=30&callback=song&vipver=MUSIC_8.0.3.1", "ARTIST", textBoxName.InputText.Trim()));

            if (string.IsNullOrEmpty(songName) && string.IsNullOrEmpty(aName)) {
                MessageBox.Show("没有查询到数据");
                return;
            }

            string[] ss = new string[] {songName,aName };
            DataTable dt = new DataTable();

            foreach (string @enum in Enum.GetNames(typeof(DATA)))
            {
                if (@enum == "PLAY" || @enum == "ADD")
                {
                    dt.Columns.Add(@enum, typeof(Image));
                }
                else
                {
                    dt.Columns.Add(@enum);
                }
            }

            foreach (string s in ss)
            {
                string a = s.Substring(s.IndexOf("jsondata={") + 9);
                a = a.Substring(0, a.IndexOf("}]}") + 3);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(a);
                object[] firstKey = (object[])json["abslist"];

                foreach (var i in firstKey)
                {
                    Dictionary<string, object> y = (Dictionary<string, object>)i;
                    string song = y["SONGNAME"].ToString();
                    string path = "http://antiserver.kuwo.cn/anti.s?response=url&type=convert_url&br=320kmp3&format=mp3&rid=" + y["MUSICRID"].ToString();//hts_MVPIC

                    string image = "";
                    if (y.ContainsKey("hts_MVPIC"))
                        image = y["hts_MVPIC"].ToString();

                    string name = y["ARTIST"].ToString();
                    string during = y["DURATION"].ToString();
                    //http://antiserver.kuwo.cn/anti.s?response=url&type=convert_url&br=320kmp3&format=mp3&rid=MUSIC_324244
                    dt.Rows.Add(song, path, image, name, during, Properties.Resources.播放器__1_, Properties.Resources.添加__1_);
                }
            }

            dgvMusic.DataSource = dt;

            dgvMusic.ClearSelection();
        }

        public static string Get(string Url)
        {
            //System.GC.Collect();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = Get("http://antiserver.kuwo.cn/anti.s?response=url&type=convert_url&br=320kmp3&format=mp3&rid=MUSIC_324244");

            axWindowsMediaPlayer1.URL = a;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            timerPlay.Start();

        }
        #endregion

        #region monitor song state
        string allTime = "";
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.openState == WMPLib.WMPOpenState.wmposMediaOpen)
            {
                allTime = axWindowsMediaPlayer1.currentMedia.durationString;
                labelTime.Text = "00:00/" + allTime;

            }
        }

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            ucTrackBarPrcss.Value = (float)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            labelTime.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString + "/" + allTime;

            Console.WriteLine(ucTrackBarPrcss.Value + "=" + ucTrackBarPrcss.MaxValue);
            if (ucTrackBarPrcss.Value == ucTrackBarPrcss.MaxValue-1)
            {
                buttonPlay.BackgroundImage = Properties.Resources.播放;
                buttonPlay.Tag = "播放";
                if (radioButtonSeq.Checked)
                {
                    if (isGrid)
                    {
                        GetMusic(dgvMusic, isGrid);
                    }
                    else
                    {
                        if (playHis == "lb")
                        {
                            GetMusic(dataGridViewPlayl, false);
                        }
                        else
                        {
                            GetMusic(dataGridViewHIS, false);
                        }
                    }
                }
                else
                {
                    
                }
            }
        }

        private void ucTrackBarPrcss_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = ucTrackBarPrcss.Value;
        }
        #endregion

        #region 公用下一首歌曲获取功能
        private void GetMusic(DataGridView gridView, bool isGrid)
        {
            int activeRow = gridView.SelectedRows[0].Index;
            gridView.Rows[activeRow].Selected = false;

            if (!isGrid)
            {
                gridView.Rows[activeRow].Cells[(int)PLAYDATA.PLAY].Value = "";
            }

            if (activeRow == gridView.Rows.Count - 1)
            {
                activeRow = 0;
            }
            else
            {
                activeRow++;
            }

            gridView.Rows[activeRow].Selected = true;

            string song = "";
            string name = "";
            string during = "";
            string a = "";
            string im = "";

            string sn = "";

            if (isGrid)
            {
                song = gridView.Rows[activeRow].Cells[(int)DATA.MUSIC_NAME].Value.ToString();
                name = gridView.Rows[activeRow].Cells[(int)DATA.NAME].Value.ToString();
                during = gridView.Rows[activeRow].Cells[(int)DATA.DURATION].Value.ToString();

                a = gridView.Rows[activeRow].Cells[(int)DATA.PATH].Value.ToString();
                im = gridView.Rows[activeRow].Cells[(int)DATA.IMAGE].Value.ToString();

                sn = song + " - " + name;
            }
            else
            {
                gridView.Rows[activeRow].Cells[(int)PLAYDATA.PLAY].Value = "💽";

                sn = gridView.Rows[activeRow].Cells[(int)PLAYDATA.NAME].Value.ToString();

                string[] ss = sn.Split('-');
                song = ss[0].Trim();
                name = ss[1].Trim();
                during = gridView.Rows[activeRow].Cells[(int)PLAYDATA.TIME].Value.ToString();

                a = gridView.Rows[activeRow].Cells[(int)PLAYDATA.URL].Value.ToString();
                im = gridView.Rows[activeRow].Cells[(int)PLAYDATA.IMAGE].Value.ToString();
            }

            if (!musicHis.ContainsKey(song + "✄" + name))
            {
                AddMusic(song + "✄" + name, a + "✄" + im + "✄" + during, "His", "MusicHis");
                musicHis.Add(song + "✄" + name, a + "✄" + im);

                if (!isGrid)
                {
                    DataTable dataTable = (DataTable)dataGridViewHIS.DataSource;
                    dataTable.Rows.Add("", song + " - " + name, a, im, during, Properties.Resources.删除__1_);
                    dataGridViewHIS.DataSource = dataTable;
                }
            }

            ucTrackBarPrcss.Value = 0;
            ucTrackBarPrcss.MaxValue = int.Parse(during);

            labelsn.Text = sn;
            PlayMusic(a, im);
            buttonPlay.BackgroundImage = Properties.Resources.播放_暂停;
            buttonPlay.Tag = "暂停";
        }
        #endregion

        #region 搜索歌曲列表 点击播放
        private void dgvMusic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == (int)DATA.PLAY)
            {
                string song = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.MUSIC_NAME].Value.ToString();
                string name = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.NAME].Value.ToString();
                string during = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.DURATION].Value.ToString();

                string a = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.PATH].Value.ToString();
                string im = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.IMAGE].Value.ToString();

                if (!musicHis.ContainsKey(song + "✄" + name))
                {
                    AddMusic(song + "✄" + name, a + "✄" + im + "✄" + during, "His", "MusicHis");
                    musicHis.Add(song + "✄" + name, a + "✄" + im + "✄" + during);
                    DataTable dataTable = (DataTable)dataGridViewHIS.DataSource;
                    dataTable.Rows.Add("", song + " - " + name, a, im, during, Properties.Resources.删除__1_);
                    dataGridViewHIS.DataSource = dataTable;
                }

                ucTrackBarPrcss.MaxValue = int.Parse(during);

                labelsn.Text = song + " - " + name;
                PlayMusic(a, im);

                isPlay = true;
                buttonPlay.BackgroundImage = Properties.Resources.播放_暂停;
                buttonPlay.Tag = "暂停";
            }
            else if (e.RowIndex > -1 && e.ColumnIndex == (int)DATA.ADD)
            {
                string song = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.MUSIC_NAME].Value.ToString();
                string name = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.NAME].Value.ToString();
                string during = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.DURATION].Value.ToString();

                string a = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.PATH].Value.ToString();
                string im = dgvMusic.Rows[e.RowIndex].Cells[(int)DATA.IMAGE].Value.ToString();

                if (musicPlay.ContainsKey(song + "✄" + name))
                {
                    MessageBox.Show("此歌曲已添加,无法重复添加");
                    return;
                }

                DataTable dataTablep = (DataTable)dataGridViewPlayl.DataSource;
                dataTablep.Rows.Add("", song + " - " + name, a, im, during, Properties.Resources.删除__1_);
                dataGridViewPlayl.DataSource = dataTablep;

                AddMusic(song + "✄" + name, a + "✄" + im + "✄" + during, "Play", "MusicPlay");
                musicPlay.Add(song + "✄" + name, a + "✄" + im + "✄" + during);
            }
        }
        #endregion

        #region 公用方法播放
        private void PlayMusic(string url,string imgUrl)
        {
            if (string.IsNullOrEmpty(imgUrl))
            {
                ucPanelSongImg.BackgroundImage = Properties.Resources.ico_没有数据;
            }
            else
            {
                WebRequest imgRequest = WebRequest.Create(imgUrl);

                HttpWebResponse res;
                try
                {
                    res = (HttpWebResponse)imgRequest.GetResponse();
                }
                catch (WebException ex)
                {

                    res = (HttpWebResponse)ex.Response;
                }

                if (res.StatusCode.ToString() == "OK")
                {
                    ucPanelSongImg.BackgroundImage = Image.FromStream(imgRequest.GetResponse().GetResponseStream());
                }
                else
                {
                    ucPanelSongImg.BackgroundImage = Properties.Resources.ico_没有数据;
                }
            }

            axWindowsMediaPlayer1.URL = url;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            timerPlay.Start();
        }
        #endregion

        #region 添加歌曲到播放列表
        private void AddMusic(string key, string value, string kinds, string type)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "\\MusicInfo.xml");
            XmlNode xmlNode = xml.SelectSingleNode("Music");

            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Attributes["ID"].Value == user)
                {
                    XmlElement xmlElement = xml.CreateElement(kinds);

                    XmlElement xmlElementK = xml.CreateElement("Key");
                    xmlElementK.InnerText = key;

                    XmlElement xmlElementV = xml.CreateElement("Value");
                    xmlElementV.InnerText = value;

                    xmlElement.AppendChild(xmlElementK);
                    xmlElement.AppendChild(xmlElementV);

                    XmlNode xmlNode1 = node.SelectSingleNode(type);
                    xmlNode1.AppendChild(xmlElement);

                    break;
                }
            }

            xml.Save(Application.StartupPath + "\\MusicInfo.xml");
        }
        #endregion

        #region 左侧列表下拉回收功能
        private void buttonPlayS_Click(object sender, EventArgs e)
        {
            commTaskBtn((Button)sender);
        }

        private void buttonHis_Click(object sender, EventArgs e)
        {
            commTaskBtn((Button)sender);
        }

        private void commTaskBtn(Button button)
        {
            if (button.Text == "+")
            {
                button.Text = "-";

                int allHeight = 0;
                foreach(Control control in panelTask.Controls)
                {
                    control.Height = 34;
                    allHeight += 34;
                }

                button.Parent.Parent.Height = panelTask.Height - allHeight + 34;

                if(beforeAddBtn != null)
                {
                    beforeAddBtn.Text = "+";              
                }
                beforeAddBtn = button;
            }
            else
            {
                beforeAddBtn = null;
                button.Text = "+";
                button.Parent.Parent.Height = 34;
            }
        }
        #endregion

        #region 歌曲顺序播放or循环播放
        private void radioButtonSeq_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSeq.Checked)
            {
                radioButtonSeq.BackgroundImage = Properties.Resources.顺序播放;
                radioButtonFor.BackgroundImage = Properties.Resources.循环监听__1_;

                axWindowsMediaPlayer1.settings.setMode("loop", false);
            }
            else
            {
                radioButtonSeq.BackgroundImage = Properties.Resources.顺序播放__1_;
                radioButtonFor.BackgroundImage = Properties.Resources.循环监听;

                axWindowsMediaPlayer1.settings.setMode("loop", true);
            }
        }
        #endregion

        private void ucPanelSongImg_Click(object sender, EventArgs e)
        {

        }

        #region 上一首按钮
        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (!isPlay)
                return;

            buttonPlay.BackgroundImage = Properties.Resources.播放;
            buttonPlay.Tag = "播放";

            if (isGrid)
            {
                GetMusicM(dgvMusic, false);
            }
            else
            {
                if (playHis == "lb")
                {
                    GetMusicM(dataGridViewPlayl, false);
                }
                else if (playHis == "ls")
                {
                    GetMusicM(dataGridViewHIS, false);
                }
            }
        }

        private void GetMusicM(DataGridView gridView, bool isGrid)
        {
            int activeRow = gridView.SelectedRows[0].Index;
            gridView.Rows[activeRow].Selected = false;

            if (!isGrid)
            {
                gridView.Rows[activeRow].Cells[(int)PLAYDATA.PLAY].Value = "";
            }

            if (activeRow == 0)
            {
                activeRow = gridView.Rows.Count - 1;
            }
            else
            {
                activeRow--;
            }

            gridView.Rows[activeRow].Selected = true;

            string song = "";
            string name = "";
            string during = "";
            string a = "";
            string im = "";

            string sn = "";

            if (isGrid)
            {
                song = gridView.Rows[activeRow].Cells[(int)DATA.MUSIC_NAME].Value.ToString();
                name = gridView.Rows[activeRow].Cells[(int)DATA.NAME].Value.ToString();
                during = gridView.Rows[activeRow].Cells[(int)DATA.DURATION].Value.ToString();

                a = gridView.Rows[activeRow].Cells[(int)DATA.PATH].Value.ToString();
                im = gridView.Rows[activeRow].Cells[(int)DATA.IMAGE].Value.ToString();

                sn = song + " - " + name;                                                                                          
            }
            else
            {
                dataGridViewPlayl.Rows[activeRow].Cells[(int)PLAYDATA.PLAY].Value = "💽";

                sn = gridView.Rows[activeRow].Cells[(int)PLAYDATA.NAME].Value.ToString();

                string[] ss = sn.Split('-');
                song = ss[0].Trim();
                name = ss[1].Trim();
                during = gridView.Rows[activeRow].Cells[(int)PLAYDATA.TIME].Value.ToString();

                a = gridView.Rows[activeRow].Cells[(int)PLAYDATA.URL].Value.ToString();
                im = gridView.Rows[activeRow].Cells[(int)PLAYDATA.IMAGE].Value.ToString();
            }

            if (!musicHis.ContainsKey(song + "✄" + name))
            {
                AddMusic(song + "✄" + name, a + "✄" + im + "✄" + during, "His", "MusicHis");
                musicHis.Add(song + "✄" + name, a + "✄" + im);

                if (!isGrid)
                {
                    DataTable dataTable = (DataTable)dataGridViewHIS.DataSource;
                    dataTable.Rows.Add("", song + " - " + name, a, im, during, Properties.Resources.删除__1_);
                    gridView.DataSource = dataTable;
                }
            }

            ucTrackBarPrcss.Value = 0;
            ucTrackBarPrcss.MaxValue = int.Parse(during);

            labelsn.Text = sn;
            PlayMusic(a, im);
            buttonPlay.BackgroundImage = Properties.Resources.播放_暂停;
            buttonPlay.Tag = "暂停";
        }
        #endregion

        #region 播放暂停按钮
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (!isPlay)
                return;

            if (buttonPlay.Tag.ToString() == "播放")
            {
                buttonPlay.BackgroundImage = Properties.Resources.播放_暂停;
                buttonPlay.Tag = "暂停";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                buttonPlay.BackgroundImage = Properties.Resources.播放;
                buttonPlay.Tag = "播放";
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }
        #endregion

        #region 下一首按钮
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (!isPlay)
                return;

            buttonPlay.BackgroundImage = Properties.Resources.播放;
            buttonPlay.Tag = "播放";

            if (isGrid)
            {
                GetMusic(dgvMusic, isGrid);
            }
            else
            {
                if (playHis == "lb")
                {
                    GetMusic(dataGridViewPlayl, false);                  
                }
                else if (playHis == "ls")
                {
                    GetMusic(dataGridViewHIS, false);                             
                }
            }
        }
        #endregion

        #region 音量按钮
        private void buttonVoice_Click(object sender, EventArgs e)
        {
            if (buttonVoice.Tag.ToString()=="NO")
            {
                buttonVoice.Tag = "YES";
                buttonVoice.BackgroundImage = Properties.Resources.音量键;
                axWindowsMediaPlayer1.settings.volume = (int)ucTrackBarVoice.Value;
            }
            else
            {
                buttonVoice.Tag = "NO";
                buttonVoice.BackgroundImage = Properties.Resources.静音;
                axWindowsMediaPlayer1.settings.volume = 0;
            }
        }

        private void ucTrackBarVoice_ValueChanged(object sender, EventArgs e)
        {
            if (buttonVoice.Tag.ToString() == "YES")
                axWindowsMediaPlayer1.settings.volume = (int)ucTrackBarVoice.Value;
        }
        #endregion

        #region 我的歌曲播放功能
        private void dataGridViewPlayl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == (int)PLAYDATA.DELETE)
            {
                string d = dataGridViewPlayl.Rows[e.RowIndex].Cells[(int)PLAYDATA.URL].Value.ToString().Replace(" - ", "✄");
                XmlDocument xml = new XmlDocument();
                xml.Load(Application.StartupPath + "\\MusicInfo.xml");
                XmlNode xmlNode = xml.SelectSingleNode("Music");

                foreach (XmlNode node in xmlNode.ChildNodes)
                {
                    if (node.Attributes["ID"].Value == user)
                    {
                        XmlNode xn = node.SelectSingleNode("MusicPlay");

                        foreach (XmlNode x in xn.ChildNodes)
                        {
                            string n = x.FirstChild.InnerText;

                            if (n == d)
                            {
                                xn.RemoveChild(x);

                                break;
                            }
                        }
                    }
                }

                xml.Save(Application.StartupPath + "\\MusicInfo.xml");

                musicPlay.Remove(d);
                dataGridViewPlayl.Rows.RemoveAt(e.RowIndex);
            }
            else
            {
                if (labelsn.Text == dataGridViewPlayl.Rows[e.RowIndex].Cells[(int)PLAYDATA.NAME].Value.ToString()) return;

                foreach(DataGridViewRow row in dataGridViewPlayl.Rows)
                {
                    row.Cells[(int)PLAYDATA.PLAY].Value = "";
                }

                playHis = "lb";
                string u = dataGridViewPlayl.Rows[e.RowIndex].Cells[(int)PLAYDATA.URL].Value.ToString();
                string i = dataGridViewPlayl.Rows[e.RowIndex].Cells[(int)PLAYDATA.IMAGE].Value.ToString();
                string t = dataGridViewPlayl.Rows[e.RowIndex].Cells[(int)PLAYDATA.TIME].Value.ToString();

                dataGridViewPlayl.Rows[e.RowIndex].Cells[(int)PLAYDATA.PLAY].Value = "💽";

                ucTrackBarPrcss.MaxValue = int.Parse(t);

                string[] nn= dataGridViewPlayl.Rows[e.RowIndex].Cells[(int)PLAYDATA.NAME].Value.ToString().Split('-');
                if (!musicHis.ContainsKey(nn[0].Trim() + "✄" + nn[1].Trim()))
                {
                    AddMusic(nn[0].Trim() + "✄" + nn[1].Trim(), u + "✄" + i + "✄" + t, "His", "MusicHis");
                    musicHis.Add(nn[0].Trim() + "✄" + nn[1].Trim(), u + "✄" + i);

                    DataTable dataTable = (DataTable)dataGridViewHIS.DataSource;
                    dataTable.Rows.Add("", nn[0] + "-" + nn[0], u, i, t, Properties.Resources.删除__1_);
                    dataGridViewHIS.DataSource = dataTable;
                }

                labelsn.Text = dataGridViewPlayl.Rows[e.RowIndex].Cells[(int)PLAYDATA.NAME].Value.ToString();
                PlayMusic(u, i);
                isPlay = true;
                buttonPlay.BackgroundImage = Properties.Resources.播放_暂停;
                buttonPlay.Tag = "暂停";
            }
        }
        #endregion

        #region 播放记录播放功能
        private void dataGridViewHIS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == (int)PLAYDATA.DELETE)
            {
                string d = dataGridViewHIS.Rows[e.RowIndex].Cells[(int)PLAYDATA.URL].Value.ToString().Replace(" - ", "✄");
                XmlDocument xml = new XmlDocument();
                xml.Load(Application.StartupPath + "\\MusicInfo.xml");
                XmlNode xmlNode = xml.SelectSingleNode("Music");

                foreach (XmlNode node in xmlNode.ChildNodes)
                {
                    if (node.Attributes["ID"].Value == user)
                    {
                        XmlNode xn = node.SelectSingleNode("MusicHis");

                        foreach (XmlNode x in xn.ChildNodes)
                        {
                            string n = x.FirstChild.InnerText;

                            if (n == d)
                            {
                                xn.RemoveChild(x);

                                break;
                            }
                        }
                    }
                }

                xml.Save(Application.StartupPath + "\\MusicInfo.xml");

                musicPlay.Remove(d);
                dataGridViewHIS.Rows.RemoveAt(e.RowIndex);
            }
            else
            {
                if (labelsn.Text == dataGridViewHIS.Rows[e.RowIndex].Cells[(int)PLAYDATA.NAME].Value.ToString()) return;

                foreach (DataGridViewRow row in dataGridViewHIS.Rows)
                {
                    row.Cells[(int)PLAYDATA.PLAY].Value = "";
                }

                playHis = "ls";
                string u = dataGridViewHIS.Rows[e.RowIndex].Cells[(int)PLAYDATA.URL].Value.ToString();
                string i = dataGridViewHIS.Rows[e.RowIndex].Cells[(int)PLAYDATA.IMAGE].Value.ToString();
                string t = dataGridViewHIS.Rows[e.RowIndex].Cells[(int)PLAYDATA.TIME].Value.ToString();

                dataGridViewHIS.Rows[e.RowIndex].Cells[(int)PLAYDATA.PLAY].Value = "💽";

                ucTrackBarPrcss.MaxValue = int.Parse(t);
                labelsn.Text=dataGridViewHIS.Rows[e.RowIndex].Cells[(int)PLAYDATA.NAME].Value.ToString();
                PlayMusic(u, i);
                isPlay = true;
                buttonPlay.BackgroundImage = Properties.Resources.播放_暂停;
                buttonPlay.Tag = "暂停";
            }
        }
        #endregion

        #region form Event
        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonNormal_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void tableLayoutPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            isClick = true;
            mX = e.X;
            mY = e.Y;
        }

        private void tableLayoutPanel2_MouseUp(object sender, MouseEventArgs e)
        {
            isClick = false;
        }

        private void tableLayoutPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClick)
            {
                this.Location = new Point(Location.X + (e.X - mX), Location.Y + (e.Y - mY));
            }
        }

        private void panel14_MouseDown(object sender, MouseEventArgs e)
        {
            isClick = true;
            mX = e.X;
            mY = e.Y;
        }

        private void panel14_MouseUp(object sender, MouseEventArgs e)
        {
            isClick = false;
        }

        private void panel14_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClick)
            {
                this.Location = new Point(Location.X + (e.X - mX), Location.Y + (e.Y - mY));
            }
        }

        bool isSizeClick = false;
        int sizeX = 0;
        int sizeY = 0;
        private void labelFormSize_MouseDown(object sender, MouseEventArgs e)
        {
            isSizeClick = true;
            sizeX = e.X;
            sizeY = e.Y;
        }

        private void labelFormSize_MouseUp(object sender, MouseEventArgs e)
        {
            isSizeClick = false;
        }

        private void labelFormSize_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSizeClick)
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    this.Width += (e.X - sizeX);
                    this.Height += (e.Y - sizeY);
                }
            }
        }
        #endregion

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            labelUser.Text = "";
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "\\UserInfo.xml");
            XmlNode sXmlNode = xml.SelectSingleNode("Users");
            XmlNode fXmlNode = sXmlNode.FirstChild;
            fXmlNode.Attributes["isLogin"].Value = "False";
            xml.Save(Application.StartupPath + "\\UserInfo.xml");

            FormLogin formLogin = new FormLogin();
            if(DialogResult.OK == formLogin.ShowDialog())
            {
                user = formLogin.userLogin;

                Form1Main_Load(null, null);
            }
        }
    }
}
