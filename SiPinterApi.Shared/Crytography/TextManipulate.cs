using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Shared.Crytography
{
    public class TextManipulate
    {
        public static string TextHideDisplay(string InputText)
        {
            string Result = string.Empty;
            if (!string.IsNullOrEmpty(InputText))
            {
                int LenText = InputText.Length;
                if (LenText >= 3)
                {
                    string StartText = InputText.Substring(0, 3);
                    string EndText = InputText.Substring(3);
                    string HideText = new string('*', EndText.Length);

                    Result = StartText + HideText;
                }
                else
                    Result = InputText;
            }
            return Result;
        }

        public static string TextHideDisplayEnd(string InputText)
        {
            string Result = string.Empty;
            if (!string.IsNullOrEmpty(InputText))
            {
                int LenText = InputText.Length;
                if (LenText >= 3)
                {
                    string StartText = InputText.Substring(0, LenText - 3);
                    string EndText = InputText.Substring(LenText - 3, 3);
                    string HideText = new string('*', StartText.Length);

                    Result = HideText + EndText;
                }
                else
                    Result = InputText;
            }
            return Result;
        }

        public static string TextHideDisplayEnd_CovidCollection(string InputText)
        {
            string Result = string.Empty;
            if (!string.IsNullOrEmpty(InputText))
            {
                int LenText = InputText.Length;
                if (LenText >= 6)
                {
                    string StartText = InputText.Substring(0, 4);
                    string MidText = InputText.Substring(4, LenText - 6);
                    string EndText = InputText.Substring(LenText - 2, 2);
                    string HideText = new string('*', MidText.Length);

                    Result = StartText + HideText + EndText;
                }
                else
                    Result = InputText;
            }
            return Result;
        }

        public static string TextHideDisplayStartEnd(string InputText)
        {
            string Result = string.Empty;
            if (!string.IsNullOrEmpty(InputText))
            {
                int LenText = InputText.Length;
                if (LenText >= 3)
                {
                    string StartText = InputText.Substring(0, 1);
                    string MidText = InputText.Substring(1, LenText - 2);
                    string EndText = InputText.Substring(LenText - 1, 1);
                    string HideText = new string('*', MidText.Length);

                    Result = StartText + HideText + EndText;
                }
                else
                    Result = InputText;
            }
            return Result;
        }

        public static string TextHideDisplayStartEndRandom(string InputText)
        {
            string Result = string.Empty;
            if (!string.IsNullOrEmpty(InputText))
            {
                int LenText = InputText.Length;
                if (LenText >= 10)
                {
                    string StartText = InputText.Substring(0, 6);
                    string MidText = InputText.Substring(6, LenText - 10);
                    string EndText = InputText.Substring(LenText - 4, 4);
                    string HideText = new string('*', MidText.Length);

                    Result = StartText + HideText + EndText;
                }
                else
                    Result = InputText;
            }
            return Result;
        }
    }
}
