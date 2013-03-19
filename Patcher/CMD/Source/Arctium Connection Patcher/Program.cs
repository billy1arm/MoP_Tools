using System;
using System.IO;
using System.Threading;

namespace ArctiumConnectionPatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please, drag the file over this tool...");
                Thread.Sleep(4000);
                return;
            }

            // Original data
            byte[] LegacyRoutingTableData = 
            {
                0x87, 0x61, 0x97, 0x82, 0xB7, 0xE0, 0x17, 0xAB, 0xBA, 0x4A, 0xB4, 0x72, 0xD7, 0x11, 0xB2, 0x24,
                0xC8, 0xEC, 0x2A, 0x1D, 0xFB, 0x7C, 0xFB, 0xBE, 0xC8, 0xC1, 0x59, 0x2F, 0xF9, 0x56, 0x83, 0x5B,
                0x24, 0x7C, 0x4A, 0xDC, 0x7A, 0xC5, 0x89, 0x44, 0x1C, 0x66, 0x3E, 0xBC, 0x0B, 0xFD, 0xE3, 0xAB,
                0x64, 0xEE, 0xB6, 0x8F, 0x87, 0xC1, 0xBF, 0x79, 0x6B, 0xDD, 0x92, 0xEF, 0xD2, 0x73, 0x4E, 0x50,
                0x2A, 0x9C, 0x76, 0x88, 0x44, 0x91, 0x80, 0x39, 0x5C, 0xB7, 0xA9, 0x16, 0x27, 0xF9, 0x23, 0x17,
                0x77, 0xCF, 0xEA, 0x79, 0xB0, 0xD9, 0xAF, 0xA0, 0xCA, 0xBE, 0x78, 0xC9, 0x6E, 0xF8, 0x99, 0x22,
                0x51, 0x9E, 0xA7, 0x91, 0xAD, 0xAA, 0xDC, 0x13, 0xAF, 0xA9, 0x2D, 0x9A, 0x5D, 0x8C, 0x2F, 0x31,
                0x21, 0xCC, 0x1A, 0xBB, 0x90, 0xD4, 0x55, 0x19, 0x05, 0xC7, 0xB9, 0x95, 0xEB, 0xA0, 0x05, 0x7C,
                0xF1, 0x1F, 0x85, 0xBB, 0x8B, 0x6A, 0xFE, 0xD7, 0xF9, 0xB0, 0x8B, 0x4D, 0x25, 0x44, 0x1F, 0xA5,
                0x93, 0xB4, 0x71, 0xD5, 0xBD, 0xC6, 0x18, 0x58, 0x04, 0xEC, 0x85, 0x46, 0x62, 0xF8, 0xF7, 0x68,
                0x3A, 0x88, 0xC2, 0x0B, 0x67, 0x1B, 0xA3, 0x50, 0x89, 0x29, 0xCA, 0xCE, 0xFA, 0xCC, 0x80, 0x15,
                0x06, 0x83, 0x3D, 0xEF, 0x34, 0x37, 0x58, 0x9E, 0x39, 0x60, 0x06, 0xF6, 0xE7, 0xA3, 0x43, 0x67,
                0x82, 0xA7, 0x19, 0xF6, 0xBB, 0x4D, 0x09, 0x8E, 0xA8, 0x7D, 0x9A, 0x7C, 0x22, 0x72, 0x97, 0xF5,
                0x08, 0x1C, 0x01, 0xD2, 0x66, 0x4C, 0x25, 0xF3, 0x8F, 0xC9, 0x35, 0xA2, 0x4C, 0x0C, 0x68, 0xD4,
                0xFC, 0xC2, 0x4F, 0x28, 0xD3, 0x6D, 0x59, 0x07, 0x15, 0xEB, 0x6C, 0x38, 0x14, 0x9F, 0x8C, 0x5A,
                0x42, 0xC4, 0xB7, 0x96, 0x20, 0x6F, 0x3C, 0x8D, 0x57, 0x40, 0x84, 0x35, 0x9E, 0x43, 0xDE, 0x5D,
                0x41, 0xBA, 0x47, 0xF4, 0x0A, 0x7B, 0x63, 0xFB, 0x87, 0x6C, 0xD5, 0xB8, 0xE3, 0x3E, 0xE8, 0xF1,
                0x30, 0x8D, 0x73, 0xB1, 0xC0, 0x02, 0x1A, 0x4B, 0xA0, 0xFD, 0xBE, 0x6B, 0x5E, 0xFF, 0x89, 0xDF,
                0x6E, 0xCE, 0xE2, 0xA4, 0xBD, 0x3F, 0x34, 0xE6, 0xEA, 0xB9, 0x56, 0x11, 0xFC, 0xB6, 0x92, 0xAA,
                0xAC, 0xE1, 0x7E, 0x5D, 0x07, 0xB3, 0x2B, 0x2C, 0x5B, 0x77, 0xC9, 0xDA, 0x4F, 0x5A, 0x75, 0x62,
                0x53, 0x18, 0xDE, 0xF0, 0x53, 0x27, 0xD1, 0x45, 0x3B, 0xA8, 0xB6, 0x99, 0x9D, 0x73, 0xE7, 0x2D,
                0xC5, 0xB4, 0x24, 0x23, 0x33, 0x0E, 0xDD, 0x65, 0x00, 0x13, 0x86, 0xE3, 0x03, 0x7E, 0x0E, 0x01,
                0x9B, 0xA6, 0xAD, 0x88, 0xC3, 0xD9, 0xE6, 0xD1, 0xFE, 0x78, 0x3B, 0x9F, 0x4E, 0x70, 0x47, 0x8E,
                0xC8, 0xAF, 0x74, 0x54, 0xDC, 0x51, 0x0D, 0xD8, 0x37, 0x94, 0x13, 0x02, 0xA9, 0x3F, 0x7F, 0x79,
                0xFD, 0xB1, 0xE5, 0x32, 0x98, 0xB5, 0xF3, 0x6D, 0xE5, 0x0F, 0xE4, 0x64, 0x61, 0x1E, 0x70, 0x42,
                0xD7, 0x7A, 0xBE, 0x0C, 0xE4, 0xBF, 0x49, 0x04, 0x16, 0x65, 0xCB, 0x2F, 0x2E, 0x7F, 0xFF, 0x61,
                0xF2, 0xE2, 0x91, 0x5E, 0x75, 0x0D, 0x76, 0xF4, 0x8A, 0xF7, 0xDB, 0x9D, 0x77, 0x48, 0xCD, 0x54,
                0x29, 0xE9, 0x95, 0x5F, 0xF2, 0x32, 0xA9, 0x10, 0xDA, 0x8A, 0xBC, 0x8F, 0xDF, 0xB2, 0x7B, 0x93,
                0x81, 0x4A, 0x7D, 0x48, 0xC0, 0xCD, 0x81, 0xD4, 0x52, 0x1D, 0x26, 0x56, 0x26, 0x12, 0xCB, 0x38,
                0x5F, 0xA2, 0x00, 0xEB, 0x69, 0x6A, 0x94, 0x52, 0xB3, 0xF0, 0x33, 0x74, 0xC7, 0xED, 0x22, 0xC3,
                0xEC, 0x86, 0x03, 0x1B, 0x4B, 0xED, 0x3D, 0x08, 0x2E, 0x55, 0x84, 0x69, 0x14, 0xDB, 0xA4, 0x76,
                0x57, 0x6F, 0xFA, 0xD3, 0x45, 0xDC, 0x41, 0x28, 0xA6, 0x46, 0xA5, 0xEE, 0xD0, 0xD6, 0x2C, 0x0F
            };
            byte[] SendData1        = { 0x48, 0x0A };
            byte[] SendData2        = { 0x48, 0x12 };
            byte[] SendData3        = { 0x5E, 0x02 };
            byte[] SendData4        = { 0x48, 0x0E };
            byte[] CommsHandlerData = { 0x0F, 0x84 };
            byte[] emailData        = { 0x74 };
            
            // Patched data
            byte[] patchedJump1     = { 0xEB };
            byte[] patchedJump2     = { 0x90, 0xE9 };
            byte[] patchedWord      = { 0x00, 0x00 };
            byte[] LegacyRoutingTableBytes = new byte[512];

            // Program start
            string wowBinary = args[0];

            Console.WriteLine("Arctium World of Warcraft - Mist of Pandaria v5.2.0(16709) Client Patcher\n");
            Console.WriteLine("This patch will allow packet communication between server and client login to private server");
            Console.WriteLine("REMEMBER: Email as account name will be required to login!!!\n");
            Console.WriteLine("Choose an action for your WoW client binary");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1: Patch 32 bits Client");
            Console.WriteLine("2: Patch 64 bits Client");
            Console.WriteLine("3: Restore 32 bits Client");
            Console.WriteLine("4: Restore 64 bits Client");
            Console.WriteLine("0: Exit.\n");

            var option = Convert.ToByte(Console.ReadLine());
            Console.WriteLine(option);

            switch (option)
            {
                case 0: // Exit program
                    Environment.Exit(0);
                    break;
                case 1: // Patch x86 client
                    Console.WriteLine("Patching 32bits Client [{0}]...", wowBinary);
                    CheckIfFilePatched((int)Offsetsx32.emailOffset, patchedJump1, wowBinary);
                    CheckIfFileOriginal((int)Offsetsx32.emailOffset, emailData, wowBinary);
                    CreateNewBinary(ref wowBinary, "x32_patched");
                    PatchBinary((int)Offsetsx32.emailOffset, patchedJump1, wowBinary);

                    Console.WriteLine("Patching receive function...");
                    PatchBinary((int)Offsetsx32.CommsHandlerOffset, patchedJump2, wowBinary);

                    Console.WriteLine("Patching send function...");
                    PatchBinary((int)Offsetsx32.SendOffset, patchedWord, wowBinary);
                    PatchBinary((int)Offsetsx32.SendOffset2, patchedWord, wowBinary);
                    PatchBinary((int)Offsetsx32.SendOffset3, patchedWord, wowBinary);
                    PatchBinary((int)Offsetsx32.SendOffset4, patchedWord, wowBinary);

                    Console.WriteLine("Patching legacy routing table...");
                    PatchBinary((int)Offsetsx32.LegacyRoutingTableOffset, LegacyRoutingTableBytes, wowBinary);

                    Console.WriteLine("Exit in 5 seconds...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                    break;
                case 2: // Patch x64 client
                    Console.WriteLine("Patching 64bits Client [{0}]...", wowBinary);
                    CheckIfFilePatched((int)Offsetsx64.emailOffset, patchedJump1, wowBinary);
                    CheckIfFileOriginal((int)Offsetsx64.emailOffset, emailData, wowBinary);
                    CreateNewBinary(ref wowBinary, "x64_patched");
                    PatchBinary((int)Offsetsx64.emailOffset, patchedJump1, wowBinary);

                    Console.WriteLine("Patching receive function...");
                    PatchBinary((int)Offsetsx64.CommsHandlerOffset, patchedJump2, wowBinary);

                    Console.WriteLine("Patching send function...");
                    PatchBinary((int)Offsetsx64.SendOffset, patchedWord, wowBinary);
                    PatchBinary((int)Offsetsx64.SendOffset2, patchedWord, wowBinary);
                    PatchBinary((int)Offsetsx64.SendOffset3, patchedWord, wowBinary);
                    PatchBinary((int)Offsetsx64.SendOffset4, patchedWord, wowBinary);

                    Console.WriteLine("Patching legacy routing table...");
                    PatchBinary((int)Offsetsx64.LegacyRoutingTableOffset, LegacyRoutingTableBytes, wowBinary);

                    Console.WriteLine("Exit in 5 seconds...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                    break;
                case 3: // Restore x86 client
                    Console.WriteLine("Restoring 32bits Client [{0}]...", wowBinary);
                    CheckIfFilePatched((int)Offsetsx32.emailOffset, emailData, wowBinary);
                    CheckIfFileOriginal((int)Offsetsx32.emailOffset, patchedJump1, wowBinary);
                    CreateNewBinary(ref wowBinary, "x32_restored");
                    PatchBinary((int)Offsetsx32.emailOffset, emailData, wowBinary);

                    Console.WriteLine("Restoring receive function...");
                    PatchBinary((int)Offsetsx32.CommsHandlerOffset, CommsHandlerData, wowBinary);

                    Console.WriteLine("Restoring send function...");
                    PatchBinary((int)Offsetsx32.SendOffset, SendData1, wowBinary);
                    PatchBinary((int)Offsetsx32.SendOffset2, SendData2, wowBinary);
                    PatchBinary((int)Offsetsx32.SendOffset3, SendData3, wowBinary);
                    PatchBinary((int)Offsetsx32.SendOffset4, SendData4, wowBinary);

                    Console.WriteLine("Restoring legacy routing table...");
                    PatchBinary((int)Offsetsx32.LegacyRoutingTableOffset, LegacyRoutingTableData, wowBinary);

                    Console.WriteLine("Exit in 5 seconds...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                    break;
                case 4: // Restore x64 client
                    Console.WriteLine("Restoring 64bits Client [{0}]...", wowBinary);
                    CheckIfFilePatched((int)Offsetsx64.emailOffset, emailData, wowBinary);
                    CheckIfFileOriginal((int)Offsetsx64.emailOffset, patchedJump1, wowBinary);
                    CreateNewBinary(ref wowBinary, "x64_restored");
                    PatchBinary((int)Offsetsx64.emailOffset, emailData, wowBinary);

                    Console.WriteLine("Restoring receive function...");
                    PatchBinary((int)Offsetsx64.CommsHandlerOffset, CommsHandlerData, wowBinary);

                    Console.WriteLine("Restoring send function...");
                    PatchBinary((int)Offsetsx64.SendOffset, SendData1, wowBinary);
                    PatchBinary((int)Offsetsx64.SendOffset2, SendData2, wowBinary);
                    PatchBinary((int)Offsetsx64.SendOffset3, SendData3, wowBinary);
                    PatchBinary((int)Offsetsx64.SendOffset4, SendData4, wowBinary);

                    Console.WriteLine("Restoring legacy routing table...");
                    PatchBinary((int)Offsetsx64.LegacyRoutingTableOffset, LegacyRoutingTableData, wowBinary);

                    Console.WriteLine("Exit in 5 seconds...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        static void CreateNewBinary(ref string file, string type)
        {
            Console.WriteLine("Creating backup from {0}...", file);
            File.Copy(file, "WoW_tmp", true);
            Console.WriteLine("Done");

            string newFileName = "WoW" + type + ".exe";
            if (File.Exists(newFileName))
                File.Delete(newFileName);

            Console.WriteLine("Create new binary...");

            File.Move(file, newFileName);
            File.Move("WoW_tmp", file);

            file = newFileName;
            Console.WriteLine("Done");
        }

        static void CheckIfFilePatched(int offset, byte[] pBytes, string file)
        {
            BinaryReader wowReader = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read));
            wowReader.BaseStream.Seek(offset, SeekOrigin.Begin);

            if (wowReader.ReadByte() == pBytes[0])
            {
                Console.WriteLine("{0} already patched/restored!!!", file);
                wowReader.Close();

                Console.WriteLine("Exit in 5 seconds...");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
            wowReader.Close();
        }

        static void CheckIfFileOriginal(int offset, byte[] pBytes, string file)
        {
            BinaryReader wowReader = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read));
            wowReader.BaseStream.Seek(offset, SeekOrigin.Begin);

            if (wowReader.ReadByte() != pBytes[0])
            {
                Console.WriteLine("{0} is not the expected file!!!", file);
                wowReader.Close();

                Console.WriteLine("Exit in 5 seconds...");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
            wowReader.Close();
        }

        static void PatchBinary(int offset, byte[] pBytes, string file)
        {
            BinaryWriter wowWriter = new BinaryWriter(File.Open(file, FileMode.Open, FileAccess.ReadWrite));
            wowWriter.BaseStream.Seek((int)offset, SeekOrigin.Begin);
            wowWriter.Write(pBytes);
            wowWriter.Close();

            Console.WriteLine("Done.");
        }
    }
}
