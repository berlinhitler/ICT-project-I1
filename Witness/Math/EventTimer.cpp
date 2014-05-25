#include "EventTimer.hpp"

int CompareTime(time_t time1,time_t time2) {
	return difftime(time1,time2) > 0.0 ? 1 : -1; 
}

double diffclock(clock_t clock1, clock_t clock2) {
    double diffticks = clock1 - clock2;
    double diffms = (diffticks) / (CLOCKS_PER_SEC / NUMBER);
    return diffms;
}

EventTimer::EventTimer() : started(false), firstTimeStamp(0), lastTimeStamp(), currentTime(0), baseTime(0), actors(), actorPhases(), CameraStream(0) {
	time(&firstTimeStamp);
}

void EventTimer::RegisterActor(Actor* TargetActor) {
	if (TargetActor != 0) {
		actors.push_back(TargetActor);
		actorPhases[TargetActor] = 0;
	}
	for (unsigned int i = 0; i < actors.size(); i++) {
		for(std::map<time_t, GPSEntry>::iterator iter = actors[i]->GetGPSData()->m_LogData.begin(); iter != actors[i]->GetGPSData()->m_LogData.end(); ++iter) {
			time_t timeStamp =  iter->first;
			if (CompareTime(firstTimeStamp, timeStamp) > 0) {
				firstTimeStamp = timeStamp;
			}
			if (CompareTime(lastTimeStamp, timeStamp) < 0) {
				lastTimeStamp = timeStamp;
			}
		}
	}
}

void EventTimer::RegisterRealCamera(StreamPGR* CameraStream) {
	this->CameraStream = CameraStream;
}

void EventTimer::Start() {
	baseTime = clock();
	started = true;
}

void EventTimer::Stop() {
	started = false;
}

void EventTimer::Update() {
	
	if (!started) {
		return;
	}

	// Store as we perform multiple operations that would mean a diffrent time registered for each clock call
	clock_t polledTime = clock();

	// Determine the relavent time since start
	currentTime = polledTime - baseTime;

	// Determine the delta from the last frame, used for moving objects
	double delta = polledTime - lastTime; 

	// Update the registered time
	lastTime = polledTime;

	if ((firstTimeStamp + (currentTime / CLOCKS_PER_SEC) > lastTimeStamp)) {
		printf("Reset!\n");
		baseTime = clock();
		lastTime = 0;
		return;
	}

	for (int i = 0; i < actors.size(); i++) {

		// Check object to see if it is in the bounds of the current time frame
		if (actors[i]->CheckTimeBounds(currentTime / CLOCKS_PER_SEC, firstTimeStamp)) {

			// Get the current phase of the actor
			int currentPhase = actors[i]->GetPhase(currentTime / CLOCKS_PER_SEC);

			// If we have a new direction, update the phase.
			if (currentPhase != actorPhases[actors[i]]) {

				// For Debugging
				printf("Actor[%d] { Phase: %d | Time until next phase: %d }\n", i, currentPhase, actors[i]->GetPhaseTime(currentPhase));

				// Update our actor to show the new phase
				actorPhases[actors[i]] = currentPhase;

			}

			// Obtain handle to render object
			Renderable* renderableObject = actors[i]->GetRenderable();

			// Get the direction vector


		}
	}
}

EventTimer::~EventTimer() {
}