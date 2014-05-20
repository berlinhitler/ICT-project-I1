#pragma once

#ifndef _GPSX_HPP_
#define _GPSX_HPP_

/*
===============================================================================

	GPSX - The base object for entities with position data (Worldspace, Relative or Camera)
	Author - Joshua Richardson
	GPSX Developer - http://www.topografix.com/gpx.asp
	TimyXML-2 - http://www.grinninglizard.com/tinyxml2docs/index.html

===============================================================================
*/

#include "GPSLog.hpp"
#include "..\XML\tinyxml2.h"

class GPSX : public GPSLog {

public:
	GPSX();
	~GPSX();

public:
	bool Import(const char* filename);

private:
	tinyxml2::XMLDocument m_XMLParser;

};

#endif