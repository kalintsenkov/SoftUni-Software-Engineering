using System;
using System.IO;

namespace _04CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = "copyMe.png";
            string picCopyPath = "copyMe-copy.png";

            using (var streamReader = new FileStream(picPath, FileMode.Open))
            {
                using (var streamWriter = new FileStream(picCopyPath, FileMode.Create))
                {
                    while (true)
                    {
                        var buffer = new byte[4096];

                        int readSize = streamReader.Read(buffer, 0, buffer.Length);

                        if (readSize == 0)
                        {
                            break;
                        }

                        streamWriter.Write(buffer, 0, readSize);
                    }
                }
            }
        }
    }
}
