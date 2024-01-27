using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
                    instance.updateData();
                }
                return instance;
            }
        }


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
                List<String> ips = (List<String>)computerData[1];
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
                List<String> ips = new List<String>();
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
                            List<string> parsedSoftwareData = SoftwareDataParser(line);
                            if (parsedSoftwareData.Count == 1)
                            {
                                software.Add(new Software(parsedSoftwareData[0]));
                            }
                            else if (parsedSoftwareData.Count == 2)
                            {
                                software.Add(new Software(parsedSoftwareData[0], parsedSoftwareData[1], ""));
                            }
                            else if (parsedSoftwareData.Count <= 3)
                            {
                                software.Add(new Software(parsedSoftwareData[0], parsedSoftwareData[1], parsedSoftwareData[2]));
                            }
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

            List<String> files = new List<String>();

            // first try to see if the path exists
            if (Directory.Exists(path))
            {
                // get all the files in the path
                files.AddRange(Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories));
            }
            /*
            else
            {
                // if the path does not exist, create it
                Directory.CreateDirectory(path);
            }*/

            
            
            foreach (String fileName in files)
            {
                List<String> fileData = new List<String>();
                fileData.Add(fileName.Replace(path, "").ToUpper().Replace(".TXT", "").Replace("\\", ""));
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

        public static List<string> SoftwareDataParser(string softwareData)
        {
            List<string> softwareDataList = new List<string>();
            // Split the input string into lines
            string[] splitData = softwareData.Split("  ");

            // Add the first line to the list, and remove it from the array
            softwareDataList.Add(splitData[0]);
            splitData = splitData.Skip(1).ToArray();

            // Clean up  the array, of empty lines
            splitData = splitData.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            // Clean up the array, of lines that are only spaces
            splitData = splitData.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            // Check if there is a version number (numbers and dots) in a string together with a publisher
            foreach (string line in splitData)
            {
                if (line.Contains(".") && line.Any(char.IsDigit))
                {
                    softwareDataList.Add(line);
                    splitData = splitData.Where(x => x != line).ToArray();
                    break;
                }
                
            }

            // Check if there is a publisher, it is the last sentence in the array
            foreach (string line in splitData)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    softwareDataList.Add(line);
                }

            }
            return softwareDataList;
        }

    }
}

