#pragma once

#ifndef _GPSLOG_HPP_
#define _GPSLOG_HPP_

/*
===============================================================================

	GPSLog - Time V GPSEntry listing
	Author - Joshua Richardson

===============================================================================
*/

#include <map>
#include <iterator>
#include "GPSEntry.hpp"

class GPSLog {

public:
	GPSLog();
	~GPSLog();

public:
	void Log(time_t timeStamp, double latitude, double longitude);
	void Log(time_t timeStamp, int latitude, int longitude);

public:
	std::map<time_t, GPSEntry> m_LogData;

};

#endif