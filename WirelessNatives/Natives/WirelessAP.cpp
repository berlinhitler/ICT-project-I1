#include "WirelessAP.hpp"
#include <string>

WirelessAP::WirelessAP() : m_RSSI(0), m_SignalStrengthQuality(0), m_SSIDLength(0) {
	memset(m_ProfileName, 0, sizeof(WCHAR)*256);
	memset(m_SSID, 0, sizeof(UCHAR)*256);
}

void WirelessAP::Initalize(PWLAN_AVAILABLE_NETWORK WirelessNetworkInstance) {
	wsprintf(m_ProfileName, WirelessNetworkInstance->strProfileName);
	m_SSIDLength = WirelessNetworkInstance->dot11Ssid.uSSIDLength;
	for (unsigned int i = 0; i < WirelessNetworkInstance->dot11Ssid.uSSIDLength; i++) {
		m_SSID[i] = WirelessNetworkInstance->dot11Ssid.ucSSID[i];
	}

	m_SignalStrengthQuality = WirelessNetworkInstance->wlanSignalQuality;
	if (WirelessNetworkInstance->wlanSignalQuality == 0) {
		m_RSSI = -100;
	} else if (WirelessNetworkInstance->wlanSignalQuality == 100) {
		m_RSSI = -50;
	} else {
		m_RSSI = -100 + (WirelessNetworkInstance->wlanSignalQuality / 2);
	}
}

void WirelessAP::Print() {
	wprintf(L"Profile Name: %s\n", m_ProfileName);
	printf("SSID: ");
	for (unsigned int i = 0; i < m_SSIDLength; i++) {
		printf("%c", m_SSID[i]);
	}
	printf("\n");
	printf("Signal Strength: %u (RSSI: %i dBm)\n", m_SignalStrengthQuality, m_RSSI);
}

WirelessAP::~WirelessAP() {
}