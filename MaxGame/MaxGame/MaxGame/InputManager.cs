using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    static class InputManager
    {
        public const int LEFT_BUTTON = 0;
        public const int RIGHT_BUTTON = 1;
        public const int POSITION = 2;

        static Dictionary<int, List<GameAction>> myMouseMap = new Dictionary<int, List<GameAction>>();

        static Dictionary<Keys, List<GameAction>> myKeyboardMap = new Dictionary<Keys, List<GameAction>>();

        public static void AddToMap<T>(Dictionary<T, List<GameAction>> map, T key, GameAction action)
        {
            List<GameAction> keyList = new List<GameAction>();

            if (map.ContainsKey(key))
            {
                keyList = map[key];
                map.Remove(key);
            }
            keyList.Add(action);
            map.Add(key, keyList);
        }

        public static void AddToMouseMap(int button, GameAction action)
        {
            AddToMap<int>(myMouseMap, button, action);
        }

        public static void AddToKeyboardMap(Keys key, GameAction action)
        {
            AddToMap<Keys>(myKeyboardMap, key, action);
        }

        public static void ActMouse(MouseState mouseState)
        {
            object[] parameterList = new object[1];
            parameterList[0] = new Vector2(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed && myMouseMap.ContainsKey(LEFT_BUTTON))
            {
                foreach (GameAction a in myMouseMap[LEFT_BUTTON])
                {
                    a.Invoke(parameterList);
                }
            }
            if (mouseState.RightButton == ButtonState.Pressed && myMouseMap.ContainsKey(RIGHT_BUTTON))
            {
                foreach (GameAction a in myMouseMap[RIGHT_BUTTON])
                {
                    a.Invoke(parameterList);
                }
            }
            if (myMouseMap.ContainsKey(POSITION))
            {
                foreach (GameAction a in myMouseMap[POSITION])
                {
                    a.Invoke(parameterList);
                }
            }
        }

        public static void ActKeyboard(KeyboardState keyState)
        {
            Keys[] allPressed = keyState.GetPressedKeys();
            foreach (Keys k in allPressed)
            {
                if (myKeyboardMap.ContainsKey(k))
                {
                    List<GameAction> actionList = myKeyboardMap[k];
                    foreach (GameAction action in actionList)
                    {
                        action.Invoke();
                    }
                }
            }
        }
    }
}
