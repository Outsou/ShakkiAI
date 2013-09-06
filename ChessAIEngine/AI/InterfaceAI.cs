﻿using System;
using System.Collections.Generic;
using System.Text;
using ChessEngine.Engine;

namespace ChessEngine.AI
{
    interface InterfaceAI
    {
        AIMove GetAIMove(ChessEngine.Engine.Engine engine);
    }
}