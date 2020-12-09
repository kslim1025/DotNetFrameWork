using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumNaverLogin
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPW = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.checkBoxIsShow = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "비밀번호";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(68, 20);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 21);
            this.textBoxID.TabIndex = 1;
            // 
            // textBoxPW
            // 
            this.textBoxPW.Location = new System.Drawing.Point(68, 47);
            this.textBoxPW.Name = "textBoxPW";
            this.textBoxPW.PasswordChar = '*';
            this.textBoxPW.Size = new System.Drawing.Size(100, 21);
            this.textBoxPW.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPW);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 79);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "네이버 로그인 정보";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(113, 97);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "로그인";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // checkBoxIsShow
            // 
            this.checkBoxIsShow.AutoSize = true;
            this.checkBoxIsShow.Location = new System.Drawing.Point(12, 101);
            this.checkBoxIsShow.Name = "checkBoxIsShow";
            this.checkBoxIsShow.Size = new System.Drawing.Size(76, 16);
            this.checkBoxIsShow.TabIndex = 3;
            this.checkBoxIsShow.Text = "창 보이기";
            this.checkBoxIsShow.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 136);
            this.Controls.Add(this.checkBoxIsShow);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;
       

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string caption = buttonLogin.Text;

            if (caption == "로그인")
            {
                string id = textBoxID.Text;
                string pw = textBoxPW.Text;

                if (checkBoxIsShow.Checked == false)
                    _options.AddArgument("headless");

                _driver = new ChromeDriver(_driverService, _options);

                _driver.Navigate().GoToUrl("https://www.naver.com");

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                var element = _driver.FindElementByXPath("//*[@id='account']/div/a/i");
                element.Click();

                Thread.Sleep(3000);

                element = _driver.FindElementByXPath("//*[@id='id']");
                element.SendKeys(id);

                element = _driver.FindElementByXPath("//*[@id='pw']");
                element.SendKeys(pw);

                element = _driver.FindElementByXPath("//*[@id='log.login']");
                element.Click();

                buttonLogin.Text = "로그아웃";
            }
            else
            {
                _driver.Quit();

                buttonLogin.Text = "로그인";
            }
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPW;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.CheckBox checkBoxIsShow;
    }
}

