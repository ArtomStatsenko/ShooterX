using UnityEngine;


namespace StatsenkoAA
{
    public sealed class FlashLightController: BaseController, IExecute, IInitialization
    {
        private FlashLightModel _flashLightModel;

        public void Initialization()
        {
            UiInterface.LightUiText.SetActive(false);
            UiInterface.FlashLightUiBar.SetActive(false);
        }

        public override void On(params BaseObjectScene[] flashLight)
        {
            if (IsActive) return;
            if (flashLight.Length > 0) _flashLightModel = flashLight[0] as FlashLightModel;
            if (_flashLightModel == null) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) return;
            base.On(_flashLightModel);
            _flashLightModel.Switch(FlashLightActiveType.On);

            UiInterface.LightUiText.SetActive(true);
            UiInterface.FlashLightUiBar.SetActive(true);
            UiInterface.FlashLightUiBar.SetColor(Color.green);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(FlashLightActiveType.Off);

            UiInterface.LightUiText.SetActive(false);
            UiInterface.FlashLightUiBar.SetActive(false);
        }

        public void Execute()
        {
            ManageFlashLight();
        }

        private void ManageFlashLight()
        {
            if (IsActive)
            {
                _flashLightModel.Rotation();

                if (_flashLightModel.LowBattery())
                {
                    UiInterface.FlashLightUiBar.SetColor(Color.red);
                }

                if (_flashLightModel.IsCharging())
                {
                    UiInterface.LightUiText.Text = _flashLightModel.BatteryChargeCurrent;
                    UiInterface.FlashLightUiBar.Fill = _flashLightModel.Charge;
                }
                else
                {
                    Off();
                }
            }
            //else
            //{
            //    if (_flashLightModel.IsDischarging())
            //    {
            //        UiInterface.LightUiText.Text = _flashLightModel.BatteryChargeCurrent;
            //        UiInterface.FlashLightUiBar.Fill = _flashLightModel.Charge;
            //    }
            //}
        }
    }
}
