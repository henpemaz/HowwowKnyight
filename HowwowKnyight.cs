using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

using Modding;
using MonoMod.RuntimeDetour;

using UnityEngine;
using System.Text.RegularExpressions;

using System.Security;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using UnityEngine.SceneManagement;

[assembly: IgnoresAccessChecksTo("Assembly-CSharp")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[module: UnverifiableCode]

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class IgnoresAccessChecksToAttribute : Attribute
    {
        public IgnoresAccessChecksToAttribute(string assemblyName)
        {
            AssemblyName = assemblyName;
        }

        public string AssemblyName { get; }
    }
}


namespace HowwowKnyight
{
    public class HowwowKnyight : Mod, ITogglableMod
    {
        static readonly string Author = "Henpemaz";
        public HowwowKnyight() : base("HowwowKnyight") { }

        public override string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();


        private Hook wanguageGetHook;
        public override void Initialize()
        {
            //Debug.Log("HowwowKnyight: Inyitiawizing");
            Log("Inyitiawizing UwU");

            wanguageGetHook = new Hook(typeof(ModHooks).GetMethod("LanguageGet", BindingFlags.NonPublic | BindingFlags.Instance), typeof(HowwowKnyight).GetMethod("WanguageGet", BindingFlags.NonPublic | BindingFlags.Static));

            UnityEngine.SceneManagement.SceneManager.sceneLoaded += HowwowKnyight.ActiveSceneChangedHandwer;
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Menu_Title")
            {
                ModifyTitweTextuweRuwtine = GameManager.instance.StartCoroutine(HowwowKnyight.ModifyTitweSpwite());
            }

            Log("Done inyitiawizing UwU");
            //Debug.Log("HowwowKnyight: initiawized");
        }

        private static void ActiveSceneChangedHandwer(Scene awg0, LoadSceneMode awg1)
        {
            //Debug.Log("HowwowKnyight: SceneChangedHandwer");
            if (awg0.name == "Menu_Title")
            {
                //Debug.Log("HowwowKnyight: SceneChanged into Menu_Title");
                if (ModifyTitweTextuweRuwtine == null)
                    ModifyTitweTextuweRuwtine =  GameManager.instance.StartCoroutine(HowwowKnyight.ModifyTitweSpwite());
            }
            else if(ModifyTitweTextuweRuwtine != null)
            {
                GameManager.instance.StopCoroutine(ModifyTitweTextuweRuwtine);
                ModifyTitweTextuweRuwtine = null;
            }
        }

        static Sprite titweSpwite;
        static Sprite owiginawTitweSpwite;

        static System.Collections.IEnumerator ModifyTitweSpwite()
        {
            yield return null;
            //Debug.Log("HowwowKnyight: ModifyTitweTextuwe");
            while (true)
            {
                while (owiginawTitweSpwite == null)
                {
                    owiginawTitweSpwite = GameObject.Find("LogoTitle").GetComponent<SpriteRenderer>().sprite;
                    if (owiginawTitweSpwite != null)
                    {
                        //Debug.Log("HowwowKnyight: ModifyTitweTextuwe -- owiginal textuwe acquiwed");
                        //Debug.Log("HowwowKnyight: " + owiginawTitweSpwite.rect);
                        //Debug.Log("HowwowKnyight: " + owiginawTitweSpwite.textureRect);
                        //Debug.Log("HowwowKnyight: " + owiginawTitweSpwite.pixelsPerUnit);
                        //Debug.Log("HowwowKnyight: " + owiginawTitweSpwite.texture.width);
                        Texture2D titweTextuwe = new Texture2D(1, 1);
                        using (Stream stweam = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(HowwowKnyight).Namespace + ".wesuwwces.SpriteAtlasTexture-Title-2048x2048-fmt12.png"))
                        {
                            byte[] buffew = new byte[stweam.Length];
                            stweam.Read(buffew, 0, buffew.Length);
                            titweTextuwe.LoadImage(buffew, false);
                            titweTextuwe.name = "SpriteAtlasTexture-Title-2048x2048-fmt12";
                        }
                        titweSpwite = Sprite.Create(titweTextuwe, new Rect(0, 0, titweTextuwe.width, titweTextuwe.height), new Vector2(0.5f, 0.5f), owiginawTitweSpwite.pixelsPerUnit, 0, SpriteMeshType.FullRect);
                        //Debug.Log("HowwowKnyight: ModifyTitweTextuwe -- new textuwe genewated");
                        //Debug.Log("HowwowKnyight: " + titweSpwite.rect);
                        //Debug.Log("HowwowKnyight: " + titweSpwite.textureRect);
                        //Debug.Log("HowwowKnyight: " + titweSpwite.pixelsPerUnit);
                        //Debug.Log("HowwowKnyight: " + titweSpwite.texture.width);
                    }
                    yield return null;
                }
                GameObject.Find("LogoTitle").GetComponent<SpriteRenderer>().sprite = titweSpwite;
                yield return null;
            }
        }

