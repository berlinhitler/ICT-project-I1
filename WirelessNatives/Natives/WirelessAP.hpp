#pragma once

#include "Common.hpp"

class WirelessAP {
	
public:
	WirelessAP();
	~WirelessAP();

public:
	void Initalize(PWLAN_AVAILABLE_NETWORK WirelessNetworkInstance);
	void Print();

public:
	WCHAR m_ProfileName[256];
	UCHAR m_SSID[256];
	int m_RSSI;
	int m_SignalStrengthQuality;
	unsigned int m_SSIDLength;
};