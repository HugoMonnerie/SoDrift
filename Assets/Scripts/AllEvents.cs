using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

#region GameManager Events
public class GameMenuEvent : SDD.Events.Event
{
}
public class GamePlayEvent : SDD.Events.Event
{
}
public class GamePauseEvent : SDD.Events.Event
{
}
public class GameResumeEvent : SDD.Events.Event
{
}
public class GameOverEvent : SDD.Events.Event
{
}
public class GameVictoryEvent : SDD.Events.Event
{
}
public class GameMap1Event : SDD.Events.Event
{
}
public class GameMap2Event : SDD.Events.Event
{
}
public class GameMapSelectorEvent : SDD.Events.Event
{
}

public class GameStatisticsChangedEvent : SDD.Events.Event
{
	public float eBestScore { get; set; }
	public float eScore { get; set; }
	public int eNLives { get; set; }
}
#endregion

#region MenuManager Events
public class EscapeButtonClickedEvent : SDD.Events.Event
{ }
public class PlayButtonClickedEvent : SDD.Events.Event
{ }
public class ResumeButtonClickedEvent : SDD.Events.Event
{ }
public class MainMenuButtonClickedEvent : SDD.Events.Event
{ }
public class QuitButtonClickedEvent : SDD.Events.Event
{ }
public class Map1ButtonClickedEvent : SDD.Events.Event
{ }
public class Map2ButtonClickedEvent : SDD.Events.Event
{ }
#endregion

#region Score Event
public class ScoreItemEvent : SDD.Events.Event
{
	public float eScore;
}
#endregion
