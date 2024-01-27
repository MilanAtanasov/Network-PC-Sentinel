using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Network_PC_Sentinel
{
    internal class Computer
    {
        String name;
        List<String> IPs;
        String lastTurnedOnOff;
        List<Software> software = new List<Software>();

        public Computer()
        {

        }

        public Computer(String name, List<String> IPs, List<Software> software, String lastTurnedOnOff)
        {
            this.name = name;
            this.IPs = IPs;
            this.software = software;
            this.lastTurnedOnOff = lastTurnedOnOff;
        }

        public String getName()
        {
            return name;
        }

        public List<String> getIPs()
        {
            return IPs;
        }

        public List<Software> getSoftware()
        {
            return software;
        }


        public String getLastTurnedOnOff()
        {
            return lastTurnedOnOff;
        }


        public void setName(String name)
        {
            this.name = name;
        }


        public void setIPs(List<String> IPs)
        {
            this.IPs = IPs;
        }

        public void setLastTurnedOnOff(String lastTurnedOnOff)
        {
            this.lastTurnedOnOff = lastTurnedOnOff;
        }

        public void setSoftware(List<Software> software)
        {
            this.software = software;
        }



        public override String ToString()
        {
            return "Computer{" + "name=" + name + ", IPs=" + IPs + ", lastTurnedOnOff=" + lastTurnedOnOff + '}';
        }


    }
}
