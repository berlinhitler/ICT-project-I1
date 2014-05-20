#pragma once

#include "Common.hpp"

#include "WirelessAP.hpp"
#include "WirelessAdapter.hpp"

class WirelessScanner {

public:
	WirelessScanner();
	~WirelessScanner();

public:
	bool Scan(const WirelessAdapter* SrcAdapter);
	void Print();

public:
	WirelessAP m_WirelessClients[256];
	unsigned int m_WirelessClientCount;
};