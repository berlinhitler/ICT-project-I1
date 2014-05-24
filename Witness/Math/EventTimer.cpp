#include "EventTimer.hpp"

int CompareTime(time_t time1,time_t time2) {
	return difftime(time1,time2) > 0.0 ? 1 : -1; 
}

double diffclock(clock_t clock1, clock_t clock2) {
    double diffticks = clock1 - clock2;
    double diffms = (diffticks) / (CLOCKS_PER_SEC / NUMBER);
    return diffms;
}

EventTimer::EventTimer() : firstTimeStamp(0), lastTimeStamp(), currentTime(0), actors(), CameraStream(0) {
	time(&firstTimeStamp);
}

void EventTimer::RegisterActor(Actor* TargetActor) {
	if (TargetActor != 0) {
		actors.push_back(TargetActor);
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

}

void EventTimer::Pause() {

}

void EventTimer::Stop() {

}

void EventTimer::Update() {
	
	for (int i = 0; i < actors.size(); i++) {

		// Check object to see if it is in the bounds of the current time frame
		if (actors[i]->CheckTimeBounds(currentTime, firstTimeStamp)) {

			// Obtain handles to the actors render state and target point
			Renderable* renderableObject = actors[i]->GetRenderable();
			glm::vec3 objectToMoveTo = actors[i]->GetNextPoint();

			// Get the current phase of the actor


			// Translate the object by 
		}
	}
}

EventTimer::~EventTimer() {
}