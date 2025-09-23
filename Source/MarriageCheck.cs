using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
public class RitualRoleTag_NotMarriedAlready : RitualRole
{
    public string tag;

    public override bool AppliesToRole(
      Precept_Role role,
      out string reason,
      Precept_Ritual ritual = null,
      Pawn p = null,
      bool skipReason = false)
    {
        reason = (string)null;
        int num1;
        if (p == null)
        {
            num1 = 0;
        }
        else
        {
            int? marriageNumber = p.GetSpouseCount(false);
            int num2 = 0;
            num1 = marriageNumber.GetValueOrDefault() > num2 & marriageNumber.HasValue ? 1 : 0;
        }
        if (num1 != 0)
        {
            if (!skipReason)
                reason = (string)"NikolaisIdeology_MustNotBeMarried".Translate();
            return false;
        }
        if (ritual != null && p != null && p.Ideo != ritual.ideo)
        {
            if (!skipReason)
                reason = (string)"MessageRitualRoleMustHaveIdeoToDoRole".Translate((NamedArgument)Find.ActiveLanguageWorker.WithIndefiniteArticle(ritual.ideo.memberName), (NamedArgument)Find.ActiveLanguageWorker.WithIndefiniteArticle((string)this.Label));
            return false;
        }
        if (role != null && role.def.roleTags != null && role.def.roleTags.Contains(this.tag) || this.substitutable && p != null && ritual != null && p.Ideo == ritual.ideo)
        {
            if (p == null || p.Faction.IsPlayerSafe())
                return true;
            if (!skipReason)
                reason = (string)"MessageRitualRoleMustBeColonist".Translate((NamedArgument)this.Label);
            return false;
        }
        if (p != null)
        {
            IEnumerable<PreceptDef> source = DefDatabase<PreceptDef>.AllDefsListForReading.Where<PreceptDef>((Func<PreceptDef, bool>)(d => typeof(Precept_Role).IsAssignableFrom(d.preceptClass) && d.roleTags != null && d.roleTags.Contains(this.tag)));
            if (!skipReason)
                reason = (string)("MessageRitualRoleRequired".Translate((NamedArgument)(Thing)p) + ": " + source.Select<PreceptDef, string>((Func<PreceptDef, string>)(r => ritual?.ideo.GetPrecept(r)?.LabelCap ?? (string)r.LabelCap)).ToCommaList());
        }
        return false;
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look<string>(ref this.tag, "tag");
    }
}
}