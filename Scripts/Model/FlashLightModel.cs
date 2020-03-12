using System;
using UnityEngine;
using static UnityEngine.Random;


namespace StatsenkoAA
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _batteryChargeMax = 10;
        [SerializeField] private float _intensity = 1.5f;

        private Light _light;
        private Transform _goFollow;
        private Vector3 _offset;
        private float _share;
        private float _takeAwayTheIntensity;

        public float Charge => BatteryChargeCurrent / _batteryChargeMax;
        public float BatteryChargeCurrent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _offset = transform.position - _goFollow.position;
            BatteryChargeCurrent = _batteryChargeMax;
            _light.intensity = _intensity;
            _share = _batteryChargeMax / 4.0f;
            _takeAwayTheIntensity = _intensity / (_batteryChargeMax * 100.0f);
        }

        public void Switch(FlashLightActiveType value)
        {
            switch(value)
            {
                case FlashLightActiveType.On:
                    _light.enabled = true;
                    Transform.position = _goFollow.position + _offset;
                    Transform.rotation = _goFollow.rotation;
                    break;
                case FlashLightActiveType.Off:
                    _light.enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void Rotation()
        {
            Transform.position = _goFollow.position + _offset;
            Transform.rotation = Quaternion.Lerp(Transform.rotation,
                _goFollow.rotation, _speed * Time.deltaTime);
        }

        public bool IsCharging()
        {
            if (BatteryChargeCurrent > 0)
            {
                BatteryChargeCurrent -= Time.deltaTime;

                if (BatteryChargeCurrent < _share)
                {
                    _light.enabled = Range(0, 100) >= Range(0, 10);
                }
                else
                {
                    _light.intensity -= _takeAwayTheIntensity;
                }
                return true;
            }
            return false;
        }

        public bool IsDischarging()
        {
            if (BatteryChargeCurrent < _batteryChargeMax)
            {
                BatteryChargeCurrent += Time.deltaTime * 2.0f;
                return true;
            }
            return false;
        }

        public bool LowBattery()
        {
            return BatteryChargeCurrent <= _batteryChargeMax / 2.0f;
        }
    }
}
