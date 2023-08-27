namespace Conosle_Witcher2_Game.Models.WeaponData.ConcreteWeapon
{
    internal class SteelSword : IWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon
            {
                MaximumShots = 8,
                OneShotDamage = 2,
                WeaponName = "Steel Sword"
            };
        }
    }
}
