using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
