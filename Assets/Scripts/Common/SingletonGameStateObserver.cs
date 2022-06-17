using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;
using System;
using UnityEngine.SceneManagement;

public abstract class SingletonGameStateObserver<T> :  Singleton<T>,IEventHandler where T:Component
{
	public virtual void SubscribeEvents()
	{
		EventManager.Instance.AddListener<GameMenuEvent>(GameMenu);
		EventManager.Instance.AddListener<GamePlayEvent>(GamePlay);
		EventManager.Instance.AddListener<GamePauseEvent>(GamePause);
		EventManager.Instance.AddListener<GameResumeEvent>(GameResume);
		EventManager.Instance.AddListener<GameOverEvent>(GameOver);
		EventManager.Instance.AddListener<GameVictoryEvent>(GameVictory);
		EventManager.Instance.AddListener<GameMap1Event>(GameMap1);
		EventManager.Instance.AddListener<GameMap2Event>(GameMap2);
		EventManager.Instance.AddListener<GameMapSelectorEvent>(GameMapSelector);
		EventManager.Instance.AddListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
	}

	public virtual void UnsubscribeEvents()
	{
		EventManager.Instance.RemoveListener<GameMenuEvent>(GameMenu);
		EventManager.Instance.RemoveListener<GamePlayEvent>(GamePlay);
		EventManager.Instance.RemoveListener<GamePauseEvent>(GamePause);
		EventManager.Instance.RemoveListener<GameResumeEvent>(GameResume);
		EventManager.Instance.RemoveListener<GameOverEvent>(GameOver);
		EventManager.Instance.RemoveListener<GameVictoryEvent>(GameVictory);
		EventManager.Instance.RemoveListener<GameMap1Event>(GameMap1);
		EventManager.Instance.RemoveListener<GameMap2Event>(GameMap2);
		EventManager.Instance.RemoveListener<GameMapSelectorEvent>(GameMapSelector);
		EventManager.Instance.RemoveListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
	}

	protected override void Awake()
	{
		base.Awake();
		SubscribeEvents();
	}

	protected virtual void OnDestroy()
	{
		UnsubscribeEvents();
	}

	protected virtual void GameMenu(GameMenuEvent e)
	{
	}

	protected virtual void GamePlay(GamePlayEvent e)
	{
	}

	protected virtual void GamePause(GamePauseEvent e)
	{
	}

	protected virtual void GameResume(GameResumeEvent e)
	{
	}

	protected virtual void GameOver(GameOverEvent e)
	{
	}

	protected virtual void GameVictory(GameVictoryEvent e)
	{
	}

	protected virtual void GameMap1(GameMap1Event e)
	{
	}
	protected virtual void GameMap2(GameMap2Event e)
	{
	}	
	protected virtual void GameMapSelector(GameMapSelectorEvent e)
	{
	}
	protected virtual void GameStatisticsChanged(GameStatisticsChangedEvent e)
	{
	}


}
