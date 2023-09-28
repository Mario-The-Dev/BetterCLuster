using ScriptEx;
using System;
using System.Management;
using BetterCLuster.Program.use.only.global;

namespace BetterCLuster.Commands.hostOS
{
    public class SystemInfoAll : ICommand
    {
        public void Execute()
        {
            try
            {
                Console.WriteLine("Device Name:");
                getComponent.GetComponent("Win32_ComputerSystem", "Name");
                Console.Write($"\n");
                Console.WriteLine("Operating System Manufacturer:");
                getComponent.GetComponent("Win32_OperatingSystem", "Manufacturer");
                Console.Write($"\n");
                Console.WriteLine("Operating System:");
                getComponent.GetComponent("Win32_OperatingSystem", "Name");
                Console.Write($"\n");
                Console.WriteLine("Motherboard model:");
                getComponent.GetComponent("Win32_BaseBoard", "Product");
                Console.Write($"\n");
                Console.WriteLine("Motherboard Manufacturer:");
                getComponent.GetComponent("Win32_BaseBoard", "Manufacturer");
                Console.Write($"\n");
                Console.WriteLine("CPU model:");
                getComponent.GetComponent("Win32_Processor", "Name");
                Console.Write($"\n");
                Console.WriteLine("CPU Manufacturer:");
                getComponent.GetComponent("Win32_Processor", "Manufacturer");
                Console.Write($"\n");
                Console.WriteLine("GPU:");
                getComponent.GetComponent("Win32_VideoController", "Name");
                Console.Write($"\n");
                Console.WriteLine("BIOS:");
                getComponent.GetComponent("Win32_BIOS", "Name");
                Console.Write($"\n");
                Console.WriteLine("BIOS Manufacturer:");
                getComponent.GetComponent("Win32_BIOS", "Manufacturer");
                Console.Write($"\n");
                Console.WriteLine("Storage:");
                getComponent.GetComponent("Win32_DiskDrive", "Model");
                Console.Write($"\n");
                Console.WriteLine("RAM:");
                getComponent.GetComponent("Win32_PhysicalMemory", "Capacity");
                Console.Write($"\n");
                Console.WriteLine("RAM Manufacturer:");
                getComponent.GetComponent("Win32_PhysicalMemory", "Manufacturer");
                Console.Write($"\n");
                Console.WriteLine("RAM Serial Number:");
                getComponent.GetComponent("Win32_PhysicalMemory", "SerialNumber");
                Console.Write($"\n");
                Console.WriteLine("Audio:");
                getComponent.GetComponent("Win32_SoundDevice", "ProductName");
                Console.Write($"\n");
                Console.WriteLine("Network:");
                getComponent.GetComponent("Win32_NetworkAdapter", "Name");
                Console.Write($"\n");
                Console.WriteLine("Battery Name:");
                getComponent.GetComponent("Win32_Battery", "Name");
                Console.Write($"\n");

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR : " + e);
            }
        }
    }

    public class SystemInfoSelect : ICommand
    {
        public void Execute()
        {
            Console.Write("Enter Component : ");
            string? hwclass = Console.ReadLine();
            Console.Write("Enter Catergory : ");
            string? syntax = Console.ReadLine();

            getComponent.GetComponent(hwclass, syntax);
        }
    }

    public class getOperatingSystem : ICommand
    {
        public void Execute()
        {
            Console.WriteLine($"OS version : {Environment.OSVersion}");
        }
    }

    public class UserName : ICommand
    {
        public void Execute()
        {
            Console.WriteLine($"User : {Environment.UserName}");
        }
    }

    public class getExternalAndInternalDrivers : ICommand
    {
        public void Execute()
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo d in driveInfos)
            {
                Console.WriteLine("Name : " + d.Name);
                Console.WriteLine("Type : " + d.DriveType);
                Console.WriteLine("Total size(in bytes): " + d.TotalSize);
                Console.WriteLine("Total free space(in bytes) : " + d.TotalFreeSpace);
                Console.WriteLine("Direver Format : " + d.DriveFormat);
                Console.WriteLine("Volume Label: " + d.VolumeLabel);
                Console.WriteLine("Root Directory : " + d.RootDirectory);
                Console.Write($"\n");
            }
        }
    }

    internal class getComponent
    {
        public static void GetComponent(string hwclass, string syntax)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                if (Convert.ToString(mj[syntax]) != "")
                    Console.WriteLine($"\t -"+Convert.ToString(mj[syntax]));
            }
            
        }//hardware
    }
}
