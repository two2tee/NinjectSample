using NinjectSample.Interface;

namespace NinjectSample.Guns
{
    /// <summary>
    ///     BaseGun is an abstract class that implements IGun.
    ///     The base gun is only used as a super class.
    /// </summary>
    public abstract class BaseGun : IGun
    {
        private readonly int _maxAmmoCapacity;
        private readonly string _name;
        private int _ammo;

        /// <summary>
        ///     Constructor to define name, and ammo capacity of gun.
        /// </summary>
        /// <param name="ammoCapacity"> </param>
        /// <param name="name"></param>
        protected BaseGun(int ammoCapacity, string name)
        {
            _name = name;
            _maxAmmoCapacity = ammoCapacity;
            _ammo = _maxAmmoCapacity;
        }

        /// <summary>
        ///     Returns name of gun.
        /// </summary>
        public string Name => "Weapon type: " + _name;

        /// <summary>
        ///     Simulates a fire sequence of a gun.
        ///     Gun is unable to fire if it is out of ammo.
        /// </summary>
        /// <returns> a string that illustrates the sequence </returns>
        public string Fire()
        {
            if (_ammo == 0) return "Out of ammo.";

            _ammo--;
            return "\nFiring " + Name + " ===> PEW PEW\n" + ShowAmmo();
        }

        /// <summary>
        ///     Simulates a reload sequence of a gun.
        /// </summary>
        /// <returns> a string that illustrates the sequence </returns>
        public string Reload()
        {
            _ammo = _maxAmmoCapacity;
            return Name + " ===> " + "Reloaded";
        }

        /// <summary>
        ///     Shows current ammo status
        /// </summary>
        /// <returns> a string of ammo left in gun </returns>
        public string ShowAmmo()
        {
            return "Ammo: " + _ammo + "/" + _maxAmmoCapacity;
        }

        /// <summary>
        /// Returns name of gun
        /// </summary>
        /// <returns> String</returns>
        public string GetName()
        {
            return _name;
        }
    }
}