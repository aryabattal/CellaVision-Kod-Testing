using System.Text;
using static System.Console;
using System.Security.Cryptography;
internal class Program
{
    private static void Main(string[] args)
    {
       
        var byteList = new List<byte>();
     
        while (true)
        {
            if (byteList.Any())
            {

                ProcessLines(args);
            }
            else
            {
                byteList.Add(ReadByte());
            }
        }

    }

    //********************************** ReadByte *******************************************//
    private static byte ReadByte()
    {

            return 0;
    }

    //********************************** ProcessLines **************************************//

    private static void ProcessLines(string[] token)
    {
        //separated a string array by spaces to two bytes
        token = "PING 23".Split(' ');


        WriteLine("Raw data:     {0} {1}", token);
        WriteLine("====================================================================");

        // Create SHA1Managed||includes a helpful class to encrypt and decrypt streams
        using (SHA1Managed sha1 = new SHA1Managed())
        {

            //returns byte array
            byte[] stringToken = sha1.ComputeHash(Encoding.UTF8.GetBytes(token[0]));
            byte[] intToken = sha1.ComputeHash(Encoding.UTF8.GetBytes(token[1]));

            // Merge string token bytes into a string of bytes
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < stringToken.Length; i++)
            {
                builder.Append(stringToken[i].ToString("x2"));
            }

            // Merge integer token bytes into a integer of bytes
            for (int i = 0; i < intToken.Length; i++)
            {
                builder.Append(intToken[i].ToString("x2"));
            }

            Console.WriteLine("Merge all token into a string of bytes: {0}", builder.ToString());
            WriteLine("____________________________________________________________________________");

            //converts a byte array into a string
            string bitString = BitConverter.ToString(stringToken);
            WriteLine("put bytes into string: {0}", bitString);

            //converts a byte array into a integer
            int bitint = BitConverter.ToInt32(intToken);

            //converted to a non-negative integer
            int mathBitInt = Math.Abs(bitint);
            WriteLine("put bytes into integer number: {0}", mathBitInt);
            WriteLine("____________________________________________________________________________");

            //converts a byte array into an actual character representation of bytes in a string 
            //using UTF conversion in string
            
           
           string utfString = Encoding.UTF8.GetString(stringToken, 0, stringToken.Length);
            WriteLine("UTF conversion:");
            WriteLine(utfString);


            //using UTF conversion in integer
            string utfInt = Encoding.UTF8.GetString(intToken, 0, intToken.Length);
            WriteLine(utfInt);
            WriteLine("____________________________________________________________________________");

            //converts bytes to string using ASCII conversion
            string asciiString = Encoding.ASCII.GetString(stringToken, 0, stringToken.Length);
            WriteLine("ASCII conversionint :");
            WriteLine( asciiString);
            string ascitInt = Encoding.ASCII.GetString(intToken, 0, intToken.Length);
            WriteLine( ascitInt);
            WriteLine("____________________________________________________________________________");

            ReadLine();
           
        }
    }



}