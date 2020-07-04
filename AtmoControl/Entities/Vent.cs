﻿using SpaceEngineers.Game.ModAPI.Ingame;


namespace IngameScript
{
    class Vent : BaseEntity
    {
        private const float SAFE_O2_THRESHOLD = 0.98f;
        private IMyAirVent _block;

        public Vent(IMyAirVent block) : base(block)
        {
            _block = block;
            Room1 = GetIniString("Room");
        }

        public string Room1 { get; set; }

        public float OxygenLevel
        {
            get
            {
                return _block.GetOxygenLevel();
            }
        }

        /// <summary>
        /// A vent is considered "Safe" if the O2 level is above 95%
        /// and it is not set to depressurise.
        /// </summary>
        public bool Safe
        {
            get
            {
                return _block.Depressurize == false && OxygenLevel > SAFE_O2_THRESHOLD;
            }
        }

        public bool Unsafe
        {
            get
            {
                return !Safe;
            }
        }
    }
}
