﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ventura.Interfaces
{
    public interface IPrngVentura: IDisposable
    {
	    void Initialise();
	    byte[] GetRandomData(byte[] input);
    }
}
