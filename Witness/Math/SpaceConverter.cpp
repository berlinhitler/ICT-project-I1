#include "SpaceConverter.hpp"

#include <math.h>

double WS_GetDistanceBetween(double sourceLatitude, double sourceLongitude, double objectLatitude, double objectLongitude) {
	double Lat = (objectLatitude - sourceLatitude)*(3.14159265/180);
	double Lon = (objectLongitude - sourceLongitude)*(3.14159265/180);
	double a = sin(Lat/2) * sin(Lat/2) + sin(Lon/2) * sin(Lon/2) * cos(sourceLatitude*(3.14159265/180)) * cos(objectLatitude*(3.14159265/180)); 
	double c = 2 * atan2(sqrt(a), sqrt(1-a)); 
	double distance = EARTH_RADIUS * c;
	return distance;
}

void WS_RealSpace(double originLatitude, double originLongitude, double objectLatitude, double objectLongitude, double* X, double* Y) {
	*X = (objectLatitude - originLatitude)*(3.14159265/180);
	*Y = (objectLongitude - originLongitude)*(3.14159265/180);
}

glm::vec3 RS_GetDirection(glm::vec3 vec1, glm::vec3 vec2) {
	return vec2 - vec1;
}