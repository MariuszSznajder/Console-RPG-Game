namespace Conosle_Witcher2_Game.Models.WeaponData.ConcreteWeapon
{
    internal class BladeOfChaos : IWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon
            {
                MaximumShots = 20,
                OneShotDamage = 1,
                WeaponName = "Blade of Chaos"
            };
        }
    }
}
