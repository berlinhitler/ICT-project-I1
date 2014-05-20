#include "GPSX.hpp"
#include "..\3rdParty\strptime.hpp"
#include <ctime>

GPSX::GPSX() : GPSLog(), m_XMLParser() {
}

bool GPSX::Import(const char* filename) {
	if (filename == 0) {
		return false;
	}

	m_XMLParser.LoadFile(filename);

	if (m_XMLParser.ErrorID() != 0) {
		return false;
	}

	tinyxml2::XMLElement* rootGPSX = m_XMLParser.FirstChildElement("gpx");

	// Not A Valid GPSX File
	if (rootGPSX == 0) {
		return false;
	}

	tinyxml2::XMLElement* trackGPSX = rootGPSX->FirstChildElement("trk");

	// No Track Record Found
	if (trackGPSX == 0) {
		return false;
	}

	tinyxml2::XMLElement* firstTrackSegmentGPXS = trackGPSX->FirstChildElement("trkseg");

	// No Tracks Recorded / Empty Track
	if (firstTrackSegmentGPXS == 0) {
		return false;
	}

	for( tinyxml2::XMLElement* currentRecordingGPXS = firstTrackSegmentGPXS->FirstChildElement( "trkpt" );
			 currentRecordingGPXS;
			 currentRecordingGPXS = currentRecordingGPXS->NextSiblingElement() ) {

		// Obtain Lat & Long
		double latitude = 0, longitude = 0;
		currentRecordingGPXS->QueryDoubleAttribute("lat", &latitude);
		currentRecordingGPXS->QueryDoubleAttribute("lon", &longitude);

		// Determin Time
		tinyxml2::XMLNode* timeStampGPSX = currentRecordingGPXS->FirstChildElement("time")->FirstChild();

		// Check For valid Time Stamp
		if (timeStampGPSX == 0) {
			return false;
		}

		tinyxml2::XMLText* timeStampTextGPSX = timeStampGPSX->ToText();

		// Check If We Can Extract The Text
		if (timeStampTextGPSX == 0) {
			return false;
		}

		// Extract Just The Time
		const char* timeStampText = timeStampTextGPSX->Value();

		if (timeStampText == 0) {
			return false;
		}

		// Convert String To Time Structure
		struct tm timeStamp;
		time_t timeStampKey;
		memset(&timeStamp, 0, sizeof(tm));
		memset(&timeStampKey, 0, sizeof(time_t));
		strptime(timeStampText, "%Y-%m-%dT%H:%M:%SZ", &timeStamp);
		timeStampKey = mktime(&timeStamp);

		// Log The Position
		Log(timeStampKey, latitude, longitude);
		printf("%s : { %f | %f }\n", timeStampText, latitude, longitude);
	}

	return true;
}

GPSX::~GPSX() {
}