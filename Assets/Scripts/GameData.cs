using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[Serializable]
public class GameData
{
    public int level;
    public bool sawCutscene;
    public List<bool> completedWithSpecial;

    public GameData()
    {
        sawCutscene = false;
        level = 1;
        completedWithSpecial = new List<bool>(Constants.maxLevel);
        completedWithSpecial.AddRange(Enumerable.Repeat(false, Constants.maxLevel));
    }
}
