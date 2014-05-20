#include "WirelessNatives.hpp"

#include "Natives\Common.hpp"
#include "Natives\WirelessAdapter.hpp"
#include "Natives\WirelessAP.hpp"
#include "Natives\WirelessScanner.hpp"

#include <map>
#include <string>

WirelessAdapter refrenceAdapter;
WirelessScanner wirelessScanner;

void Initalize() {
	refrenceAdapter.Open();
}

void PollAdapter() {
	wirelessScanner.Scan(&refrenceAdapter);
}

int __stdcall GetRSSI(const char* AccessPointName) {

	for (unsigned int i = 0; i < wirelessScanner.m_WirelessClientCount; i++) {
		WirelessAP* VisableAccessPoint = &wirelessScanner.m_WirelessClients[i];
		
		if (strcmp(AccessPointName, (char*)VisableAccessPoint->m_SSID) == 0) {
			return VisableAccessPoint->m_RSSI;
		}

	}

	return 0;
}