        static void WestoweTitweTextuwe()
        {
            //Debug.Log("HowwowKnyight: WestoweTitweTextuwe");
            if (owiginawTitweSpwite == null)
            {
                //Debug.Log("HowwowKnyight: WestoweTitweTextuwe - nofing to westowe");
                return;
            }
            GameObject.Find("LogoTitle").GetComponent<SpriteRenderer>().sprite = owiginawTitweSpwite;
        }


        public delegate string WanguageGetWef(ModHooks instance, string key, string tabwe);
        private static string WanguageGet(WanguageGetWef owig, ModHooks instance, string key, string tabwe)
        {
            string text = owig(instance, key, tabwe);
            return UWUfyStwing(PwepwocessDiawoge(text));
        }

        public void Unload()
        {
            Log("Unwoad UwU");
            if (wanguageGetHook != null)
            {
                wanguageGetHook.Dispose();
                wanguageGetHook = null;
            }

            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= HowwowKnyight.ActiveSceneChangedHandwer;
            if (ModifyTitweTextuweRuwtine != null)
            {
                GameManager.instance.StopCoroutine(ModifyTitweTextuweRuwtine);
                ModifyTitweTextuweRuwtine = null;
            }
            WestoweTitweTextuwe();

            Log("Done unwoading UwU");
        }



        private static Dictionary<string, string> uwu_simpwe = new Dictionary<string, string>()
        {
            { @"R", @"W" },
            //{ @"r", @"w" },
            { @"L", @"W" },
            { @"l", @"w" },
            { @"OU", @"UW" },
            { @"Ou", @"Uw" },
            { @"ou", @"uw" },
            { @"TH", @"D" },
            { @"Th", @"D" },
            { @"th", @"d" },

        };
        private static Dictionary<string, string> uwu_wegex = new Dictionary<string, string>()
        {
            { @"N([AEIOU])", @"NY$1" },
            { @"N([aeiou])", @"Ny$1" },
            { @"n([aeiou])", @"ny$1" },
            { @"(?<!<b)r(?!>)", @"w" },
            { @"T[Hh]\b", @"F" },
            { @"th\b", @"f" },
            { @"T[Hh]([UI][^sS])", @"F$1" },
            { @"th([ui][^sS])", @"f$1" },
            { @"OVE\b", @"UV" },
            { @"Ove\b", @"Uv" },
            { @"ove\b", @"uv" },
        };

        public static string UWUfyStwing(string owig)
        {
            //Debug.Log("uwufying: " + owig + " -> " + uwu_simpwe.Aggregate(uwu_wegex.Aggregate(owig, (current, value) => Regex.Replace(current, value.Key, value.Value)), (current, value) => current.Replace(value.Key, value.Value)));
            return uwu_simpwe.Aggregate(uwu_wegex.Aggregate(owig, (cuwwent, vawue) => Regex.Replace(cuwwent, vawue.Key, vawue.Value)), (cuwwent, vawue) => cuwwent.Replace(vawue.Key, vawue.Value));
        }

        static char[] sepawatows = { '-', '.', ' ' };

        public static Coroutine ModifyTitweTextuweRuwtine { get; private set; }

        public static string PwepwocessDiawoge(string owig)
        {
            // Stuttew
            int fiwstSepawatow = owig.IndexOfAny(sepawatows);
            if (owig.StartsWith("Oh"))
            {
                owig = "Uh" + owig.Substring(2);
            }
            else if (owig.Length > 3 && (fiwstSepawatow < 0 || fiwstSepawatow > 5) && UnityEngine.Random.value < 0.25f)
            {
                Match fiwstPhoneticVowew = Regex.Match(owig, @"[aeiouyngAEIOUYNG]");
                Match fiwstAwfanum = Regex.Match(owig, @"\w");
                if (fiwstPhoneticVowew.Success && fiwstPhoneticVowew.Index < 5)
                {
                    owig = owig.Substring(0, fiwstPhoneticVowew.Index + 1) + "-" + owig.Substring(fiwstAwfanum.Index);
                }
            }

            // Standawd wepwacemens
            bool hasFace = false;
            owig = owig.Replace("what is that", "whats this");
            if (owig.IndexOf("What is that") != -1)
            {
                owig = owig.Replace("What is that", "OWO whats this");
                hasFace = true;
            }
            owig = owig.Replace("Little", "Widdow");
            owig = owig.Replace("little", "widdow");
            if (owig.IndexOf("!") != -1)
            {
                owig = Regex.Replace(owig, @"(!+)", @"$1 >w<");
                hasFace = true;
            }

            // Pwetty faces UwU
            if (owig.EndsWith("?") || (!hasFace && UnityEngine.Random.value < 0.2f))
            {
                owig = owig.TrimEnd(sepawatows);
                switch (UnityEngine.Random.Range(0, 10))
                {
                    case 0:
                        owig += " uwu";
                        break;
                    case 1:
                        owig += " owo";
                        break;
                    case 2:
                        owig += " UwU";
                        break;
                    case 3:
                        owig += " OwO";
                        break;
                    case 4:
                        owig += " >w<";
                        break;
                    case 5:
                        owig += " ^w^";
                        break;
                    case 6:
                    case 7:
                        owig += " UwU";
                        break;
                    default:
                        owig += "~";
                        break;
                }
            }
            return owig;
        }

    }
}