#pragma once

#include <stdio.h>
#include <ladybugstream.h>

class StreamPGR {

public:
	StreamPGR();
	StreamPGR(const char* filename);
	~StreamPGR();

public:
	bool LoadFile(const char* filename);
	void Destroy();

private:
	LadybugContext Context;
	LadybugStreamContext ReadContext;
	LadybugStreamHeadInfo StreamHeaderInfo;

private:
	LadybugColorProcessingMethod ColorProcessingMethod;
	float fFalloffCorrectionValue;
	bool bFalloffCorrectionFlagOn;
	int textureWidth;
	int textureHeight;

private:
	bool CheckError(LadybugError Error);
	void PrintHeaderInformation(LadybugStreamHeadInfo HeaderInfo);
	bool SaveStream(LadybugStreamContext& Context);
	void SetTextureBounds(LadybugImage& Image);

private:
	bool StreamReady;

};