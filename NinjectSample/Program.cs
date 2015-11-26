using Ninject;
using NinjectSample.Controller;

namespace NinjectSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Creates a GunController that utilizes Ninjects standardkernel
            var handler = new GunController(new StandardKernel());
        }
    }
}