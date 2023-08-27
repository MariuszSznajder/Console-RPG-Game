namespace Conosle_Witcher2_Game.Models.WeaponData.ConcreteWeapon
{
    internal class Cannon : IWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon
            {
                MaximumShots = 9,
                OneShotDamage = 1,
                WeaponName = "Cannon"
            };
        }
    }
}
