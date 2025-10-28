using UnityEngine;

[CreateAssetMenu(fileName = "EndgameData", menuName = "Game/Endgame Data")]
public class EndgameData : ScriptableObject
{
    private float p1Time = 0, p2Time = 0, p3Time = 0;
    public void setP1Time(float time)
    {
        p1Time = time;
    }
    public float getP1Time()
    {
        return p1Time;
    }

    public void setP2Time(float time)
    {
        p2Time = time;
    }
    public float getP2Time()
    {
        return p2Time;
    }

    public void setP3Time(float time)
    {
        p3Time = time;
    }
    public float getP3Time()
    {
        return p3Time;
    }

    public float getFinalTime()
    {
        return p1Time + p2Time + p3Time;
    }
}
