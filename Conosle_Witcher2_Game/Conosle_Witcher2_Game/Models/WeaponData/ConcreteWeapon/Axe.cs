namespace Conosle_Witcher2_Game.Models.WeaponData.ConcreteWeapon
{
    internal class Axe : IWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon
            {
                MaximumShots = 12,
                OneShotDamage = 2,
                WeaponName = "Axe"
            };
        }
    }
}
