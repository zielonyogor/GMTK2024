using System;

[Serializable]
public class GameData
{
    public int level;
    public bool sawCutscene;

    public GameData()
    {
        sawCutscene = false;
        level = 1;
    }
}
