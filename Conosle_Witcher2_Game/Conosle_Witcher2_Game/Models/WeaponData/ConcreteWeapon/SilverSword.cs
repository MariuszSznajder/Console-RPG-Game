namespace Conosle_Witcher2_Game.Models.WeaponData.ConcreteWeapon
{
    internal class SilverSword : IWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon
            {
                MaximumShots = 15,
                OneShotDamage = 2,
                WeaponName = "Silver Sword"
            };
        }


    }
}
