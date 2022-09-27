using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;


namespace IsLab3
{
    public partial class Form1 : Form
    {
		// Файл, который ВСЕГДА используется алгоритмами шифрования/дешифрования/хэширования
		// при пользовательском выборе тут хранится файл пользователя
		// при генерации - файл генератора по умолчанию.
		private string fileName = "";
		private string fileNameMessage = "";
		private byte[] key; // ключ
		private byte[] init_vect;  // вектор инициализации
		Decryter myDec = new Decryter();
		// Выполняет асимметричное шифрование и расшифровку с помощью реализации алгоритма RSA
		static RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

		// Значение true для включения закрытых параметров; в противном случае — значение false.
		RSAParameters rsaPrivateKey = RSA.ExportParameters(true);//экспорт закрытого ключа
		RSAParameters rsaOpenKey = RSA.ExportParameters(false);  //экспорт открытого ключа


		public Form1()
        {
            InitializeComponent();
			clear_result();
        }

		private void clear_result()
        {
			tb_filepath.Clear();
			tb_key.Clear();
			tb_IV.Clear();
			tb_hash.Clear();
			tb_encrypted.Clear();
			tb_decrypted.Clear();
			tb_privateKey.Clear();
			tb_publicKey.Clear();
			b_decrypt.Enabled = false;

			
		
			/*this.MinimumSize = new Size(this.Width - panel1.Width, this.Height);
			this.Width = this.Width - panel1.Width;*/
			panel1.Visible = false;
		}
		
		private void unlock_interface()
		{
			// разблокируем блоки с командами для шифрования/дешифрования, хэширования
			groupBox2.Enabled = true; groupBox3.Enabled = true;
			//groupBox4.Enabled = true;
			// кнопочки тоже разблокируем
			b_validate.Enabled = true; b_signature.Enabled = true;
		}

		private void Form1_Load_1(object sender, EventArgs e)
        {
			// Не даём пользователю жать что-либо, пока он не дал нам данные
			b_decrypt.Enabled = false;
			b_validate.Enabled = false;
			b_signature.Enabled = false;
			groupBox2.Enabled = false;
			groupBox3.Enabled = false;
			groupBox4.Enabled = false;
			panel1.Enabled = false;
		}

