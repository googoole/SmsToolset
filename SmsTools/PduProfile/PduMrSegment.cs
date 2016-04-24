﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsTools.PduProfile
{
    /// <summary>
    /// MR
    /// </summary>
    public class PduMrSegment : IPduSegment
    {
        private int _mr = 0;

        public PduSegment Type { get { return PduSegment.MessageReference; } }

        public PduMrSegment(IPduProfileSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("Profile settings not specified.");

            if (settings.MessageReference != null)
            {
                if (settings.MessageReference.Value < 0 || settings.MessageReference.Value > 255)
                    throw new ArgumentException("Message id out of range.");

                _mr = settings.MessageReference.Value;
            }
        }

        public PduMrSegment()
        {
        }

        public int Length()
        {
            return 1;
        }

        public override string ToString()
        {
            return $"{_mr.ToString("X2")}";
        }
    }
}
