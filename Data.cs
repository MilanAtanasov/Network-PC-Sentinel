using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace Network_PC_Sentinel
{
    internal class Data
    {

        // 1. Private static instance of the same class
        private static Data instance = null;
        private List<Computer> computers = new List<Computer>();
        private List<Software> software = new List<Software>();
        private String path = "C:\\Users\\Public\\Documents\\Network PC Sentinel\\";

        // 2. Private constructor so that no instance can be created from outside
        private Data()
        {
        }

        // 3. Public static method to access the instance
        public static Data Instance
        {
            get
            {
                // If the instance is null then create one and return, otherwise return the existing instance
                if (instance == null)
                {
                    instance = new Data();
                }
                instance.updateData();
                return instance;
            }
        }

        // Rest of the class members go here

        public List<Computer> getComputers()
        {
            return computers;
        }

        public List<Software> getSoftware()
        {
            return software;
        }

        public String getPath()
        {
            return path;
        }

        public void setComputers(List<Computer> computers)
        {
            this.computers = computers;
        }

        public void setSoftware(List<Software> software)
        {
            this.software = software;
        }

        public void setPath(String path)
        {
            this.path = path;
        }

        public void updateData()
        {
         
            List<List<String>> data = readData();
            ArrayList computers = parseData(data);
            List<Computer> newComputerList = new List<Computer>();

            Debug.WriteLine(computers.Count);

            foreach (ArrayList computerData in computers)
            {
                String name = (String)computerData[0];
                ArrayList ips = (ArrayList)computerData[1];
                List<Software> software = (List<Software>)computerData[2];
                String lastTurnedOnOff = (String)computerData[3];
                Computer computer = new Computer(name, ips, software, lastTurnedOnOff);
                newComputerList.Add(computer);
            }

            this.computers = newComputerList;

        }

        private ArrayList parseData(List<List<String>> data)
        {
            ArrayList computers = new ArrayList();

            foreach (List<String> computerData in data)
            {
                ArrayList computer = new ArrayList();
                ArrayList ips = new ArrayList();
                List<Software> software = new List<Software>();
                String lastTurnedOnOff = computerData[computerData.Count - 1];

                Boolean ipsDone = false;
                Boolean betweenSoftware = false;
                Boolean softwareStarted = false;
                for(int i = 1; i < computerData.Count - 1; i++)
                {
                    String line = computerData[i];
                    if (line.Contains(".") && !ipsDone)
                    {
                        ips.Add(line);
                    }

                    if (line.Contains("DisplayName"))
                    {
                        ipsDone = true;
                        betweenSoftware = true;
                        continue;
                    }

                    if (line.Contains("----"))
                    {
                        betweenSoftware = true;
                        continue;
                    }

                    if (!line.Contains("----"))                        
                    {
                        betweenSoftware = false;
                        softwareStarted = true;
                    }

                    if (ipsDone && !betweenSoftware && softwareStarted)
                    {
                        if (!line.StartsWith(" "))
                        {
                            software.Add(new Software(line));
                        }
                    }
                }
                

                computer.Add(computerData[0]);
                computer.Add(ips);
                computer.Add(software);
                computer.Add(lastTurnedOnOff);
                computers.Add(computer);

            }

            return computers;
        }


        private List<List<String>> readData()
        {
            List<List<String>> data = new List<List<String>>();

            List<String> files = System.IO.Directory.GetFiles(path).ToList();
            foreach (String fileName in files)
            {
                List<String> fileData = new List<String>();
                fileData.Add(fileName.Replace(path, "").ToUpper().Replace(".TXT", ""));
                String[] lines = System.IO.File.ReadAllLines(fileName);
                foreach (String line in lines)
                {
                    fileData.Add(line);
                }
                fileData.Add(System.IO.File.GetLastWriteTime(fileName).ToString());
                data.Add(fileData);
            }  


            return data;

        }

    }
}


