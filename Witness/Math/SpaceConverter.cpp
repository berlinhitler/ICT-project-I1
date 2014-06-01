#include "SpaceConverter.hpp"
#include <glm\geometric.hpp>
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

double RS_CameraSpace_ThinLense(double focalLength, double z0) {
	return (focalLength * z0) / (z0 - focalLength);
}

int CS_GetProjectionPlane(double z0, double zi, int h) {
	return zi * (h / z0);
}

glm::vec3 RS_GetDirection(glm::vec3 vec1, glm::vec3 vec2) {
	return vec2 - vec1;
}

glm::vec3 RS_Lerp( const glm::vec3& vec1, const glm::vec3& vec2, float t ) {
	glm::vec3 vec1_t = vec1*t;
	glm::vec3 vec2_t = vec2*(1.f-t);
	//return vec1*t + vec2*(1.f-t) ;
	glm::vec3 return_vec = vec1_t+vec2_t;
	return_vec.y = 0.0f;
	return return_vec;
}