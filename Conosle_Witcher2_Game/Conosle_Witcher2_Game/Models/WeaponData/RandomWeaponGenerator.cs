namespace Conosle_Witcher2_Game.Models.WeaponData
{
    public class RandomWeaponGenerator
    {
        public Weapon GenerateWeapon()
        {
            WeaponFactory weaponFactory = new WeaponFactory();
            IWeapon weapon = weaponFactory.CreateWeapon();
            Weapon createdWeapon = weapon.CreateWeapon();
            return createdWeapon;
        }
    }
}
