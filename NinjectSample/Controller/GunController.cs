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

        private void InitiaizeKernel()
        {
            _kernel.Bind<IGun>().To<PipeHandGun>();
            _kernel.Bind<IGun>().To<M16>();
        }

        private void GunSelection()
        {
            Console.WriteLine("Select a gun: \n" +
                            "1: Rifle\n" +
                            "2: Pistol\n");
            try
            {
                var selection = int.Parse(Console.ReadLine());

                //Ninjects finds the proper gun
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
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please select a valid gun.");
                GunSelection();
            }
        }

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