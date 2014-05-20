#include "Actor.hpp"

Actor::Actor() : drawIndex(0) {
}

void Actor::Initalize(const char* GPSData, double OriginLatitude, double OriginLongitude) {
	gpsData.Import(GPSData);
	UpdatePoints(OriginLatitude, OriginLongitude);
	renderObject = new Cube();

	renderObject->SetRealPosition(loggedPoints.front());
	((Cube*)renderObject)->Scale(glm::vec3(0.5f, 0.5f, 0.5f));
}

void Actor::Destroy() {
	if (renderObject) {
		delete renderObject;
	}
}

void Actor::Update(double delta) {
}

Renderable* Actor::GetRenderable() {
	return renderObject;
}

void Actor::Step() {
	drawIndex++;

	if (drawIndex == loggedPoints.size()) {
		drawIndex = 0;
	}

	renderObject->SetRealPosition(loggedPoints[drawIndex]);
}

void Actor::StepBack() {
	drawIndex--;

	if (drawIndex < 0) {
		drawIndex = loggedPoints.size()-1;
	}

	renderObject->SetRealPosition(loggedPoints[drawIndex]);
}

void Actor::UpdatePoints(double OriginLatitude, double OriginLongitude) {

	int index = 0;
	for(it_type iterator = gpsData.m_LogData.begin(); iterator != gpsData.m_LogData.end(); iterator++) {

		double CurrentDistance = WS_GetDistanceBetween(OriginLatitude, OriginLongitude, iterator->second.m_Latitude, iterator->second.m_Longitude);
		double x, y;

		WS_RealSpace(OriginLatitude, OriginLongitude, 
						 iterator->second.m_Latitude, iterator->second.m_Longitude, 
						 &x, &y);

		loggedPoints.push_back(glm::vec3(x*WORLD_SCALE, 0, y*WORLD_SCALE));
		loggedDistances.push_back(CurrentDistance);
		index++;
	}
}

Actor::~Actor() {
}