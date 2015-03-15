namespace Mathos {
	namespace Arithmetic {
		namespace ComplexNumbers{
			#include <cstdint>
			#include <string>

			struct ComplexNumber {
			public:
				ComplexNumber(int64_t inRealPart);
				ComplexNumber(double inRealPart);
				ComplexNumber(int inRealPart, int inImaginaryPart);
				ComplexNumber(double inRealPart, double inImaginaryPart);
				ComplexNumber(std::string strcomplex);

				double RealPart;
				double ImaginaryPart;

				double Modulus();
				double Argument();
				
				bool IsReal();
				bool IsPureImaginary();

				ComplexNumber * Conjugate();
			private:
			};
		}
	}
}
