using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace MaxGame
{
    class GameAction
    {
        Sprite myActor;
        MethodInfo myMethod;
        object[] myParameters;

        public GameAction(Sprite actor, MethodInfo method, object[] param)
        {
            myActor = actor;
            myMethod = method;
            myParameters = param;
        }

        public void Invoke()
        {
            myMethod.Invoke(myActor, myParameters);
        }
        public void Invoke(object[] myParameters)
        {
            myParameters = myParameters;
            myMethod.Invoke(myActor, myParameters);
        }
    }
}

