#include "WirelessScanner.hpp"

WirelessScanner::WirelessScanner() : m_WirelessClientCount(0) {
	memset(&m_WirelessClients, 0, sizeof(WirelessAP)*256);
}

bool WirelessScanner::Scan(const WirelessAdapter* SrcAdapter) {

	DWORD OperationResult = -1;
	PWLAN_AVAILABLE_NETWORK_LIST WirelessNetworkList;
	m_WirelessClientCount = 0;

	

	for (unsigned int i = 0; i < SrcAdapter->m_AdapterCount; i++) {
		WlanScan(SrcAdapter->m_WirelessHandle, &SrcAdapter->m_Adapters[i].m_WinInterface->InterfaceGuid, 0, 0, 0);
		OperationResult = WlanGetAvailableNetworkList(SrcAdapter->m_WirelessHandle, &SrcAdapter->m_Adapters[i].m_WinInterface->InterfaceGuid, 0, 0, &WirelessNetworkList);

		if (OperationResult != ERROR_SUCCESS) {
			printf("WlanGetAvailableNetworkList failed with error: %d", OperationResult);
			return false;
		}

		for (unsigned int j = 0, k = 0; j < WirelessNetworkList->dwNumberOfItems; j++) {
			if (!(WirelessNetworkList->Network[j].dwFlags & WLAN_AVAILABLE_NETWORK_HAS_PROFILE)) {
				m_WirelessClients[k] = WirelessAP();
				m_WirelessClients[k].Initalize(&WirelessNetworkList->Network[j]);
				m_WirelessClientCount++;
				k++;
			}
		}

	}

	return true;
}

void WirelessScanner::Print() {
	printf("-----\n");
	for (unsigned int i = 0; i < m_WirelessClientCount; i++) {
		m_WirelessClients[i].Print();
	}
	printf("-----\n");
}

WirelessScanner::~WirelessScanner() {
}