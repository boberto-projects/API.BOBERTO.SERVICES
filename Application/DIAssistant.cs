using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.APPLICATION
{


    public static class DIAssistant
    {
        public static void DI<T>(this T instance, IServiceProvider serviceProvider)
        {
            foreach (var prop in instance.GetType().GetRuntimeProperties())
            {
                var service = serviceProvider.GetService(prop.PropertyType);
                if (service == null)
                {
                    continue;
                }
                prop.SetValue(instance, service);
            }
        }
    }
}
