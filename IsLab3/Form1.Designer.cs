
namespace IsLab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_filepath = new System.Windows.Forms.TextBox();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.tb_IV = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_encrypted = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_openHash = new System.Windows.Forms.Button();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_hash = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_RSA = new System.Windows.Forms.RadioButton();
            this.tb_decrypted = new System.Windows.Forms.TextBox();
            this.b_decrypt = new System.Windows.Forms.Button();
            this.b_encrypt = new System.Windows.Forms.Button();
            this.rb_DES = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.b_validate = new System.Windows.Forms.Button();
            this.b_signature = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_privateKey = new System.Windows.Forms.TextBox();
            this.tb_publicKey = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.b_hash = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_filepath);
            this.groupBox1.Controls.Add(this.tb_key);
            this.groupBox1.Controls.Add(this.tb_IV);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Инициализация входных данных";
            // 
            // tb_filepath
            // 
            this.tb_filepath.Location = new System.Drawing.Point(13, 152);
            this.tb_filepath.Name = "tb_filepath";
            this.tb_filepath.Size = new System.Drawing.Size(430, 22);
            this.tb_filepath.TabIndex = 2;
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(16, 206);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(430, 22);
            this.tb_key.TabIndex = 2;
            // 
            // tb_IV
            // 
            this.tb_IV.Location = new System.Drawing.Point(16, 251);
            this.tb_IV.Name = "tb_IV";
            this.tb_IV.Size = new System.Drawing.Size(430, 22);
            this.tb_IV.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Сгенерировать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.b_generate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.b_openFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "IV";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Путь";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ключ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Сгенерировать данные";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Открыть файл с ключем и вектором инициализации";
            // 
            // tb_encrypted
            // 
            this.tb_encrypted.Location = new System.Drawing.Point(16, 72);
            this.tb_encrypted.Multiline = true;
            this.tb_encrypted.Name = "tb_encrypted";
            this.tb_encrypted.Size = new System.Drawing.Size(456, 86);
            this.tb_encrypted.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_openHash);
            this.groupBox2.Controls.Add(this.tb_message);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tb_hash);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(10, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 331);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Хеширование";
            // 
            // b_openHash
            // 
            this.b_openHash.Location = new System.Drawing.Point(336, 29);
            this.b_openHash.Name = "b_openHash";
            this.b_openHash.Size = new System.Drawing.Size(102, 26);
            this.b_openHash.TabIndex = 1;
            this.b_openHash.Text = "Открыть";
            this.b_openHash.UseVisualStyleBackColor = true;
            this.b_openHash.Click += new System.EventHandler(this.b_openHash_Click);
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(13, 94);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(430, 100);
            this.tb_message.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Сообщение";
            // 
            // tb_hash
            // 
            this.tb_hash.Location = new System.Drawing.Point(13, 225);
            this.tb_hash.Multiline = true;
            this.tb_hash.Name = "tb_hash";
            this.tb_hash.Size = new System.Drawing.Size(430, 100);
            this.tb_hash.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Хеш";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Хеширование с помощью алгоритма MD5";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_RSA);
            this.groupBox3.Controls.Add(this.tb_decrypted);
            this.groupBox3.Controls.Add(this.tb_encrypted);
            this.groupBox3.Controls.Add(this.b_decrypt);
            this.groupBox3.Controls.Add(this.b_encrypt);
            this.groupBox3.Controls.Add(this.rb_DES);
            this.groupBox3.Location = new System.Drawing.Point(487, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 342);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Шифрование/Дешифрование";
            // 
            // rb_RSA
            // 
            this.rb_RSA.AutoSize = true;
            this.rb_RSA.Location = new System.Drawing.Point(297, 28);
            this.rb_RSA.Name = "rb_RSA";
            this.rb_RSA.Size = new System.Drawing.Size(57, 21);
            this.rb_RSA.TabIndex = 0;
            this.rb_RSA.TabStop = true;
            this.rb_RSA.Text = "RSA";
            this.rb_RSA.UseVisualStyleBackColor = true;
            // 
            // tb_decrypted
            // 
            this.tb_decrypted.Location = new System.Drawing.Point(16, 207);
            this.tb_decrypted.Multiline = true;
            this.tb_decrypted.Name = "tb_decrypted";
            this.tb_decrypted.Size = new System.Drawing.Size(456, 86);
            this.tb_decrypted.TabIndex = 2;
            // 
            // b_decrypt
            // 
            this.b_decrypt.Location = new System.Drawing.Point(180, 299);
            this.b_decrypt.Name = "b_decrypt";
            this.b_decrypt.Size = new System.Drawing.Size(145, 34);
            this.b_decrypt.TabIndex = 1;
            this.b_decrypt.Text = "Дешифровать";
            this.b_decrypt.UseVisualStyleBackColor = true;
            this.b_decrypt.Click += new System.EventHandler(this.b_decrypt_Click);
            // 
            // b_encrypt
            // 
            this.b_encrypt.Location = new System.Drawing.Point(180, 164);
            this.b_encrypt.Name = "b_encrypt";
            this.b_encrypt.Size = new System.Drawing.Size(145, 37);
            this.b_encrypt.TabIndex = 1;
            this.b_encrypt.Text = "Шифровать";
            this.b_encrypt.UseVisualStyleBackColor = true;
            this.b_encrypt.Click += new System.EventHandler(this.b_encrypt_Click);
            // 
            // rb_DES
            // 
            this.rb_DES.AutoSize = true;
            this.rb_DES.Location = new System.Drawing.Point(114, 28);
            this.rb_DES.Name = "rb_DES";
            this.rb_DES.Size = new System.Drawing.Size(57, 21);
            this.rb_DES.TabIndex = 0;
            this.rb_DES.TabStop = true;
            this.rb_DES.Text = "DES";
            this.rb_DES.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.b_validate);
            this.groupBox4.Controls.Add(this.b_signature);
            this.groupBox4.Location = new System.Drawing.Point(487, 349);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 138);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Цифровая подпись";
            // 
            // b_validate
            // 
            this.b_validate.Location = new System.Drawing.Point(327, 46);
            this.b_validate.Name = "b_validate";
            this.b_validate.Size = new System.Drawing.Size(145, 34);
            this.b_validate.TabIndex = 1;
            this.b_validate.Text = "Проверить";
            this.b_validate.UseVisualStyleBackColor = true;
            this.b_validate.Click += new System.EventHandler(this.b_validate_Click);
            // 
            // b_signature
            // 
            this.b_signature.Location = new System.Drawing.Point(16, 46);
            this.b_signature.Name = "b_signature";
            this.b_signature.Size = new System.Drawing.Size(145, 34);
            this.b_signature.TabIndex = 1;
            this.b_signature.Text = "Создать";
            this.b_signature.UseVisualStyleBackColor = true;
            this.b_signature.Click += new System.EventHandler(this.b_signature_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.tb_privateKey);
            this.groupBox5.Controls.Add(this.tb_publicKey);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(492, 483);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ключи";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Public Key";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Private Key";
            // 
            // tb_privateKey
            // 
            this.tb_privateKey.Location = new System.Drawing.Point(6, 251);
            this.tb_privateKey.Multiline = true;
            this.tb_privateKey.Name = "tb_privateKey";
            this.tb_privateKey.Size = new System.Drawing.Size(456, 153);
            this.tb_privateKey.TabIndex = 2;
            // 
            // tb_publicKey
            // 
            this.tb_publicKey.Location = new System.Drawing.Point(6, 61);
            this.tb_publicKey.Multiline = true;
            this.tb_publicKey.Name = "tb_publicKey";
            this.tb_publicKey.Size = new System.Drawing.Size(456, 153);
            this.tb_publicKey.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Location = new System.Drawing.Point(994, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 457);
            this.panel1.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // b_hash
            // 
            this.b_hash.Location = new System.Drawing.Point(167, 649);
            this.b_hash.Name = "b_hash";
            this.b_hash.Size = new System.Drawing.Size(118, 27);
            this.b_hash.TabIndex = 1;
            this.b_hash.Text = "Хешировать";
            this.b_hash.UseVisualStyleBackColor = true;
            this.b_hash.Click += new System.EventHandler(this.b_hash_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 701);
            this.Controls.Add(this.b_hash);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_encrypted;
        private System.Windows.Forms.TextBox tb_IV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button b_openHash;
        private System.Windows.Forms.TextBox tb_hash;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_RSA;
        private System.Windows.Forms.TextBox tb_decrypted;
        private System.Windows.Forms.Button b_decrypt;
        private System.Windows.Forms.Button b_encrypt;
        private System.Windows.Forms.RadioButton rb_DES;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tb_filepath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button b_validate;
        private System.Windows.Forms.Button b_signature;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_privateKey;
        private System.Windows.Forms.TextBox tb_publicKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button b_hash;
    }
}

