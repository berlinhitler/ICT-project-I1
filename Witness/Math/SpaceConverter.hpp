#pragma once

#define EARTH_RADIUS 6371
#define EARTH_RADIUS_M 6371000

#include "glm\vec3.hpp"

/*
 * World Space Conversions
 */

double WS_GetDistanceBetween(double sourceLatitude, double sourceLongitude, double objectLatitude, double objectLongitude);
void WS_RealSpace(double originLatitude, double originLongitude, double objectLatitude, double objectLongitude, double* X, double* Y);
glm::vec3 RS_GetDirection(glm::vec3 vec1, glm::vec3 vec2);