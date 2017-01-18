using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

using WindowsInput;

namespace RemoteControl
{
    static class InputHandler
    {
        public static BinaryFormatter bf = new BinaryFormatter();
        private static StringBuilder inputString = new StringBuilder();
        public static string GetInputAsAString()
        {
            //string inputString = "";
            inputString.Clear();
            if (InputSimulator.IsKeyDown(VirtualKeyCode.ACCEPT))
            {
                inputString.Append(FormatString(VirtualKeyCode.ACCEPT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.ADD))
            {
                inputString.Append(FormatString(VirtualKeyCode.ADD.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.APPS))
            {
                inputString.Append(FormatString(VirtualKeyCode.APPS.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.ATTN))
            {
                inputString.Append(FormatString(VirtualKeyCode.ATTN.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.BACK))
            {
                inputString.Append(FormatString(VirtualKeyCode.BACK.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.BROWSER_BACK))
            {
                inputString.Append(FormatString(VirtualKeyCode.BROWSER_BACK.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.BROWSER_FAVORITES))
            {
                inputString.Append(FormatString(VirtualKeyCode.BROWSER_FAVORITES.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.BROWSER_FORWARD))
            {
                inputString.Append(FormatString(VirtualKeyCode.BROWSER_FORWARD.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.BROWSER_HOME))
            {
                inputString.Append(FormatString(VirtualKeyCode.BROWSER_HOME.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.BROWSER_REFRESH))
            {
                inputString.Append(FormatString(VirtualKeyCode.BROWSER_REFRESH.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.BROWSER_SEARCH))
            {
                inputString.Append(FormatString(VirtualKeyCode.BROWSER_SEARCH.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.BROWSER_STOP))
            {
                inputString.Append(FormatString(VirtualKeyCode.BROWSER_STOP.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.CANCEL))
            {
                inputString.Append(FormatString(VirtualKeyCode.CANCEL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.CAPITAL))
            {
                inputString.Append(FormatString(VirtualKeyCode.CAPITAL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.CLEAR))
            {
                inputString.Append(FormatString(VirtualKeyCode.CLEAR.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.CONTROL))
            {
                inputString.Append(FormatString(VirtualKeyCode.CONTROL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.CONVERT))
            {
                inputString.Append(FormatString(VirtualKeyCode.CONVERT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.CRSEL))
            {
                inputString.Append(FormatString(VirtualKeyCode.CRSEL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.DECIMAL))
            {
                inputString.Append(FormatString(VirtualKeyCode.DECIMAL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.DELETE))
            {
                inputString.Append(FormatString(VirtualKeyCode.DELETE.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.DIVIDE))
            {
                inputString.Append(FormatString(VirtualKeyCode.DIVIDE.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.DOWN))
            {
                inputString.Append(FormatString(VirtualKeyCode.DOWN.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.END))
            {
                inputString.Append(FormatString(VirtualKeyCode.END.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.EREOF))
            {
                inputString.Append(FormatString(VirtualKeyCode.EREOF.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.ESCAPE))
            {
                inputString.Append(FormatString(VirtualKeyCode.ESCAPE.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.EXECUTE))
            {
                inputString.Append(FormatString(VirtualKeyCode.EXECUTE.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.EXSEL))
            {
                inputString.Append(FormatString(VirtualKeyCode.EXSEL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F1))
            {
                inputString.Append(FormatString(VirtualKeyCode.F1.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F2))
            {
                inputString.Append(FormatString(VirtualKeyCode.F2.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F3))
            {
                inputString.Append(FormatString(VirtualKeyCode.F3.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F4))
            {
                inputString.Append(FormatString(VirtualKeyCode.F4.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F5))
            {
                inputString.Append(FormatString(VirtualKeyCode.F5.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F6))
            {
                inputString.Append(FormatString(VirtualKeyCode.F6.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F7))
            {
                inputString.Append(FormatString(VirtualKeyCode.F7.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F8))
            {
                inputString.Append(FormatString(VirtualKeyCode.F8.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F9))
            {
                inputString.Append(FormatString(VirtualKeyCode.F9.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F10))
            {
                inputString.Append(FormatString(VirtualKeyCode.F10.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F11))
            {
                inputString.Append(FormatString(VirtualKeyCode.F11.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.F12))
            {
                inputString.Append(FormatString(VirtualKeyCode.F12.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.FINAL))
            {
                inputString.Append(FormatString(VirtualKeyCode.FINAL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.HANGUL))
            {
                inputString.Append(FormatString(VirtualKeyCode.HANGUL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.HANJA))
            {
                inputString.Append(FormatString(VirtualKeyCode.HANJA.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.HELP))
            {
                inputString.Append(FormatString(VirtualKeyCode.HELP.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.HOME))
            {
                inputString.Append(FormatString(VirtualKeyCode.HOME.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.INSERT))
            {
                inputString.Append(FormatString(VirtualKeyCode.INSERT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.JUNJA))
            {
                inputString.Append(FormatString(VirtualKeyCode.JUNJA.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.KANA))
            {
                inputString.Append(FormatString(VirtualKeyCode.KANA.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.KANJI))
            {
                inputString.Append(FormatString(VirtualKeyCode.KANJI.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.LBUTTON))
            {
                inputString.Append(FormatString(VirtualKeyCode.LBUTTON.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.LCONTROL))
            {
                inputString.Append(FormatString(VirtualKeyCode.LCONTROL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.LEFT))
            {
                inputString.Append(FormatString(VirtualKeyCode.LEFT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.LMENU))
            {
                inputString.Append(FormatString(VirtualKeyCode.LMENU.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.LSHIFT))
            {
                inputString.Append(FormatString(VirtualKeyCode.LSHIFT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.LWIN))
            {
                inputString.Append(FormatString(VirtualKeyCode.LWIN.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.MBUTTON))
            {
                inputString.Append(FormatString(VirtualKeyCode.MBUTTON.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.MENU))
            {
                inputString.Append(FormatString(VirtualKeyCode.MENU.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.MULTIPLY))
            {
                inputString.Append(FormatString(VirtualKeyCode.MULTIPLY.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NEXT))
            {
                inputString.Append(FormatString(VirtualKeyCode.NEXT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMLOCK))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMLOCK.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD0))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD0.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD1))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD1.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD2))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD2.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD3))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD3.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD4))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD4.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD5))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD5.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD6))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD6.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD7))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD7.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD8))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD8.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.NUMPAD9))
            {
                inputString.Append(FormatString(VirtualKeyCode.NUMPAD9.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_1))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_1.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_2))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_2.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_3))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_3.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_4))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_4.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_5))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_5.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_6))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_6.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_7))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_7.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_8))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_8.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_CLEAR))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_CLEAR.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_COMMA))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_COMMA.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_MINUS))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_MINUS.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_PERIOD))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_PERIOD.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.OEM_PLUS))
            {
                inputString.Append(FormatString(VirtualKeyCode.OEM_PLUS.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.PAUSE))
            {
                inputString.Append(FormatString(VirtualKeyCode.PAUSE.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.PLAY))
            {
                inputString.Append(FormatString(VirtualKeyCode.PLAY.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.PRINT))
            {
                inputString.Append(FormatString(VirtualKeyCode.PRINT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.PRIOR))
            {
                inputString.Append(FormatString(VirtualKeyCode.PRIOR.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.RBUTTON))
            {
                inputString.Append(FormatString(VirtualKeyCode.RBUTTON.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.RCONTROL))
            {
                inputString.Append(FormatString(VirtualKeyCode.RCONTROL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.RETURN))
            {
                inputString.Append(FormatString(VirtualKeyCode.RETURN.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.RIGHT))
            {
                inputString.Append(FormatString(VirtualKeyCode.RIGHT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.RMENU))
            {
                inputString.Append(FormatString(VirtualKeyCode.RMENU.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.RSHIFT))
            {
                inputString.Append(FormatString(VirtualKeyCode.RSHIFT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.RWIN))
            {
                inputString.Append(FormatString(VirtualKeyCode.RWIN.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SCROLL))
            {
                inputString.Append(FormatString(VirtualKeyCode.SCROLL.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SELECT))
            {
                inputString.Append(FormatString(VirtualKeyCode.SELECT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SEPARATOR))
            {
                inputString.Append(FormatString(VirtualKeyCode.SEPARATOR.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SHIFT))
            {
                inputString.Append(FormatString(VirtualKeyCode.SHIFT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SLEEP))
            {
                inputString.Append(FormatString(VirtualKeyCode.SLEEP.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SNAPSHOT))
            {
                inputString.Append(FormatString(VirtualKeyCode.SNAPSHOT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SPACE))
            {
                inputString.Append(FormatString(VirtualKeyCode.SPACE.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.SUBTRACT))
            {
                inputString.Append(FormatString(VirtualKeyCode.SUBTRACT.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.TAB))
            {
                inputString.Append(FormatString(VirtualKeyCode.TAB.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.UP))
            {
                inputString.Append(FormatString(VirtualKeyCode.UP.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_0))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_0.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_1))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_1.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_3))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_3.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_4))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_4.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_5))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_5.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_6))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_6.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_7))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_7.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_8))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_8.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_9))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_9.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_A))
            {   
                inputString.Append(FormatString(VirtualKeyCode.VK_A.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_B))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_B.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_C))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_C.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_D))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_D.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_E))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_E.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_F))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_F.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_G))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_G.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_H))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_H.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_I))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_I.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_J))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_J.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_K))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_K.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_L))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_L.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_M))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_M.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_N))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_N.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_O))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_O.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_P))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_P.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_Q))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_Q.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_R))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_R.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_S))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_S.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_T))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_T.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_U))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_U.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_V))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_V.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_W))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_W.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_X))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_X.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_Y))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_Y.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VK_Z))
            {
                inputString.Append(FormatString(VirtualKeyCode.VK_Z.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VOLUME_DOWN))
            {
                inputString.Append(FormatString(VirtualKeyCode.VOLUME_DOWN.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VOLUME_MUTE))
            {
                inputString.Append(FormatString(VirtualKeyCode.VOLUME_MUTE.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.VOLUME_UP))
            {
                inputString.Append(FormatString(VirtualKeyCode.VOLUME_UP.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.XBUTTON1))
            {
                inputString.Append(FormatString(VirtualKeyCode.XBUTTON1.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.XBUTTON2))
            {
                inputString.Append(FormatString(VirtualKeyCode.XBUTTON2.ToString()));
            }
            if (InputSimulator.IsKeyDown(VirtualKeyCode.ZOOM))
            {
                inputString.Append(FormatString(VirtualKeyCode.ZOOM.ToString()));
            }
            return inputString.ToString();
        } 

        private static string FormatString(string text)
        {
            return text + "\n";                                                
        }

    }
}
