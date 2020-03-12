using UnityEngine;


namespace StatsenkoAA
{
    public sealed class InputController : BaseController, IExecute
    {
        private const string MOUSE_SCROLL = "Mouse ScrollWheel";
        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;
        private KeyCode _gun = KeyCode.Alpha1;
        private KeyCode _grenade = KeyCode.Alpha2;
        private int _mouseButton = (int)MouseButton.LeftButton;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
		
        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch(ServiceLocator.Resolve<Inventory>().FlashLight);
            }

            if (Input.GetKeyDown(_gun))
            {
                SelectWeapon(0);
            }

            if (Input.GetKeyDown(_grenade))
            {
                SelectWeapon(1);
            }

            if (Input.GetAxis(MOUSE_SCROLL) > 0)
            {
                SelectWeapon(1);
            }
            else if (Input.GetAxis(MOUSE_SCROLL) < 0)
            {
                SelectWeapon(0);
            }

            if (Input.GetMouseButton(_mouseButton))
            {
                if (ServiceLocator.Resolve<WeaponController>().IsActive)
                {
                    ServiceLocator.Resolve<WeaponController>().Fire();
                }
            }

            if (Input.GetKeyDown(_cancel))
            {
                ServiceLocator.Resolve<WeaponController>().Off();
                ServiceLocator.Resolve<FlashLightController>().Off();
            }

            if (Input.GetKeyDown(_reloadClip))
            {
                ServiceLocator.Resolve<WeaponController>().ReloadClip();
            }
        }


        /// <summary>
        /// Выбор оружия
        /// </summary>
        /// <param name="i">Номер оружия</param>
        private void SelectWeapon(int i)
        {
            ServiceLocator.Resolve<WeaponController>().Off();
            var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; //todo инкапсулировать
            if (tempWeapon != null)
            {
                ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
            }
        }
    }
}
