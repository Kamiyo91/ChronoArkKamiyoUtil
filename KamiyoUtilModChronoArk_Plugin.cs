using ChronoArkMod.Plugin;
using HarmonyLib;

namespace _1ChronoArkKamiyoUtil
{
    public class KamiyoUtilModChronoArk_Plugin : ChronoArkPlugin
    {
        private Harmony _harmony;

        public override void Dispose()
        {
            _harmony.UnpatchSelf();
        }

        public override void Initialize()
        {
            _harmony = new Harmony(GetGuid());
            _harmony.PatchAll();
        }
    }
}