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

	error = ladybugCreateContext( &Context );
	if (CheckError(error)) {
		return false;
	}

	error = ladybugCreateStreamContext( &ReadContext );
	if (CheckError(error)) {
		return false;
	}

	error = ladybugInitializeStreamForReading( ReadContext, filename, true );
	if (CheckError(error)) {
		return false;
	}

	error = ladybugGetStreamHeader( ReadContext, &StreamHeaderInfo );
	if (CheckError(error)) {
		return false;
	}

    const float frameRateToUse = StreamHeaderInfo.ulLadybugStreamVersion < 7 ? (float)StreamHeaderInfo.ulFrameRate : StreamHeaderInfo.frameRate;

    printf( "--- Stream Information ---\n");
    printf( "Stream version : %d\n", StreamHeaderInfo.ulLadybugStreamVersion);
    printf( "Base S/N: %d\n", StreamHeaderInfo.serialBase);
    printf( "Head S/N: %d\n", StreamHeaderInfo.serialHead);
    printf( "Frame rate : %3.2f\n", frameRateToUse);
    printf( "--------------------------\n");

	error = ladybugSetColorProcessingMethod( Context, ColorProcessingMethod);
	if (CheckError(error)) {
		return false;
	}

    error = ladybugSetFalloffCorrectionAttenuation( Context, fFalloffCorrectionValue );
	if (CheckError(error)) {
		return false;
	}

    error = ladybugSetFalloffCorrectionFlag( Context, bFalloffCorrectionFlagOn );
	if (CheckError(error)) {
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

StreamPGR::~StreamPGR() {
}
