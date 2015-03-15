#include <cmath>

#include "ComplexNumber.h"

using namespace std;
using namespace Mathos::Arithmetic::ComplexNumbers;

ComplexNumber::ComplexNumber(int64_t inRealPart) : RealPart(inRealPart), ImaginaryPart(0) {}
ComplexNumber::ComplexNumber(double inRealPart) : RealPart(inRealPart), ImaginaryPart(0) {}
ComplexNumber::ComplexNumber(int inRealPart, int inImaginaryPart) : RealPart(inRealPart), ImaginaryPart(inImaginaryPart) {}
ComplexNumber::ComplexNumber(double inRealPart, double inImaginaryPart) : RealPart(inRealPart), ImaginaryPart(inImaginaryPart) {}

ComplexNumber::ComplexNumber(std::string strcomplex) {
	RealPart = 0;
	ImaginaryPart = 0;

	char * seperator = {};
	int factor = 1;

	if (strcomplex.find("+") > 0) {
		seperator = new char[] {'+', 'i'};
		factor = 1;
	}
	else if (strcomplex.find("-") > 0) {
		seperator = new char[] {'-', 'i'};
		factor = -1;
	}


}

double ComplexNumber::Modulus() {
	if (abs(RealPart) >= abs(ImaginaryPart)) {
		return abs(RealPart) * sqrt(1 + pow(ImaginaryPart / RealPart, 2));
	}

	return abs(ImaginaryPart) * sqrt(1 + pow(RealPart / ImaginaryPart, 2));
}

double ComplexNumber::Argument() {
	if (abs(RealPart) < 1 && abs(ImaginaryPart) < 1)
		return 0;

	return atan2(ImaginaryPart, RealPart);
}

bool ComplexNumber::IsReal() {
	return abs(ImaginaryPart) < 1;
}

bool ComplexNumber::IsPureImaginary() {
	return abs(RealPart) < 1;
}

ComplexNumber * ComplexNumber::Conjugate() {
	return new ComplexNumber(RealPart, ImaginaryPart);
}
