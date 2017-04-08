using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator instance;
        private Dictionary<string,Logger> services;

        public ServiceLocator()
        {
            this.services = new Dictionary<string, Logger>();
        }

        public static ServiceLocator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceLocator();
                }

                return instance;
            }
        }

        public void AddService(string name,Logger logger)
        {
            this.services.Add(name, logger);
        }

        public Logger GetService(string name)
        {
           
            return this.services.FirstOrDefault(s => s.Key == name).Value;
        }
    }
}