        private void b_openFile_Click(object sender, EventArgs e)
        {
			try
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
					clear_result();
					fileName = openFileDialog1.FileName;
					tb_filepath.Text = openFileDialog1.FileName;

					StreamReader reader = new StreamReader(fileName);
					key = reader.ReadLine().Split(' ').Select(byte.Parse).ToArray();
					init_vect = reader.ReadLine().Split(' ').Select(byte.Parse).ToArray();
					reader.Close();

					tb_key.AppendText(String.Join(" ", key));
					tb_IV.AppendText(String.Join(" ", init_vect));

					unlock_interface();
                }
            }
            catch (Exception ex)
            {
				MessageBox.Show(ex.Message);
            }
        }

		private void b_generate_Click(object sender, EventArgs e)
        {
			clear_result();

			StreamWriter writer = new StreamWriter("config.txt");

			DESCryptoServiceProvider gener = new DESCryptoServiceProvider();
			gener.GenerateKey();
			gener.GenerateIV();
			key = gener.Key;
			init_vect = gener.IV;

			writer.WriteLine(String.Join(" ", gener.Key));
			writer.WriteLine(String.Join(" ", gener.IV));
			writer.Close();

			tb_key.AppendText(String.Join(" ", key));
			tb_IV.AppendText(String.Join(" ", init_vect));
			tb_filepath.Text = Directory.GetCurrentDirectory() + '\\' + Convert.ToString("config.txt");
			fileName = "config.txt";

			unlock_interface();

        }

        private void b_encrypt_Click(object sender, EventArgs e)
        {
            if (rb_DES.Checked)
            {
				tb_decrypted.Clear();
				string inputData = tb_encrypted.Text;
				myDec.EncryptFileDes(key,init_vect, inputData);
				byte[] keks = File.ReadAllBytes("encrypt_des.txt");
				for (int i = 0; i < keks.Length; i++)
					tb_decrypted.AppendText(keks[i].ToString("x2"));

				b_decrypt.Enabled = true; // есть что шифровать - дай расшифровать

			}
            if (rb_RSA.Checked)
            {
				tb_decrypted.Clear();
				string inputData = tb_encrypted.Text;
				string keyRSA = myDec.EncryptFileRsa(key, init_vect, inputData, rsaPrivateKey, rsaOpenKey);
				tb_publicKey.Text = keyRSA;
				byte[] keks = File.ReadAllBytes("encrypt_rsa.txt");
				for (int i = 0; i < keks.Length; i++)
					tb_decrypted.AppendText(keks[i].ToString("x2"));

				b_decrypt.Enabled = true; // есть что шифровать - дай расшифровать
				groupBox4.Enabled = true;
				panel1.Enabled = true;
				panel1.Visible = true;
			}
        }


		private void b_decrypt_Click(object sender, EventArgs e)
        {
			tb_decrypted.Clear();
			if (rb_DES.Checked)
			{
				tb_decrypted.Clear(); // очищаем поле с дешифрованным сообщением

				myDec.DecryptFileDes(key,init_vect); // вызываем функцию дешифрования

				// открываем результат шифрования из файла DecryptFileDes (он уже в верном формате)
				StreamReader reader = new StreamReader("decrypt_des.txt");
				// т.к. мы шифруем ключ и вектор инициализации, то мы 2 раза считываем по строке и записываем в текстбокс

				string str = reader.ReadLine().ToString();
				tb_decrypted.AppendText(str);
				reader.Close(); // закрываем файлопоток
			}
			if (rb_RSA.Checked)
			{
				tb_decrypted.Clear(); // очищаем поле с дешифрованным сообщением

				string keyRsa = myDec.DecryptFileRSA(key, init_vect,rsaPrivateKey,rsaOpenKey); // вызываем функцию дешифрования

				tb_privateKey.Text = keyRsa;
				// открываем результат шифрования из файла DecryptFileDes (он уже в верном формате)
				StreamReader reader = new StreamReader("decrypt_rsa.txt");
				string str = reader.ReadLine().ToString();
				tb_decrypted.AppendText(str);
				reader.Close(); // закрываем файлопоток
			}
		}

        private void b_openHash_Click(object sender, EventArgs e)
        {
			try
			{
				if (openFileDialog2.ShowDialog() == DialogResult.OK)
				{
					fileNameMessage = openFileDialog2.FileName;
					StreamReader reader = new StreamReader(fileNameMessage);
					string inputData = "";
					string s;
					while ((s = reader.ReadLine()) != null)
                    {
						inputData += String.Join("", s.Split(' '));
                    }
					reader.Close();
					tb_message.Text = inputData;
				
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void b_hash_Click(object sender, EventArgs e)
        {
			string message = tb_message.Text;
			string res = myDec.HashMD5(fileNameMessage);
			tb_hash.Text = res;
        }

		private void b_signature_Click(object sender, EventArgs e)
		{
			byte[] hash;
			using (var md5 = MD5.Create())
			{
				using (var stream = File.OpenRead(fileNameMessage))
				{
					hash = md5.ComputeHash(stream);
				}
			}
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) 
			{
				rsa.ImportParameters(rsaOpenKey);
				using (var ms = new MemoryStream(hash)) // с использованием потока памяти (байт) хэша
														// открываем файловый поток для записи электронной подписи
				using (var fstreamOut = new FileStream("signature", FileMode.Create, FileAccess.Write))
				{
					byte[] buf = new byte[64];
					for (; ; )
					{
						// и будем считывать по 64 байта, пока не кончится хэш
						int bytesRead = ms.Read(buf, 0, buf.Length);
						if (bytesRead == 0) break; // хэш кончился - выходим
						byte[] encrypted = bytesRead == buf.Length ? // если считанное кол-во байт = лимиту считывания байт
																	 // то шифруем всё считанное, иначе - шифруем тот оставшийся кусок
							rsa.Encrypt(buf, true) : rsa.Encrypt(buf.Take(bytesRead).ToArray(), true);
						// записываем в файлопоток
						fstreamOut.Write(encrypted, 0, encrypted.Length);
					}
				}

				MessageBox.Show("Электронная подпись создана!");
				b_validate.Enabled = true;
			}
        }

        private void b_validate_Click(object sender, EventArgs e)
        {
			byte[] hashCalc = null;
			byte[] hashDecr = null;

			// Создаём хэш-код с помощью MD5
			using (var md5 = MD5.Create())
			{   // открываем файлопоток с ключом/вектором инициализации пользователя и вычисляем хэш
				using (var stream = File.OpenRead(fileNameMessage))	
				{
					hashCalc = md5.ComputeHash(stream);
				}
			}

			// Создаём объект RSA
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(rsaPrivateKey); // импортируем закрытый ключ

				// используя файлопоток с электронной подписью для чтения
				using (var fstreamIn = new FileStream("signature", FileMode.Open, FileAccess.Read))
				using (var ms = new MemoryStream()) // а также поток памяти (байт)
				{
					byte[] buf = new byte[128]; // используем буфер размерностью 128 байт
					for (; ; )
					{
						int bytesRead = fstreamIn.Read(buf, 0, buf.Length); // считываем кусочек 128 байт
						if (bytesRead == 0) break; // если в кусочке пусто, то выходим из цикла
						byte[] decrypted = rsa.Decrypt(buf, true); // дешифруем кусочек, записываем в массив
						ms.Write(decrypted, 0, decrypted.Length); // в поток памяти записываем кусочек

					}
					hashDecr = ms.ToArray(); // переводим в массив всё, что накопилось в потоке памяти
				}
			}
			// если размерность дешифрованной ЭП и хэша НЕ совпадают, то всё плохо
			if (hashDecr.Count() != hashCalc.Count())
			{
				MessageBox.Show("Электронная подпись некорекктна!");
				return;
			}
			// если хоть для какого-то байта хэша и дешифрованной ЭП есть несовпадение, то тоже всё плохо
			for (int i = 0; i < hashCalc.Count(); i++)
				if (hashCalc[i] != hashDecr[i])
				{
					MessageBox.Show("Электронная подпись некорекктна!");
					return;
				}
			// при невыполнении вышеописанных условий (а их невыполнение приводит к выходу из программы)
			// мы подтверждаем корректность электронной подписи
			MessageBox.Show("Электронная подпись корекктна!");
		}
    }
}
