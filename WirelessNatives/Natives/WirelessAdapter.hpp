#pragma once

#include "Common.hpp"

struct Adapter {
	int m_Index;
	WLAN_INTERFACE_INFO* m_WinInterface;
	WCHAR m_GUID[39];
};

class WirelessAdapter {

public:
	WirelessAdapter();
	~WirelessAdapter();

public:
	bool Open();
	void Print();

public:
	Adapter m_Adapters[64];
	HANDLE m_WirelessHandle;
	PWLAN_INTERFACE_INFO_LIST m_InterfaceListing;
	unsigned int m_AdapterCount;
};