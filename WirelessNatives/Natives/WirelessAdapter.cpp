#include "WirelessAdapter.hpp"

void ClearAdapter(Adapter& SrcAdapter);

WirelessAdapter::WirelessAdapter() : m_WirelessHandle(0), m_InterfaceListing(0), m_AdapterCount(0) {
	for (unsigned int i = 0; i < 64; i++) {
		ClearAdapter(m_Adapters[i]);
	}
}

bool WirelessAdapter::Open() {
	DWORD OperationResult = -1;
	DWORD CurrentWirelessVersion = -1;

	OperationResult = WlanOpenHandle(2, 0, &CurrentWirelessVersion, &m_WirelessHandle);

	if (OperationResult != ERROR_SUCCESS) {
		printf("WlanOpenHandle failed with error: %d", OperationResult);
		return false;
	}

	OperationResult = WlanEnumInterfaces(m_WirelessHandle, NULL, &m_InterfaceListing);

	if (OperationResult != ERROR_SUCCESS) {
		printf("WlanEnumInterfaces failed with error: %d", OperationResult);
		return false;
	}

	for (unsigned int i = 0; i < m_InterfaceListing->dwNumberOfItems; i++) {
		m_Adapters[i] = Adapter();
		m_Adapters[i].m_Index = i;
		m_Adapters[i].m_WinInterface = (WLAN_INTERFACE_INFO*)&m_InterfaceListing->InterfaceInfo[i];

		if (StringFromGUID2(m_Adapters[i].m_WinInterface->InterfaceGuid, (LPOLESTR)&m_Adapters[i].m_GUID, sizeof(m_Adapters[i].m_GUID)/sizeof(*m_Adapters[i].m_GUID)) == 0) {
			printf("StringFromGUID2 failed");
			return false;
		}

		m_AdapterCount++;
	}

	return true;
}

void WirelessAdapter::Print() {

	// Top level adapters
	printf("-------------------------\n");
	printf("%-5s | %-20s \n", "Index", "GUID");
	printf("-------------------------\n");
	// Print individual adapters
	for (unsigned int i = 0; i < m_AdapterCount; i++) {
		wprintf(L"%-5d | %-20s \n", i, m_Adapters[i].m_GUID);
	}
	printf("------------------------\n");
}

WirelessAdapter::~WirelessAdapter() {
}

void ClearAdapter(Adapter& SrcAdapter) {
	SrcAdapter = Adapter();
	SrcAdapter.m_Index = -1;
	memset(SrcAdapter.m_GUID, 0, 39);
}