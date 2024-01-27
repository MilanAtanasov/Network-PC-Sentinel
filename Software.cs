using System;
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
        String version;
        String publisher;
        String installDate;
        private String description;
        ArrayList simmularSoftware = new ArrayList();

        public Software(String name) { 
            this.name = name; 
            this.version = "";
            this.publisher = "";
        }

        public Software(String name, String version, String publisher)
        {
            this.name = name;
            this.version = version;
            this.publisher = publisher;
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
        public String getPublisher()
        {
               return publisher;
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

        public void setPublisher(String publisher)
        {
            this.publisher = publisher;
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
