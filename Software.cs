﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_PC_Sentinel
{
    internal class Software
    {

        String name;
        String description;
        String version;
        ArrayList simmularSoftware = new ArrayList();

        public Software(String name, String description, String version)
        {
            this.name = name;
            this.description = description;
            this.version = version;
        }   

        public String getName()
        {
            return name;
        }

        public String getDescription()
        {
            return description;
        }

        public String getVersion()
        {
            return version;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setDescription(String description)
        {
            this.description = description;
        }

        public void setVersion(String version)
        {
            this.version = version;
        }

        public override String ToString()
        {
            return "Software{" + "name=" + name + ", description=" + description + ", version=" + version + '}';
        }

        private void updateSimmularSoftware()
        {
            //TODO
        }

    }
}