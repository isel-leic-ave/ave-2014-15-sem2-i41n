#include <iostream>
using namespace std;

const int nblocos = 1024*1024*1024;
const int size = 1000;

int main(int argc, char* argv[]) {
	int j;
	try {
	  char *ptr;
	  for ( j=0; j <nblocos; ++j) {
		ptr = new char[size];
	  }
	   
	}
	catch (...) {  cout << "error allocating memory! j=" << j << endl;  }
	return 0;
}
