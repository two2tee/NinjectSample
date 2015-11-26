using System;
using Ninject;
using NinjectSample.Guns;
using NinjectSample.Interface;

namespace NinjectSample.Controller
{
    public class GunController
    {
        private readonly IKernel _kernel;
        private IGun _selectedGun;

        /// <summary>
        ///     Constructor for the gun controller. It utalizes Ninject so one must specify a kernel to be
        ///     used.
        /// </summary>
        /// <param name="kernel"> Some implementation of IKernel. </param>
        public GunController(IKernel kernel)
        {
            _kernel = kernel;
            InitiaizeKernel();

            GunSelection();
            while (true)
            {
                GunAction(); // Simulate gun
            }
        }

        /// <summary>
        ///     Sets the bindings that are to be used.
        /// </summary>
        private void InitiaizeKernel()
        {
            _kernel.Bind<IGun>().To<PipeHandGun>();
            _kernel.Bind<IGun>().To<M16>();
        }

        /// <summary>
        ///     Let user select a gun of their choice
        /// </summary>
        private void GunSelection()
        {
            Console.WriteLine("Select a gun: \n" +
                              "1: Rifle\n" +
                              "2: Pistol\n");
            try
            {
                var selection = int.Parse(Console.ReadLine());

                //Ninjects returns an instace of the selected gun
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("M16 combat rifle selected.");
                        _selectedGun = _kernel.Get<M16>();
                        break;
                    case 2:
                        Console.WriteLine("pipe pistol selected.");
                        _selectedGun = _kernel.Get<PipeHandGun>();
                        break;
                    default:
                        Console.WriteLine("Please select a valid gun.");
                        GunSelection();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please select a valid gun.");
                GunSelection();
            }
        }


        /// <summary>
        ///     perfom an actions specified by the user. Eg. Fire a gun.
        /// </summary>
        private void GunAction()
        {
            Console.WriteLine("Gun Action: \n" +
                              "1: Shoot\n" +
                              "2: Reload\n");
            try
            {
                var selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        Console.WriteLine(_selectedGun.Fire());
                        break;
                    case 2:
                        Console.WriteLine(_selectedGun.Reload());
                        break;
                    default:
                        Console.WriteLine("Invalid action.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please select a valid action.");
            }
        }
    }
}