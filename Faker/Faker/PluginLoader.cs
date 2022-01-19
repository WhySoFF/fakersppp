using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class PluginLoader
    {
        private static readonly string PluginPath = Path.Combine("C:\\Users\\mrsti\\VisualProjects\\FakerSpp", "plugins");
        private Dictionary<Type, IGenerator> generators;

        public PluginLoader(Dictionary<Type, IGenerator> gen)
        {
            this.generators = gen;
        }

        public void LoadPluginGenerators()
        {
            if (!Directory.Exists(PluginPath))
                return;

            string[] files = Directory.GetFiles(PluginPath, "*.dll");

            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFrom(file);
                LoadPluginGenerator(assembly);
            }
        }

        