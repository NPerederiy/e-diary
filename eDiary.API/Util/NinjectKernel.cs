using Ninject;
using Ninject.Modules;

namespace eDiary.API.Util
{
    public static class NinjectKernel
    {
        public static IKernel Kernel { get; private set; }

        public static void SetupKernel()
        {
            NinjectModule registrations = new NinjectRegistrations();
            Kernel = new StandardKernel(registrations);
        }
    }
}
