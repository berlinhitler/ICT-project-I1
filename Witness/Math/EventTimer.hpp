#pragma once

#include <vector>
#include <time.h>
#include "..\Core\Actor.hpp"
#include "..\PGR\StreamPGR.hpp"
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
	void Pause();
	void Stop();
	void Update();

private:
	time_t firstTimeStamp;
	time_t lastTimeStamp;
	clock_t currentTime;
	std::vector<Actor*> actors;
	StreamPGR* CameraStream;
};