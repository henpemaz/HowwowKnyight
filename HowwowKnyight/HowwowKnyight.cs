using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

using Modding;
using MonoMod.RuntimeDetour;

using UnityEngine;
using UnityEngine.SceneManagement;

using System.Text.RegularExpressions;
using System.Security;
using System.Security.Permissions;


//[assembly: IgnoresAccessChecksTo("Assembly-CSharp")]
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
    /*
	   Place your code on github text time ok? This looks way better then what I originally did. xD
	   I'm also going to be adding random comments, just ignore them please. I use them make make my brain not explode.
	   If you encounter any bug, IDK how to contact the creator, so just contact me: Ruttie#3005 on Discord.
	   Will I be updating this to 1.5? Idk you'll have to see! :3
	   (I had no idea what random to use, so i just used unity.)
       Oh and status update: I found the creator and he gave me this! You can now contact me (@Ruttie#3005) or the creator (@Henpemaz#9262)!
       I have no idea if he wants to be contacted, so the better option is to contact me (@Ruttie#3005).
	   ~Ruttie
	*/
    public class HowwowKnyight : Mod, ITogglableMod
    {
        static readonly string Author = "Henpemaz";
        static readonly string Contributor = "Ruttie";
        public HowwowKnyight() : base("HowwowKnyight") { }

        public override string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        //int[] nums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //sry RedFrog
        Regex r = new Regex(@"\d", RegexOptions.IgnoreCase); //go SFG

        private Hook wanguageGetHook;
        public override void Initialize()
        {
            //Debug.Log("HowwowKnyight: Inyitiawizing");
            Log("Inyitiawizing UwU");

            wanguageGetHook = new Hook(typeof(ModHooks).GetMethod("LanguageGet", BindingFlags.NonPublic | BindingFlags.Instance), typeof(HowwowKnyight).GetMethod("WanguageGet", BindingFlags.NonPublic | BindingFlags.Static));
            //ModHooks.Instance.LanguageGetHook += wanguageGetHook;
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += HowwowKnyight.ActiveSceneChangedHandwer;
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Menu_Title")
            {
                try
                {
                    ModifyTitweTextuweRuwtine = GameManager.instance.StartCoroutine(HowwowKnyight.ModifyTitweSpwite());
                }
                catch
                {
                    Unload();
                }
            }

            Log("Done inyitiawizing UwU");
            Log("Mwade bwy: " + Author + ", and fyixed annoying softlock bwy: " + Contributor + ". Enjoy :3 ~Ruttie");
            Log("If you encounter any bug, (and read this), (~~IDK how to contact the creator~~) see what i posted above in the code, so just conact me: Ruttie#3005 on Discord.");
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
            Regex r = new Regex(@"\d", RegexOptions.IgnoreCase); //i hope this works SFG
            MatchCollection matches = r.Matches(text);
            if (matches.Count > 0)
            {
                //Modding.Logger.Log("Theres a number here!");
                //Debug.Log("Theres a number here!");
                //No longer needed, it worked! OwO
                return (text);
            }
            else
            {
                //Modding.Logger.Log("Found something usefull");
                //Debug.Log("Found something usefull");
                //Sorry everyone in modding-development for me being dumb and using the worng dll!
                try
                {
                    return UWUfyStwing(PwepwocessDiawoge(text));
                }
                catch
                {
                    Modding.Logger.Log("Something terrible has happened! Please contact me with this info!");
                    return (text);
                }
            }
        }

        public void Unload()
        {
            Log("Unwoad UwU");
            try
            {
                
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
            catch
            {
                Log("It seems like unloading has failed! Please let me know!");
            }
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