using Conosle_Witcher2_Game.Models.WeaponData.ConcreteWeapon;

namespace Conosle_Witcher2_Game.Models.WeaponData
{
    internal class WeaponFactory
    {
        private readonly Random random;

        public WeaponFactory()
        {
            this.random = new Random();
        }

        public IWeapon CreateWeapon()
        {
            int weapon = random.Next(1, 6);

            return weapon switch
            {
                1 => new Axe(),
                2 => new SilverSword(),
                3 => new SteelSword(),
                4 => new BladeOfChaos(),
                5 => new Cannon(),
            };
        }
    }
}
