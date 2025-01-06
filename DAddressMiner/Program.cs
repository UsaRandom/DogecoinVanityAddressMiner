using System.Diagnostics;
using System.IO;
using System.Reflection;
using Lib.Dogecoin;

internal class Program
{
    public const string HDPATH = "m/44'/3'/0'/0/0";


    private static void Main(string[] args)
    {
        if (args.Length == 0) return;
        if (args[0].Length != 9) return;

        var pattern = args[0];

        var ctx = LibDogecoinContext.Instance;

        char start0 = pattern[0];
        char start1 = pattern[1];
        char start2 = pattern[2];
        char start3 = pattern[3];
        char start4 = pattern[4];

        char end0 = pattern[5];
        char end1 = pattern[6];
        char end2 = pattern[7];
        char end3 = pattern[8];

        int addressCounter = 0;
        int lastCounter = 0;

        Stopwatch stopwatch = new Stopwatch();
        DateTime lastUpdate = DateTime.Now;

        stopwatch.Start();

        while (true)
        {

            var mnemonic = ctx.GenerateMnemonic("eng", LibDogecoinContext.ENTROPY_SIZE_128, " ");

            var masterKeys = ctx.GenerateHDMasterPubKeypairFromMnemonic(mnemonic);

            if (ctx.VerifyHDMasterPubKeyPair(masterKeys.privateKey, masterKeys.publicKey))
            {
                var address = ctx.GetDerivedHDAddressByPath(masterKeys.privateKey, HDPATH, false);

                addressCounter++; // Increment counter for each address generated

                // Update performance every second
                if ((DateTime.UtcNow - lastUpdate).TotalMilliseconds >= 250)
                {
                    long elapsedMs = stopwatch.ElapsedMilliseconds;
                    if (elapsedMs > 0)
                    {

                        if(Process.GetProcessesByName("DogecoinAddressMiner").Length == 0)
                        {
                            //Child process should exit!
                            return;
                        }

                        Console.WriteLine($"Count:{(addressCounter - lastCounter)}");

                        lastCounter = addressCounter;
                        lastUpdate = DateTime.UtcNow;
                        stopwatch.Restart();
                    }
                }
                

                if ((address[1] == start0 || start0 == '*') &&
                    (address[2] == start1 || start1 == '*') &&
                    (address[3] == start2 || start2 == '*') &&
                    (address[4] == start3 || start3 == '*') &&
                    (address[5] == start4 || start4 == '*') &&
                    (address[address.Length - 4] == end0 || end0 == '*') &&
                    (address[address.Length - 3] == end1 || end1 == '*') &&
                    (address[address.Length - 2] == end2 || end2 == '*') &&
                    (address[address.Length - 1] == end3 || end3 == '*'))
                {
                    Console.WriteLine($"Match:{mnemonic}");
                    return;
                }
            }
            
        }


    }
}