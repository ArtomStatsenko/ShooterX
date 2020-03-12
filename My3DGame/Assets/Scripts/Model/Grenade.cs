namespace StatsenkoAA
{
    public sealed class Grenade : Weapon
    {
        public override void Fire()
        { 
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.forward * _force);
            Clip.CountAmmunition--;
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechergeTime);

            ReloadClip();
            gameObject.SetActive(false);
            Invoke(nameof(SetGrenadeActive), _rechergeTime);
        }

        private void SetGrenadeActive()
        {
            gameObject.SetActive(true);
        }
    }
}