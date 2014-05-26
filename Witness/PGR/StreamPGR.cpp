#include "StreamPGR.hpp"

StreamPGR::StreamPGR() : Context(), StreamReady(false), ColorProcessingMethod(LADYBUG_HQLINEAR), fFalloffCorrectionValue(1.0f), bFalloffCorrectionFlagOn(false) {
}

StreamPGR::StreamPGR(const char* filename) : StreamReady(false) {
	if (!LoadFile(filename)) {
		StreamReady = false;
	} else {
		StreamReady = true;
	}
}

bool StreamPGR::LoadFile(const char* filename) {
	LadybugError error;

	if (CheckError(ladybugCreateContext( &Context ))) {
		return false;
	}

	if (CheckError(ladybugCreateStreamContext( &ReadContext ))) {
		return false;
	}

	if (CheckError(ladybugInitializeStreamForReading( ReadContext, filename, true ))) {
		return false;
	}

	if (CheckError(ladybugGetStreamHeader( ReadContext, &StreamHeaderInfo ))) {
		return false;
	}

	PrintHeaderInformation(StreamHeaderInfo);

	if (CheckError(ladybugSetColorProcessingMethod( Context, ColorProcessingMethod))) {
		return false;
	}

	if (CheckError(ladybugSetFalloffCorrectionAttenuation( Context, fFalloffCorrectionValue ))) {
		return false;
	}

	if (CheckError(ladybugSetFalloffCorrectionFlag( Context, bFalloffCorrectionFlagOn ))) {
		return false;
	}

	if (!SaveStream(Context)) {
		return false;
	}

	return false;
}

void StreamPGR::Destroy() {
}

bool StreamPGR::CheckError(LadybugError Error) {
	if (Error != LADYBUG_OK) {
		printf("Ladybug Error: %s\n", ladybugErrorToString( Error ) );
		return true;
	}
	return false;
}

void StreamPGR::PrintHeaderInformation(LadybugStreamHeadInfo HeaderInfo) {
	const float frameRateToUse = StreamHeaderInfo.ulLadybugStreamVersion < 7 ? (float)StreamHeaderInfo.ulFrameRate : StreamHeaderInfo.frameRate;
    printf( "--- Stream Information ---\n");
    printf( "Stream version : %d\n", StreamHeaderInfo.ulLadybugStreamVersion);
    printf( "Base S/N: %d\n", StreamHeaderInfo.serialBase);
    printf( "Head S/N: %d\n", StreamHeaderInfo.serialHead);
    printf( "Frame rate : %3.2f\n", frameRateToUse);
    printf( "--------------------------\n");
}

bool StreamPGR::SaveStream(LadybugStreamContext& Context) {
	LadybugImage image;
	if (CheckError(ladybugReadImageFromStream(Context, &image))) {
		return false;
	}
	SetTextureBounds(image);
	return true;
}

void StreamPGR::SetTextureBounds(LadybugImage& Image) {
    if ( ColorProcessingMethod == LADYBUG_DOWNSAMPLE4 || ColorProcessingMethod == LADYBUG_MONO)
    {
        textureWidth = Image.uiCols / 2;
        textureHeight = Image.uiRows / 2;
    }
    else
    {
        textureWidth = Image.uiCols;
        textureHeight = Image.uiRows;
    }
}

StreamPGR::~StreamPGR() {
}
