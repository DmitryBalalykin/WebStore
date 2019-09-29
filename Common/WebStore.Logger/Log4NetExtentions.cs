using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WebStore.Logger
{
    public static class Log4NetExtentions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, 
                                                string configurationFile = "log4net.config")
        {
            if (!Path.IsPathRooted(configurationFile))
            {
                var assemble = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException("Не найдена сборка исполнительного файла");
                var dir = Path.GetDirectoryName(assemble.Location) ?? throw new InvalidOperationException ("Не определена дирректория исполнительного файла");
                configurationFile = Path.Combine(dir, configurationFile);

            }

            factory.AddProvider(new Log4NetLoggerProvider(configurationFile));
            return factory;
        }
    }
}
