using HarmonyLib;
using Kingmaker.Localization.Shared;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModTag
{
    [HarmonyPatch(typeof(LocalizedString), nameof(LocalizedString.LoadString))]
    internal class DualLanguageMode3
    {
        static void Postfix(ref string __result, ref LocalizedString __instance)
        {
            try
            {
                if (!__result.Contains(".") && !__result.Contains("。")) { return; }
                if (__result.Contains("(mod)")) { return; }
                string actualKey = __instance.GetActualKey();
                LocalizationPack.StringEntry stringEntry;
                if (!pack1.m_Strings.TryGetValue(actualKey, out stringEntry) || !pack2.m_Strings.TryGetValue(actualKey, out stringEntry))
                {
                    __result += " (mod)";
                }
            }
            catch { }
        }

        private static LocalizationPack pack1 = LocalizationManager.LoadPack(Locale.enGB);
        private static LocalizationPack pack2 = LocalizationManager.LoadPack(Locale.zhCN);
    }
}
