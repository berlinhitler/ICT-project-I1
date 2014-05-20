#pragma once

#ifndef _GPSENTRY_HPP_
#define _GPSENTRY_HPP_

/*
===============================================================================

	GPSEntry - Latitude & Longitude
	Author - Joshua Richardson

===============================================================================
*/

class GPSEntry {

public:
	GPSEntry();
	GPSEntry(double latitude, double longitude);
	GPSEntry(int latitude, int longitude);
	~GPSEntry() {}

public:
	double m_Latitude;
	double m_Longitude;
};

inline GPSEntry::GPSEntry() {
	this->m_Latitude = 0;
	this->m_Longitude = 0;
}

inline GPSEntry::GPSEntry(double latitude, double longitude) {
	this->m_Latitude = latitude;
	this->m_Longitude = longitude;
}

// Prevent compiler warnings with level 4 warning level
inline GPSEntry::GPSEntry(int latitude, int longitude) {
	this->m_Latitude = (int)latitude;
	this->m_Longitude = (int)longitude;
}

#endif