// Example File:
/*/169.254.201.26
134.147.190.188
127.0.0.1

DisplayName                                                     DisplayVersion   Publisher             InstallDate
-----------                                                     --------------   ---------             -----------
                                                                                                                  
Mozilla Firefox (x64 de)                                        121.0.1          Mozilla                          
Mozilla Maintenance Service                                     101.0.1          Mozilla                          
                                                                                 Microsoft Corporation            
                                                                                 Microsoft Corporation            
Microsoft 365 Apps for Enterprise - de-de                       16.0.16924.20180 Microsoft Corporation            
Microsoft OneDrive                                              23.246.1127.0002 Microsoft Corporation            
                                                                                 Microsoft Corporation            
Sophos Endpoint Agent                                           2023.1.3.6       Sophos Limited        20240116   
Sophos Endpoint Defense                                         3.1.3.2282       Sophos Limited        20240123   
Sophos ML Engine                                                1.8.25.1         Sophos Limited                   
Sophos Standalone Engine                                        3.88.0.81        Sophos Limited                   
                                                                                                                  
Sophos AutoUpdate                                               6.15.1417        Sophos Limited        20240116   
Dynamic Application Loader Host Interface Service               1.0.0.0          Intel Corporation     20220317   
Sophos AMSI Protection                                          1.9.2098         Sophos Limited        20240116   
Intel(R) Management Engine Components                           1.0.0.0          Intel Corporation     20220622   
Intel(R) Management Engine Components                           2205.15.0.2623   Intel Corporation                
Microsoft Update Health Tools                                   3.74.0.0         Microsoft Corporation 20231110   
Sophos Endpoint Agent                                           2.9.564          Sophos Limited        20240116   
Sophos Endpoint Firewall                                        2.3.93           Sophos Limited        20240116   
Sophos Network Threat Protection                                1.17.3508        Sophos Limited        20240123   
Zoom (64-bit)                                                   5.16.26186       Zoom                  20231215   
Intel(R) Serial IO                                              30.100.1943.2    Intel Corporation     20220622   
Sophos Endpoint Self Help                                       3.4.530.0        Sophos Limited        20240116   
Dell SupportAssist OS Recovery Plugin for Dell Update           5.5.4.16189      Dell Inc.             20221111   
Microsoft VC++ redistributables repacked.                       12.0.0.0         Intel Corporation     20220622   
Sophos Diagnostic Utility                                       6.15.1417        Sophos Limited        20240116   
Intel(R) LMS                                                    1.0.0.0          Intel Corporation     20220317   
Sophos Exploit Prevention                                       3.9.1.2325       Sophos Limited        20240116   
Office 16 Click-to-Run Licensing Component                      16.0.16924.20180 Microsoft Corporation 20231213   
Office 16 Click-to-Run Extensibility Component                  16.0.16924.20124 Microsoft Corporation 20231213   
Office 16 Click-to-Run Localization Component                   16.0.16924.20088 Microsoft Corporation 20231213   
Intel(R) Icls                                                   1.0.0.0          Intel Corporation     20220317   
Intel(R) Management Engine Driver                               1.0.0.0          Intel Corporation     20220622   
Intel(R) Serial IO                                              30.100.1943.2    Intel Corporation                
Intel(R) LMS                                                    1.0.0.0          Intel Corporation     20220317   
Windows-PC-Integritätsprüfung                                   3.6.2204.08001   Microsoft Corporation 20220608   
Intel(R) Management Engine Components                           1.0.0.0          Intel Corporation     20220622   
Intel(R) Trusted Connect Service Client x64                     1.63.1155.2      Intel Corporation     20220622   
Sophos File Scanner                                             1.11.3.530       Sophos Limited        20240116   
Local Administrator Password Solution                           6.2.0.0          Microsoft Corporation 20221012   
HP PageWide Pro 477dw MFP - Grundlegende Software für das Gerät 38.9.2003.21350  HP Inc.               20231009   
*/
