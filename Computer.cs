using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_PC_Sentinel
{
    internal class Computer
    {
        String name;
        ArrayList IPs;
        String lastTurnedOnOff;
        ArrayList software = new ArrayList();

        public Computer(String name, ArrayList IPs, String lastTurnedOnOff)
        {
            this.name = name;
            this.IPs = IPs;
            this.lastTurnedOnOff = lastTurnedOnOff;
        }

        public String getName()
        {
            return name;
        }

        public ArrayList getIPs()
        {
            return IPs;
        }

        public String getLastTurnedOnOff()
        {
            return lastTurnedOnOff;
        }


        public void setName(String name)
        {
            this.name = name;
        }


        public void setIPs(ArrayList IPs)
        {
            this.IPs = IPs;
        }

        public void setLastTurnedOnOff(String lastTurnedOnOff)
        {
            this.lastTurnedOnOff = lastTurnedOnOff;
        }

        public override String ToString()
        {
            return "Computer{" + "name=" + name + ", IPs=" + IPs + ", lastTurnedOnOff=" + lastTurnedOnOff + '}';
        }

        public void addSoftware(Software software)
        {
            this.software.Add(software);
        }

    }
}
