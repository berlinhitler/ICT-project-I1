#pragma once

#define EARTH_RADIUS 6371
#define EARTH_RADIUS_M 6371000

/*
 * World Space Conversions
 */

double WS_GetDistanceBetween(double sourceLatitude, double sourceLongitude, double objectLatitude, double objectLongitude);
void WS_RealSpace(double originLatitude, double originLongitude, double objectLatitude, double objectLongitude, double* X, double* Y);