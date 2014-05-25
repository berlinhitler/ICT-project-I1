#pragma once

#include <vector>
#include <time.h>
#include "..\Core\Actor.hpp"
#include "..\PGR\StreamPGR.hpp"
#include "SpaceConverter.hpp"

#define NUMBER 10000

int CompareTime(time_t time1,time_t time2);
double diffclock(clock_t clock1, clock_t clock2);

class EventTimer {

public:
	EventTimer();
	~EventTimer();

public:
	void RegisterActor(Actor* TargetActor);
	void RegisterRealCamera(StreamPGR* CameraStream);

public:
	void Start();
	void Stop();
	void Update();

private:
	bool started;

	time_t firstTimeStamp;
	time_t lastTimeStamp;

	clock_t currentTime;
	clock_t baseTime;
	clock_t lastTime;

	std::vector<Actor*> actors;
	std::map<Actor*, int> actorPhases;
	StreamPGR* CameraStream;
};