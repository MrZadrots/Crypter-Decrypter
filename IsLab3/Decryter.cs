using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IsLab3
{
    class Decryter
    {
        public void EncryptFileDes(byte[] key, byte[] init_vect, string stringT)
        {
            // using (var fsInput = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (var fsEncrypted = new FileStream("encrypt_des.txt", FileMode.Create, FileAccess.Write))
            {
                // Инициализируем объект типа DESCryptoServiceProvider для использования алгоритма DES
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = key;
                DES.IV = init_vect;
                // Создаём объект-шифратор с ключом и вектором инициализации
                ICryptoTransform desencrypt = DES.CreateEncryptor();

                // Создаём поток данных для связывания потоков данных FileStream
                // и криптографических преобразований ICryptoTransform (с режимом потока CryptoStreamMode)
                // (эта штука будет записывать полученный шифр в файл со всеми необходимыми преобразованиями)
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

                // Инициализировали массив байтов по количеству байт потока входных данных
                byte[] bytearrayinput = new byte[stringT.Length];
                // Считываем массив байтов из входного файла
                //stringT.Read(bytearrayinput, 0, bytearrayinput.Length);
                bytearrayinput = Encoding.UTF8.GetBytes(stringT);
                // Передаём считанный массив байтов в ранее инициализированный CryptoStream
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                // он удачно записывает результат шифрования алгоритма DES в файл
                // мы закрываем криптопоток
                cryptostream.Close();
            }
        }
        
        public void DecryptFileDes(byte[] key, byte[] init_vect)
        {
            using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
            {
                DES.Key = key;
                DES.IV = init_vect;
                using (var fsread = new FileStream("encrypt_des.txt", FileMode.Open, FileAccess.Read))
                {
                    // Инициализируем дешифратор
                    ICryptoTransform desdecrypt = DES.CreateDecryptor();

                    // Создаём поток данных для связывания потоков данных FileStream
                    // и криптографических преобразований ICryptoTransform (с режимом потока CryptoStreamMode)
                    // (эта штука будет считывать шифр из файла со всеми необходимыми преобразованиями)
                    CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
                    // Инициализируем файловый поток для результата дешифровки
                    using (var fsDecrypted = new FileStream("decrypt_des.txt", FileMode.Create))
                    {
                        byte[] bytearrayinput = new byte[1024];
                        int length;
                        // в цикле мы получаем данные из криптопотока частями (не более 1024 байт за раз)
                        // поэтому, пока в length записано 1024 байт (кусок полный), мы считываем ещё и ещё,
                        // пока не скушаем последний кусочек криптотортика
                        do
                        {
                            // в length он кидает то, что считал на пути 1024 байт (непустую часть)
                            length = cryptostreamDecr.Read(bytearrayinput, 0, 1024);

                            // пишем в файл дешифрованную информацию
                            fsDecrypted.Write(bytearrayinput, 0, length);
                        } while (length == 1024);

                        // Очищаем буферы файлопотока и вызываем запись всех буферизированных данных в файл
                        fsDecrypted.Flush();
                    }
                }
            }
        }

        public string EncryptFileRsa(byte[] key, byte[] init_vect, string stringT, RSAParameters rsaPrivateKey, RSAParameters rsaOpenKey)
        {
            string public_key;
            // Инициализируем объект типа RSACryptoServiceProvider для использования алгоритма RSA
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaOpenKey);
                byte[] keks = rsa.ExportCspBlob(false);
                string kek = "";
                for (int i = 0;i< keks.Length; i++)
                    kek += (keks[i].ToString("x2"));
                public_key = kek;

                using (var fstreamOut = new FileStream("encrypt_rsa.txt", FileMode.Create, FileAccess.Write))
                {
                    byte[] bytearrayinput = new byte[stringT.Length];
                    // Считываем массив байтов из входного файла
                    bytearrayinput = Encoding.UTF8.GetBytes(stringT);
                    byte[] encrypted = rsa.Encrypt(bytearrayinput, false);
                    fstreamOut.Write(encrypted, 0, encrypted.Length);
                }
            }

            return public_key;
        }

        public string DecryptFileRSA(byte[] key, byte[] init_vect, RSAParameters rsaPrivateKey, RSAParameters rsaOpenKey)
        {
            string privateKey;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Импортируем закрытый ключ
                rsa.ImportParameters(rsaPrivateKey);
                // экспортируем этот ключ, чтобы преобразовать его к 16х формату и вывести на форму
                byte[] keks = rsa.ExportCspBlob(true);
                string kek = "";
                for (int i = 0; i < keks.Length; i++)
                    kek += (keks[i].ToString("x2"));
                privateKey = kek;
                // Инициализация файлопотоков для чтения и записи
                using (var fstreamIn = new FileStream("encrypt_rsa.txt", FileMode.Open, FileAccess.Read))
                using (var fstreamOut = new FileStream("decrypt_rsa.txt", FileMode.Create, FileAccess.Write))
                {
                    byte[] buf = new byte[128]; // мы можем взять кусок максимум 128 байт
                    for (; ; )
                    {
                        // считываем байты из файлопотока (с лимитом 128 байт)
                        int bytesRead = fstreamIn.Read(buf, 0, buf.Length);
                        if (bytesRead == 0) break; // если пусто - выходим

                        byte[] decrypted = rsa.Decrypt(buf, false);
                        // записываем кусочек (или всё целиком)
                        fstreamOut.Write(decrypted, 0, decrypted.Length);
                    }
                }
            }

            return privateKey;
        }
    
        public string HashMD5(string fileName)
        {
            string res;
            // Создадим объект класса MD5
            using (var md5 = MD5.Create())
            {
                // Откроем файл с входными данными пользователя/генератора
                using (var stream = File.OpenRead(fileName))
                {
                    // Высчитываем хэш (результат - поток байт)
                    byte[] hash = md5.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();

                    // Каждый элемент результата формируем как 2 шестнадцатеричных символа
                    // в верхнем регистре, затем производим добавление к текущей строке результата
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    // выводим строку-результат в специальном поле

                    using (var streamWrite = new FileStream("hash.txt", FileMode.Create, FileAccess.Write))
                    {
                        string str = sb.ToString();
                        byte[] bytearrayinput = new byte[str.Length];
                        // Считываем массив байтов из входного файла
                        bytearrayinput = Encoding.UTF8.GetBytes(str);
                        streamWrite.Write(bytearrayinput, 0, bytearrayinput.Length);

                        streamWrite.Flush();
                        return str;
                    }
                }
            }

        }
    }
}
