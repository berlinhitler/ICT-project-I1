#include "GPSLog.hpp"

GPSLog::GPSLog() : m_LogData() {
}

void GPSLog::Log(time_t timeStamp, double latitude, double longitude) {
	m_LogData[timeStamp] = GPSEntry(latitude, longitude);
}

void GPSLog::Log(time_t timeStamp, int latitude, int longitude) {
	m_LogData[timeStamp] = GPSEntry(latitude, longitude);
}

GPSLog::~GPSLog() {
}